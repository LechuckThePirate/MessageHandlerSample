using MessageHandlerSample.DTO;
using MessageHandlerSample.Responses.Base;
using System;

namespace MessageHandlerSample.Responses
{
    [HandlesResponseType("ARTICLE")]
    public class ArticleResponse : GenericResponse<ArticleDTO>
    {
        public ArticleResponse(string value) : base(value) { }

        public override ArticleDTO GetValue()
        {
            try
            {
                var result = new ArticleDTO();
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
