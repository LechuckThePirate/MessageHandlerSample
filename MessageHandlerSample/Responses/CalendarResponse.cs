using MessageHandlerSample.DTO;
using MessageHandlerSample.Responses.Base;
using System;

namespace MessageHandlerSample.Responses
{
    [HandlesResponseType("CALENDAR")]
    public class CalendarResponse : GenericResponse<CalendarDTO>
    {

        public CalendarResponse(string value) : base(value) { }

        public override CalendarDTO GetValue()
        {
            try
            {
                var result = new CalendarDTO();
                var valueArray = this.Value.Split(FieldSeparator);
                result.Date = DateTime.Parse(valueArray[1]);
                result.Description = valueArray[2];
                return result;
            }
            catch
            {
                throw new FormatException();
            }

        }
    }
}
