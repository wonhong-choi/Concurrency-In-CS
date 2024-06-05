using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Examples
{
    public class WaitingAll : ITaskRunnable
    {
        public async Task Run()
        {
            Task task1 = Task.Delay(TimeSpan.FromSeconds(1));
            Task task2 = Task.Delay(TimeSpan.FromSeconds(2));
            Task task3 = Task.Delay(TimeSpan.FromSeconds(3));
            await Task.WhenAll(task1, task2, task3);

            
            Task<int> task4 = Task.FromResult(4);
            Task<int> task5 = Task.FromResult(5);
            Task<int> task6 = Task.FromResult(6);
            var result = await Task.WhenAll(task4, task5, task6);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
