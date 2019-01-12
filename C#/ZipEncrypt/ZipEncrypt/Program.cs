using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipEncrypt
{
    class Program
    {
        static void Main(string[] args)
        {   using (ZipFile zip = new ZipFile())
            {
                zip.Password = "456";
                zip.AddFile("1.zip");
                zip.Save("2.zip");
            }
        }
    }
}
