using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenPop.Mime;
using OpenPop.Pop3;
using S22.Imap;

namespace SsdFetcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string 
                hostname = "imap.gmail.com",
                username = "***@gmail.com", 
                password = "***",
                from = "***";
            
            List<Earthquake> quakes = EmailFetcher.Fetch(hostname, 993, username, password, from);
            foreach (var quake in quakes)
            {
                Console.WriteLine(quake);
            }
        }
    }
}
