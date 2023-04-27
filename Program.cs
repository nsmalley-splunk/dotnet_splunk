using System;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_splunk
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var random = new Random();
            var cancellationTokenSource = new CancellationTokenSource();
            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                eventArgs.Cancel = true;
                cancellationTokenSource.Cancel();
            };

            while (!cancellationTokenSource.IsCancellationRequested)
            {
                try
                {
                    LogEvent("Application starting");

                    // Simulate random performance counters
                    int cpuUsage = random.Next(0, 100);
                    int memoryUsage = random.Next(50, 200);
                    int diskSpace = random.Next(100, 500);
                    int transactions = random.Next(1, 100);

                    LogEvent($"CPU Usage: {cpuUsage}%");
                    LogEvent($"Memory Usage: {memoryUsage} MB");
                    LogEvent($"Disk Space: {diskSpace} GB");
                    LogEvent($"Transactions: {transactions}");

                    LogEvent("Application stopping");

                    // Wait for a random time interval between 5 and 15 seconds before restarting
                    int delay = random.Next(5000, 15000);
                    await Task.Delay(delay, cancellationTokenSource.Token);
                }
                catch (TaskCanceledException)
                {
                    // The application was interrupted by the user, exit gracefully
                    LogEvent("Application interrupted");
                    break;
                }
                catch (Exception ex)
                {
                    // Log any exceptions and continue
                    LogEvent($"Error: {ex.Message}");
                }
            }

            LogEvent("Application exiting");
        }

        private static void LogEvent(string message)
        {
            string timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            Console.WriteLine($"{timestamp} - {message}");
        }
    }
}

