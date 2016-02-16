namespace MessageHandlerSample.Responses.Base
{
    public abstract class GenericResponse<T> : BaseResponse where T : class, new()
    {
        public GenericResponse(string value) : base(value) { }

        public abstract T GetValue();
    }
}
