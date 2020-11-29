using System;
using System.IO;
using System.Text;

namespace WordReplace
{
    class Program
    {
        public static void Main(string[] args)
        {
            string cd = Directory.GetCurrentDirectory();
            Console.WriteLine(cd);
            if (args.Length > 0 && File.Exists(args[0]))
            {
                string replaceWord, replacedWord;
                Console.WriteLine("​Enter the text you want to replace.");
                replaceWord = Console.ReadLine();
                Console.WriteLine("​Enter the text after replacement.");
                replacedWord = Console.ReadLine();
                new Program().ReplaceWord(args, replaceWord, replacedWord);
            }
            else
            {
                Console.WriteLine("There is no valid file.");
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        public void ReplaceWord(string[] args, string bef, string aft)
        {
            try
            {
                string cd = Directory.GetCurrentDirectory();
                for (int i = 0; i < args.Length; i++)
                {
                    if (File.Exists(args[i]))
                    {
                        StreamReader sr = new StreamReader(@args[i]);
                        string s = sr.ReadToEnd();
                        sr.Close();
                        s = s.Replace(bef, aft);
                        StreamWriter sw = new StreamWriter(@args[i], false, Encoding.GetEncoding("utf-8"));
                        sw.Write(s);
                        sw.Close();
                    }
                    else
                    {
                        Console.WriteLine("File did not found: " + args[i]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}