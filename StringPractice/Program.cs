using System;
using System.Text;
using System.Threading;

ThreadSafeLogger logger = new ThreadSafeLogger();

Thread[] threads = new Thread[5];

for (int i = 0; i < threads.Length; i++)
{
    int threadId = i + 1;

    threads[i] = new Thread(() =>
    {
        for (int j = 1; j <= 1000; j++)
        {
            logger.Log($"Поток {threadId}: сообщение {j}");
        }
    });

    threads[i].Start();
}

foreach (Thread thread in threads)
{
    thread.Join();
}

string result = logger.GetLog();

Console.WriteLine(result);
Console.WriteLine($"Всего сообщений: {logger.Count}");

class ThreadSafeLogger
{
    private readonly StringBuilder sb = new StringBuilder();
    private readonly object locker = new object();
    private int count = 0;

    public void Log(string message)
    {
        lock (locker)
        {
            sb.AppendLine(message);
            count++;
        }
    }
    public void LogUnsafe(string message)
    {
        sb.AppendLine(message);
        count++;
    }
    public string GetLog()
    {
        lock (locker)
        {
            return sb.ToString();
        }
    }

    public int Count
    {
        get
        {
            lock (locker)
            {
                return count;
            }
        }
    }
}