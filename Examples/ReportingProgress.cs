using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole.Examples
{
    public class ReportingProgress : ITaskRunnable
    {
        static async Task CallReportProgress()
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} th thread execute.");

            var progress = new Progress<double>();
            progress.ProgressChanged += (sender, e) =>
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} th thread execute progress.ProgressChanged.");
                Console.WriteLine($"{e}% progressd.");
            };

            await ReportProgressAsync(progress);

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} th thread execute after Report done.");
        }

        private static async Task ReportProgressAsync(IProgress<double> progress = null)
        {
            double percentComplete = 0;
            while (percentComplete < 100)
            {
                progress?.Report(percentComplete);
                percentComplete += 10;

                await Task.Delay(1000);
            }
        }

        public async Task Run()
        {
            await CallReportProgress();
        }
    }
}
