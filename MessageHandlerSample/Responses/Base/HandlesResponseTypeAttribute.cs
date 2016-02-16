using System;

namespace MessageHandlerSample.Responses.Base
{
    /// <summary>
    /// This attribute is used to define what class of response string handles
    /// the class, so the ResponseFactory can locate and instantiate it
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    class HandlesResponseTypeAttribute : Attribute
    {
        public string ResponseType { get; set; }

        public HandlesResponseTypeAttribute(string responseType)
        {
            ResponseType = responseType;
        }
    }
}
