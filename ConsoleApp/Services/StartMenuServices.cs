using ConsoleApp.Models;
using Newtonsoft.Json;

namespace ConsoleApp.Services;

internal class StartMenuServices
{   
    private List<Contact> contacts = new List<Contact>();  // A private field that is only accessable within this class
    private FileService file = new FileService();

    public string Path { get; set; } = null!;
    public void StartMenu()
    {
        Console.Clear();
        Console.WriteLine("Välkommen till Adressboken");
        Console.WriteLine("1.Skapa en kontakt");
        Console.WriteLine("2.Visa alla kontakter");
        Console.WriteLine("3.Visa en specifik kontakt");
        Console.WriteLine("4.Ta bort en specifik kontakt");
        Console.Write("Välj ett av alternativen ovan:");
        var select = Console.ReadLine();

        switch (select)
        {
            case "1":
                SelectOne();
                break;
            case "2":
                SelectTwo();
                break;
            case "3":
                SelectThree();
                break;
            case "4":
                SelectFour();
                break;
        }
    }
    private void SelectOne()  
    {
        var contact = new Contact();

        Console.Clear();
        Console.WriteLine("Skapa en kontakt");
        Console.Write("Skriv in förnamn:");
        contact.FirstName = Console.ReadLine() ?? "";
        Console.Write("Skriv in efternamn:");
        contact.LastName = Console.ReadLine() ?? "";
        Console.Write("Skriv in email:");
        contact.Email = Console.ReadLine() ?? "";
        Console.Write("Skriv in telefonnummer:");
        contact.Phone = Console.ReadLine() ?? "";
        Console.Write("Skriv in adress:");
        contact.Address = Console.ReadLine() ?? "";
        Console.WriteLine("Kontakten är nu sparad, tryck på valfri tangent för att komma tillbaka till huvudmenyn");
        Console.ReadKey();

       contacts.Add(contact);
       file.SaveContact(Path, JsonConvert.SerializeObject(new { contacts }));
    }
    private void SelectTwo()
    {
        Console.Clear();    
    }
    private void SelectThree()
    {
        Console.Clear();
    }
    private void SelectFour()
    {
        Console.Clear();
    }
}
