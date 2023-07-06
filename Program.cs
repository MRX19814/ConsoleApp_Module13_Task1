using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;

class Program
{
    static void Main()
    {
        // URL для считывания текста
        string url = "https://apps.skillfactory.ru/learning/course/course-v1:SkillFactory+CDEV+2021/block-v1:SkillFactory+CDEV+2021+type@sequential+block@df2806a9355e44c7be22a5dd8cd48818/block-v1:SkillFactory+CDEV+2021+type@vertical+block@29a2e1d179ac440a85e084c5dbf585a4";

        // Считывание текста из URL
        WebClient webClient = new WebClient();
        string text = webClient.DownloadString(url);
        List<string> lines = text.Split('\n').ToList();

        // Измерение производительности вставки в List<T>
        Stopwatch listInsertionStopwatch = Stopwatch.StartNew();
        List<string> list = new List<string>();
        foreach (string line in lines)
        {
            list.Add(line);
        }
        listInsertionStopwatch.Stop();

        // Измерение производительности вставки в LinkedList<T>
        Stopwatch linkedListInsertionStopwatch = Stopwatch.StartNew();
        LinkedList<string> linkedList = new LinkedList<string>();
        foreach (string line in lines)
        {
            linkedList.AddLast(line);
        }
        linkedListInsertionStopwatch.Stop();

        // Вывод результатов
        Console.WriteLine("Результаты сравнения производительности вставки:");
        Console.WriteLine($"Вставка в List<T>: {listInsertionStopwatch.Elapsed}");
        Console.WriteLine($"Вставка в LinkedList<T>: {linkedListInsertionStopwatch.Elapsed}");
    }
}
