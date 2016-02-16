using MessageHandlerSample.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageHandlerSample
{
    class Program
    {

        static void Main(string[] args)
        {

            var responseList = new List<string>
            {
                "TABLE|10|Item Id 10",
                "ARTICLE|ABCCDEE|true|2,5",
                "TABLE|15|Item Id 15",
                "TABLE|20|Item Id 20",
                "CALENDAR|01/05/2016 14:00|Meeting",
                "ARTICLE|9388d99|false|0,20",
                "CALENDAR|06/02/2017 17:00|Buy more Redbull"
            };

            Console.WriteLine("Processing list: ");
            Console.WriteLine();

            var responses = responseList.Select(responseString => ResponseFactory.Create(responseString));

            // If you want to process the responses
            ProcessTableResponses(responses.OfType<TableResponse>());
            ProcessArticleResponses(responses.OfType<ArticleResponse>());
            ProcessCalendarResponses(responses.OfType<CalendarResponse>());

            // If you just want the DTOs
            var tableDtos = responses.OfType<TableResponse>().Select(r => r.GetValue());
            var articleDtos = responses.OfType<ArticleResponse>().Select(r => r.GetValue());
            var calendarDtos = responses.OfType<CalendarResponse>().Select(r => r.GetValue());

            Console.WriteLine();
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }

        private static void ProcessTableResponses(IEnumerable<TableResponse> responses)
        {
            responses.Select(r => r.GetValue())
                .ForEach(dto => Console.WriteLine($"Id: {dto.Id}, Name: {dto.Name}"));
        }

        private static void ProcessArticleResponses(IEnumerable<ArticleResponse> responses)
        {
            responses.Select(r => r.GetValue())
                .ForEach(dto => Console.WriteLine($"Code: {dto.Code}, Active: {dto.IsActive}, Quantity: {dto.Quantity:0.00}"));
        }

        private static void ProcessCalendarResponses(IEnumerable<CalendarResponse> responses)
        {
            responses.Select(r => r.GetValue())
                .ForEach(dto => Console.WriteLine($"Date: {dto.Date}, Description: {dto.Description}"));
        }


    }
}
