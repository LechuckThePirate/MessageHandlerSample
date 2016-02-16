using MessageHandlerSample.DTO;
using MessageHandlerSample.Responses.Base;
using System;

namespace MessageHandlerSample.Responses
{
    [HandlesResponseType("ARTICLE")]
    public class AnotherResponse : GenericResponse<AnotherDTO>
    {
        public AnotherResponse(string value) : base(value) { }

        public override AnotherDTO GetValue()
        {
            try
            {
                var result = new AnotherDTO();
                var valueArray = this.Value.Split(FieldSeparator);
                result.Code = valueArray[1];
                result.IsActive = bool.Parse(valueArray[2]);
                result.Quantity = decimal.Parse(valueArray[3]);
                return result;
            }
            catch
            {
                throw new FormatException();
            }
        }
    }
}
