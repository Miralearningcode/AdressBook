using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class FileService
    {
        public void SaveContact(string path, string content)
        {
            using var sw = new StreamWriter(path);
            sw.WriteLine(content);
        }

        public string ReadContact(string path)
        {
            try
            {
                using var sr = new StreamReader(path);  
                return sr.ReadToEnd();
            }
            catch
            {
                return null!;
            }
        }

        //public void DeleteContact() 
        //{

        //}
    }
}
