using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Services
{
    internal class FileService
    {
        public string Path { get; set; } = null!;
        public void SaveContact(string content)  // Save a contact  public void SaveContact(string path, string content) 
        {
            using var sw = new StreamWriter(Path); //
            sw.WriteLine(content);
        }

        public string ReadContacts()  //Show all contacts (string path), is a constructor  
        {
            try
            {
                using var sr = new StreamReader(Path);
                return sr.ReadToEnd();
            }
            catch
            {
                return null!;
            }
        }
    }
}
