using System.Net;

namespace AsynchronousTask
{
    public class ImageDownloader
    {
        public event Action? ImageStarted;
        public event Action? ImageCompleted;

        public async Task DownloadAsync(string remoteUri, string fileName, CancellationToken ct)
        {
            var myWebClient = new WebClient();
            Console.WriteLine($"Качаю \"{fileName}\" из \"{remoteUri}\" .......\n");
            ImageStarted?.Invoke();
            await myWebClient.DownloadFileTaskAsync(remoteUri, fileName);
            if (ct.IsCancellationRequested)
            {
                Console.WriteLine($"Файл {fileName} отменен");
                ct.ThrowIfCancellationRequested();
            }
            Console.WriteLine($"Успешно скачал \"{fileName}\" из \"{remoteUri}\"");
            ImageCompleted?.Invoke();
        }
    }
}
