using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class FileService
    {
        public string FilePath { get; set; } = null!; 
        public void SaveContact(string content)  
        {
            using var sw = new StreamWriter (FilePath); 
            sw.WriteLine(content);
        }

        public string ReadContacts()  
        {
            try
            {
                using var sr = new StreamReader(FilePath);  
                return sr.ReadToEnd();
            }
            catch
            {
                return null!;
            }
        }

        

        //public void/string SpecificContact (string path) //Show a specific contact
        //{ 

        //}

        // public void Delete (string path)   //Delete a contact
        //{

        //}
    }
}
