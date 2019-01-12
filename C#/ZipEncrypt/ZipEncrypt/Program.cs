using System;
using System.IO;

namespace ZipEncrypt
{
    internal class Program
    {
        public static void printError(string msg)
        {
            Console.WriteLine("error: " + msg);
        }

        public static void closeProgram()
        {
            Console.WriteLine("Enter any key to continue......");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private static void Main(string[] args)
        {
            string text = "";
            string[] passwords={};
            try
            {
                Console.Write("Enter the name of the file to encrypt: ");
                var textFileName = Console.ReadLine();
                try
                {
                    text = File.ReadAllText(textFileName);
                }
                catch (Exception e)
                {
                    printError(textFileName + " do not exits, program exiting");
                    closeProgram();
                }
                Console.WriteLine(text);
                Console.Write("Enter the name of the password file: ");
                var passFileName = Console.ReadLine();
                try
                {
                    passwords = File.ReadAllLines(passFileName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    printError(passFileName + " do not exits, program exiting");
                    closeProgram();
                }
                Console.WriteLine(passwords.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            //            using (ZipFile zip = new ZipFile())
            //            {
            //                zip.Password = "456";
            //                zip.AddFile("1.zip");
            //                zip.Save("2.zip");
            //            }
            closeProgram();
        }
    }
}