using System.Net;

namespace AsynchronousTask
{
    public class ImageDownloader
    {
        public event Action? ImageStarted;
        public event Action? ImageCompleted;

        public async Task DownloadAsync(string remoteUri, string fileName, CancellationToken ct)
        {
            using (WebClient myWebClient = new WebClient())
            {
                ct.Register(myWebClient.CancelAsync);

                Console.WriteLine($"Качаю \"{fileName}\" из \"{remoteUri}\" .......");
                ImageStarted?.Invoke();

                try
                {
                    await myWebClient.DownloadFileTaskAsync(remoteUri, fileName);
                }
                catch (WebException ex) when (ex.Status == WebExceptionStatus.RequestCanceled)
                {
                    // исключение, которое возникает при отмене скачивания
                    Console.WriteLine($"Файл {fileName} отменен");
                    throw new OperationCanceledException();
                }
                catch (AggregateException ex) when (ex.InnerException is WebException exWeb && exWeb.Status == WebExceptionStatus.RequestCanceled)
                {
                    throw new OperationCanceledException();
                }
                catch (TaskCanceledException)
                {
                    throw new OperationCanceledException();
                }                

                Console.WriteLine($"Успешно скачал \"{fileName}\" из \"{remoteUri}\"");
                ImageCompleted?.Invoke();
            }
        }
    }
}
