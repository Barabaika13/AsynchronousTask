using System.Net;

namespace AsynchronousTask
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ImageDownloader imageDownloader = new ImageDownloader();
            NotificationService notificationService = new NotificationService();
            imageDownloader.ImageStarted += notificationService.OnFileDownloadStarted;
            imageDownloader.ImageCompleted += notificationService.OnFileDownloadCompleted;
           
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            var t1 = Task.Run(() => imageDownloader.DownloadAsync("https://images.hdqwalls.com/download/beautiful-yosemite-8k-r7-7680x4320.jpg", "bigimage1.jpg", token), token);
            var t2 = Task.Run(() => imageDownloader.DownloadAsync("https://images.hdqwalls.com/download/snow-covered-mountains-8k-sf-7680x4320.jpg", "bigimage2.jpg", token), token);
            var t3 = Task.Run(() => imageDownloader.DownloadAsync("https://images.hdqwalls.com/download/skye-united-kingdom-8k-yh-7680x4320.jpg", "bigimage3.jpg", token));
            var t4 = Task.Run(() => imageDownloader.DownloadAsync("https://images.hdqwalls.com/download/brooklyn-bridge-blue-sky-buildings-8k-5f-7680x4320.jpg", "bigimage4.jpg", token), token);
            var t5 = Task.Run(() => imageDownloader.DownloadAsync("https://images.hdqwalls.com/download/churei-tower-mount-fuji-in-japan-8k-68-7680x4320.jpg", "bigimage5.jpg", token), token);
            var t6 = Task.Run(() => imageDownloader.DownloadAsync("https://images.hdqwalls.com/download/bridge-sunset-8k-9x-7680x4320.jpg", "bigimage6.jpg", token), token);
            var t7 = Task.Run(() => imageDownloader.DownloadAsync("https://images.hdqwalls.com/download/sunflowes-field-8k-m3-7680x4320.jpg", "bigimage7.jpg", token), token);
            var t8 = Task.Run(() => imageDownloader.DownloadAsync("https://images.hdqwalls.com/download/switzerland-lake-landscape-mountains-10k-7p-7680x4320.jpg", "bigimage8.jpg", token), token);
            var t9 = Task.Run(() => imageDownloader.DownloadAsync("https://images.hdqwalls.com/download/mam-tor-castleton-united-kingdom-8k-0g-7680x4320.jpg", "bigimage9.jpg", token), token);
            var t10 = Task.Run(() => imageDownloader.DownloadAsync("https://images.hdqwalls.com/download/lake-tekapo-8k-uo-7680x4320.jpg", "bigimage10.jpg", token), token);


            Console.WriteLine("Нажмите клавишу A для остановки скачивания или любую другую клавишу для проверки статуса скачивания");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.A)
            {
                cancelTokenSource.Cancel();
                Console.WriteLine("ПРЕРВАНО");                
            }
            else
            {
                var tasks = new List<Task>() { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 };
                for (int i = 0; i < tasks.Count; i++)
                {
                    if (tasks[i].IsCompleted)
                    {
                        Console.WriteLine($"Файл bigimage{i + 1}.jpg загружен");
                    }
                    else
                    {
                        Console.WriteLine($"Файл bigimage{i + 1}.jpg не загружен");
                    }
                }
                await Task.WhenAll(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            }
            cancelTokenSource.Dispose();

            Console.ReadLine();
        }        
    }
}