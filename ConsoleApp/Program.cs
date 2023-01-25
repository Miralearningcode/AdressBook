using ConsoleApp.Services;
using System.ComponentModel.Design;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var startmenu = new StartMenuServices();
            startmenu.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";

      


            while(true)
            {   
                //console.clear?
                startmenu.StartMenu();
            }
            
        }
    }
}