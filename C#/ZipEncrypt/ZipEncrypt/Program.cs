using System;
using System.IO;
using Ionic.Zip;

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
            string[] passwords = {};
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
                for (int i = passwords.Length - 1; i >= 0; i--)
                {
                    string fileName = "";
                    if (i == passwords.Length - 1)
                    {
                        fileName = textFileName;
                    }
                    else
                    {
                        fileName = i + 2 + ".zip";
                    }

                    using (ZipFile zip = new ZipFile())
                    {
                        zip.Password = passwords[i];
                        zip.AddFile(fileName);
                        zip.Save(i + 1 + ".zip");
                    }
                }
            }
            catch (Exception e)
            {
                printError("in zipping the file");
                Console.WriteLine(e);
                closeProgram();
            }


            closeProgram();
        }
    }
}