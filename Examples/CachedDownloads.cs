using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Examples
{
    public class CachedDownloadsUsingFromResult : ITaskRunnable
    {
        static ConcurrentDictionary<string, string> cachedDownloads = new ConcurrentDictionary<string, string>();

        public static Task<string> DownloadStringAsync(string address)
        {
            string content = string.Empty;
            if (cachedDownloads.TryGetValue(address, out content))
            {
                return Task.FromResult(content);
            }
            return Task.Run(async () =>
            {
                content = await new WebClient().DownloadStringTaskAsync(address);
                cachedDownloads.TryAdd(address, content);
                return content;
            });
        }

        public async Task Run()
        {
            string[] urls = new string[]
            {
                "http://www.naver.com",
                "http://www.google.com",
            };
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            var downloads = from url in urls
                            select DownloadStringAsync(url);

            await Task.WhenAll(downloads).ContinueWith(results =>
            {
                stopwatch.Stop();
                Console.WriteLine($"{results.Result.Sum(result => result.Length)} char retrived.{stopwatch.ElapsedMilliseconds} Elapsed.");
            });

            stopwatch.Restart();
            downloads = from url in urls
                        select DownloadStringAsync(url);
            await Task.WhenAll(downloads).ContinueWith(results =>
            {
                stopwatch.Stop();
                Console.WriteLine($"{results.Result.Sum(result => result.Length)} char retrived.{stopwatch.ElapsedMilliseconds} Elapsed.");
            });
        }
    }
}
