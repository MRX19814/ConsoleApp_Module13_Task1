using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        // Чтение текстового файла
        string filePath = "C:\\Users\\kurga\\Desktop\\texrr.txt";
        List<string> lines = File.ReadAllLines(filePath).ToList();

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
