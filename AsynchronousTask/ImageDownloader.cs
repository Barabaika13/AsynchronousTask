using System.Net;

namespace AsynchronousTask
{
    public class ImageDownloader
    {
        public event Action? ImageStarted;
        public event Action? ImageCompleted;

        public async Task DownloadAsync(string remoteUri, string fileName, CancellationToken token)
        {
            var myWebClient = new WebClient();
            Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n", fileName, remoteUri);
            ImageStarted?.Invoke();

            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Операция прервана");
                return;
            }

            await myWebClient.DownloadFileTaskAsync(remoteUri, fileName);
            Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUri);
            ImageCompleted?.Invoke();
        }
    }
}
