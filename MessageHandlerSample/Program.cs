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
                "THIRD|38743",
                "ARTICLE|9388d99|false|0,20",
                "THIRD|99999"
            };

            Console.WriteLine("Processing list: ");
            Console.WriteLine();

            var responses = responseList.Select(responseString => ResponseFactory.Create(responseString));

            // If you want to process the responses
            ProcessTestResponses(responses.OfType<TestResponse>());
            ProcessAnotherResponses(responses.OfType<AnotherResponse>());
            ProcessThirdResponses(responses.OfType<ThirdResponse>());

            // If you just want the DTOs
            var testDtos = responses.OfType<TestResponse>().Select(r => r.GetValue());
            var anotherDtos = responses.OfType<AnotherResponse>().Select(r => r.GetValue());
            var thirdDtos = responses.OfType<ThirdResponse>().Select(r => r.GetValue());

            Console.WriteLine();
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }

        private static void ProcessTestResponses(IEnumerable<TestResponse> responses)
        {
            responses.Select(r => r.GetValue())
                .ForEach(dto => Console.WriteLine($"Id: {dto.Id}, Name: {dto.Name}"));
        }

        private static void ProcessAnotherResponses(IEnumerable<AnotherResponse> responses)
        {
            responses.Select(r => r.GetValue())
                .ForEach(dto => Console.WriteLine($"Code: {dto.Code}, Active: {dto.IsActive}, Quantity: {dto.Quantity:0.00}"));
        }

        private static void ProcessThirdResponses(IEnumerable<ThirdResponse> responses)
        {
            responses.Select(r => r.GetValue())
                .ForEach(dto => Console.WriteLine($"Number: {dto.Number}"));
        }


    }
}
