﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class FileService
    {
        public string Path { get; set; } = null!; 
        public void SaveContact(string content)  // Save a contact  public void SaveContact(string path, string content) 
        {
            using var sw = new StreamWriter (Path); //
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

        

        //public void/string SpecificContact (string path) //Show a specific contact
        //{ 

        //}

        //public void/string DeleteContact()   //Delete a contact
        //{

        //}
    }
}
