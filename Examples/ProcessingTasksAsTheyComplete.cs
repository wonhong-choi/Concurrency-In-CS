using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Examples
{
    public class ProcessingTasksAsTheyComplete : ITaskRunnable
    {
        private async Task ProcessTasksAsync()
        {
            Task<int> task1 = DelayAndReturnAsync(2);
            Task<int> task2 = DelayAndReturnAsync(3);
            Task<int> task3 = DelayAndReturnAsync(1);

            var tasks = new Task<int>[] { task1, task2, task3 };
            var processingTasks = tasks.Select(async task =>
            {
                var result = await task;
                Console.WriteLine(result);
            });

            await Task.WhenAll(processingTasks);
        }

        private async Task<int> DelayAndReturnAsync(int v)
        {
            await Task.Delay(TimeSpan.FromSeconds(v));
            return v;
        }


        public async Task Run()
        {
            await ProcessTasksAsync();

        }
    }
}
