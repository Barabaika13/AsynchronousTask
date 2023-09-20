namespace AsynchronousTask
{
    public class NotificationService
    {
        public static void OnFileDownloadStarted()
        {
            Console.WriteLine($"Скачивание файла началось\n");
        }

        public static void OnFileDownloadCompleted()
        {
            Console.WriteLine($"Скачивание файла закончилось\n");
        }
    }
}
