using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ExampleConsole_01
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //await AsyncMath();
            //await AsyncWriteBook();
            await AsyncAdd();

            Console.WriteLine("Очень жаль");
            
            Console.ReadLine();
        }

        static async Task<int> AsyncAdd()
        {
            int a = 12;
            int b = 13;
            int sum = await Task.Run(() => Add(a, b));
            //Console.WriteLine(sum);
            return sum;
        }

        static int Add(int a, int b)
        {
            Console.WriteLine("Start Add");
            Thread.Sleep(5000);
            Console.WriteLine("Finish Add");

            return a + b;
        }

        static async Task AsyncWriteBook()
        {
            string text = "Я жду комп уже который день, я ппц устал и просто хочу уже поиграть, ибо я ничего не понимаю и ничего не могу сделать, мне просто хочется отдохнуть.";
            await Task.Run(() => WriteBook(text));
            Console.WriteLine("Done");
        }

        static void WriteBook(string text)
        {
            Console.WriteLine("Start WriteBook");
            Thread.Sleep(5000);
            Console.WriteLine("Finish WriteBook");
            Console.WriteLine($"Text: {text}");
        }

        static async Task AsyncMath()
        {
            await Task.Run(Math);
            Console.WriteLine("Done");
        }

        static void Math()
        {
            Console.WriteLine("Start Math");
            Thread.Sleep(5000);
            Console.WriteLine("Finish Math");
        }
    }
}
