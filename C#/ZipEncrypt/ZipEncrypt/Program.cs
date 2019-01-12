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
            try
            {
                Console.Write("Please enter the name of the password file: ");
                var passFileName = Console.ReadLine();
                if (!File.Exists(passFileName))
                {
                    printError(passFileName + " do not exits, program exiting");
                    closeProgram();
                }
                Console.Write("Please enter the name of the file to encrypt: ");
                var textFileName = Console.ReadLine();
                if (!File.Exists(textFileName))
                {
                    printError(textFileName + " do not exits, program exiting");
                    closeProgram();
                }
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
        }
    }
}