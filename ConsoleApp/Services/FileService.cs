using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class FileService
    {
        public string Path { get; set; } = null!; //Behövs denna?
        public void SaveContact(string path, string content)  // Save a contact  public void SaveContact(string path, string content) 
        {
            using var sw = new StreamWriter (path); //
            sw.WriteLine(content);
        }

        public string ReadContacts(string path)  //Show all contacts (string path)
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

        

        //public void/string SpecificContact (string path) //Show a specific contact
        //{ 

        //}

        //public void/string DeleteContact()   //Delete a contact
        //{

        //}
    }
}
