using MessageHandlerSample.DTO;
using MessageHandlerSample.Responses.Base;
using System;

namespace MessageHandlerSample.Responses
{
    [HandlesResponseType("TABLE")]
    public class TestResponse : GenericResponse<TestDTO>
    {

        public TestResponse(string value) : base(value) { }

        public override TestDTO GetValue()
        {
            try
            {
                var result = new TestDTO();
                var valueArray = this.Value.Split(FieldSeparator);
                result.Id = long.Parse(valueArray[1]);
                result.Name = valueArray[2];
                return result;
            }
            catch
            {
                throw new FormatException();
            }
        }

    }
}
