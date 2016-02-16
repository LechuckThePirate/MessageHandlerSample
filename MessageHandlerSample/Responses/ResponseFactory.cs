using MessageHandlerSample.Responses.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MessageHandlerSample.Responses
{
    public static class ResponseFactory
    {
        #region .: Types, Services and Properties :.

        private delegate object ExpressionTreeActivator(params object[] args);
        private static Dictionary<string, ExpressionTreeActivator> _expressionTreeActivatorsCache;

        #endregion

        #region .: Static Constructor :.

        static ResponseFactory()
        {
            _expressionTreeActivatorsCache = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetCustomAttributes<HandlesResponseTypeAttribute>().Any())
                .Select(type => {
                    var handlesResponseTypeAttr = type.GetCustomAttribute<HandlesResponseTypeAttribute>().ResponseType;
                    return new { key = handlesResponseTypeAttr, activator = BuildExpressionTreeActivatorFor(type) };
                })
                .ToDictionary(o => o.key, o => o.activator);
        }

        #endregion

        #region .: Public Methods :.

        public static BaseResponse Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException();
            // Get the record type
            var responseType = value.Split(BaseResponse.FieldSeparator)[0];
            // Get an activator delegate to create the object from the cache...
            var activator = GetActivatorFor(responseType);
            // Create the object
            var result = activator(value);

            return (BaseResponse)result;
        }

        #endregion

        #region .: Private Methods :.
        
        private static T GetExpressionTreeActivatorFromCtor<T>(ConstructorInfo ctor) where T : class
        {
            var ctorParams = ctor.GetParameters();
            var paramExp = Expression.Parameter(typeof(object[]), "args");
            // Create the expression tree for the constructor's arguments
            var expList = ctorParams.Select((ctp, i) =>
                {
                    var ctorType = ctp.ParameterType;
                    var argExp = Expression.ArrayIndex(paramExp, Expression.Constant(i));
                    var argExpConverted = Expression.Convert(argExp, ctorType);
                    return argExpConverted;
                });
            // Create the expression
            var newExp = Expression.New(ctor, expList);
            // Compile it to get the activator
            return Expression.Lambda<T>(newExp, paramExp).Compile();
        }

        private static ExpressionTreeActivator GetActivatorFor(string responseType)
        {
            // Thread safe...
            lock (_expressionTreeActivatorsCache)
            {
                // If we have no activator for this type, add it to the dictionary
                if (!_expressionTreeActivatorsCache.ContainsKey(responseType))
                    throw new NotImplementedException();
                // Return the activator
                return _expressionTreeActivatorsCache[responseType];
            }
        }

        private static ExpressionTreeActivator BuildExpressionTreeActivatorFor(Type type)
        {
            // Get our type default constructor 
            var ctor = type.GetConstructors().FirstOrDefault();
            // Create the activator
            var result = GetExpressionTreeActivatorFromCtor<ExpressionTreeActivator>(ctor);
            return result;
        }

        #endregion

    }
}
