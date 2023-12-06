using Nest;
using System;
using System.Reflection.PortableExecutable;

namespace ElasticSearchProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // 테스트 케이스 작성
            SendLogService sendLogService = new SendLogService();

            // 로그 남기기
            //sendLogService.SendListLog(10);
            //sendLogService.SendDictLog(10);
            //sendLogService.SendArrayLog(10);
            sendLogService.SendClassLog(10);
            //sendLogService.SendNestedLog(10);

            ReceiveLog();
            Console.ReadLine();
        }

        static async void ReceiveLog()
        {
            LogService _LogService = new LogService();

            ISearchResponse<object> searchResponse = await _LogService.GetCustomLog();

            foreach (var document in searchResponse.Documents)
            {
                var log = document as Dictionary<string, object>;

                foreach (string key in log.Keys)
                {
                    Console.WriteLine(key);
                }

                Console.WriteLine(log["Kennen"]);
            }
        }
    }
}