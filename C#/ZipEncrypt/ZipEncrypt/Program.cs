using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipEncrypt
{
    class Program
    {
        public static void printError(string msg)
        {
            Console.WriteLine("error: " + msg);
        }

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Please enter the name of the password file: ");
                string passFileName = Console.ReadLine();
                if (!File.Exists(passFileName))
                {
                    printError(passFileName + " do not exits, program exiting");
                }
                Console.Write("Please enter the name of the file to encrypt: ");
                string textFileName = Console.ReadLine();
                if (!File.Exists(passFileName))
                {
                    printError(textFileName + " do not exits, program exiting");
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