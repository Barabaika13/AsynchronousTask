namespace AsynchronousTask
{
    public class NotificationService
    {
        public void OnFileDownloadStarted()
        {
            Console.WriteLine("Скачивание файла началось");
        }

        public void OnFileDownloadCompleted()
        {
            Console.WriteLine("Скачивание файла закончилось");
        }
    }
}
