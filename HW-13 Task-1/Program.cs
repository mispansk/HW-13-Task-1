using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace HW_13_Task_1 // заполняем элементами из текстового файла Llist 
{
    class Program
    {      
        // объявим список в виде статической переменной (простейший список List)
        public static List<string> List = new List<string>();
        static void Main(string[] args)
        {
            // читаем весь файл в строку текста
            string text = File.ReadAllText("C:\\Work\\skillFactori\\unit 13\\text1.txt");
            //Console.WriteLine(text.Length); // можно вывести длину(количество символов) и весь текст, для контроля
            //Console.WriteLine(text);
            //Console.WriteLine();

            // убираем из текста знаки пунктуации
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            //Console.WriteLine(noPunctuationText.Length); // можно вывести длину(количество символов) и текст после того, как убрали знаки пунктуации
            //Console.WriteLine(noPunctuationText);
            //Console.WriteLine();

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // выводим количество элементов
            Console.WriteLine($"Всего записано элементов: {words.Length}"); 
            
            var watchTwo = Stopwatch.StartNew();// засекаем время
            foreach (var i in words)
                List.Add(i); // добавляем элементы в List
            Console.WriteLine($"Вставка в List : {watchTwo.Elapsed.TotalMilliseconds}  мс");

            // для проверки можно посмотреть количество элементов (и сами элементы) записаных в List (лучше на маленьких примерах)
            //Console.WriteLine(List.Count);
            //foreach (var ii in List)
            //    Console.WriteLine(ii);
        }
    }
}
