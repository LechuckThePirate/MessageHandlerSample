namespace MessageHandlerSample.Responses.Base
{
    public abstract class BaseResponse
    {
        public static char FieldSeparator = '|';

        protected string Value { get; set; }

        public BaseResponse(string value)
        {
            Value = value;
        }

    }
}
