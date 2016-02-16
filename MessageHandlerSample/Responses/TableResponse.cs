using MessageHandlerSample.DTO;
using MessageHandlerSample.Responses.Base;
using System;

namespace MessageHandlerSample.Responses
{
    [HandlesResponseType("TABLE")]
    public class TableResponse : GenericResponse<TableDTO>
    {

        public TableResponse(string value) : base(value) { }

        public override TableDTO GetValue()
        {
            try
            {
                var result = new TableDTO();
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
