using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Examples
{
    public class WaitingAny : ITaskRunnable
    {
        public async Task Run()
        {
            string[] urls =
            {
                "http://www.naver.com",
                "http://www.google.com",
            };
         
            await FirstRespondingUrlAsync(urls);
        }

        private async Task FirstRespondingUrlAsync(params string[] urls)
        {
            var httpClient = new HttpClient();

            var tasks = new List<Task<byte[]>>();
            foreach (var url in urls)
            {
                tasks.Add(httpClient.GetByteArrayAsync(url));
            }

             Task<byte[]> firstFinishedTask = await Task.WhenAny(tasks.ToArray());

            var result = await firstFinishedTask;
            
            Console.WriteLine(result.Length);
        }
    }
}
