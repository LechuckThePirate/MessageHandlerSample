using MessageHandlerSample.DTO;
using MessageHandlerSample.Responses.Base;
using System;

namespace MessageHandlerSample.Responses
{
    [HandlesResponseType("THIRD")]
    public class ThirdResponse : GenericResponse<ThirdDTO>
    {

        public ThirdResponse(string value) : base(value) { }

        public override ThirdDTO GetValue()
        {
            try
            {
                var result = new ThirdDTO();
                var valueArray = this.Value.Split(FieldSeparator);
                result.Number = long.Parse(valueArray[1]);
                return result;
            }
            catch
            {
                throw new FormatException();
            }

        }
    }
}
