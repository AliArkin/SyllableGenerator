using System;
using System.IO;
using System.Text;
using SyllableGenerator;

namespace TestSyllableGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating Syllable");
            Console.WriteLine("press any key to start...");
            Console.ReadKey();

            Generator gen = new Generator();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";

            //generate all syllable types && output to file
            foreach (var item in Enum.GetValues(typeof(SyllableType)))
            {
                Console.WriteLine("Generating Syllable type:");
                Console.WriteLine("\t-" + item);
                var result = gen.Generate((SyllableType)item);
                File.WriteAllLines(path + item.ToString() + ".txt", result.ToArray(), Encoding.UTF8);
            }

            Console.WriteLine("All type of syllable generated.");
            Console.WriteLine("You can find it in the path: ");
            Console.WriteLine("\t"+ path);
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }
    }
}
