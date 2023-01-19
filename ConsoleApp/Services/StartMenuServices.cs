using ConsoleApp.Models;
using Newtonsoft.Json;

namespace ConsoleApp.Services;

internal class StartMenuServices
{   
    private List<Contact> contacts = new List<Contact>();  // A private field that is only accessable within this class || private List<Contact> contacts = new List<Contact>();
    private FileService file = new FileService();
  

    public string Path { get; set; } = null!;
    public void StartMenu()
    {
        file.Path = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json"; //3,52,.30 in , ifall dessa ska flyttas till Program.cs

        PopulateContactList();
        

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

    private void PopulateContactList()  
    {
        try
        {
            var items = JsonConvert.DeserializeObject<List<Contact>>(file.ReadContacts());
            if (items != null)
            {
                contacts = items;
            }
        }
        catch { }
    }
    private void SelectOne()  //Lägga till en kontakt
    {
        var contact = new Contact();

        Console.Clear();
        Console.WriteLine("SKAPA EN KONTAKT");
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
       file.SaveContact(JsonConvert.SerializeObject(contacts)); //file.SaveContact(Path, JsonConvert.SerializeObject(new { contacts }));
    }
    private void SelectTwo() //Visa alla kontakter
    {
        Console.Clear();
        Console.WriteLine("ALLA KONTAKTER");

        foreach (var contact in contacts) //Since it is a list foreach loop is needed
        {
            Console.WriteLine($"Förnamn: {contact.FirstName}, Efternamn: {contact.LastName}, Email: {contact.Email}");
        }

        Console.ReadKey();
    }

    private void SelectThree() //Visa specifik kontakt
    {
        Console.Clear();
        Console.WriteLine("VISA EN KONTAKT");
        Console.Write("Skriv in förnamnet på den kontakt du vill visa, börja med stor bokstav:");
        var searchName = Console.ReadLine();
        DisplayContact(searchName);
        Console.ReadKey();
    }

    public void DisplayContact(string? firstName)
    { 
        var contact = contacts.FirstOrDefault(c => c.FirstName == firstName);
        if (contact == null)
        {
            Console.WriteLine("Kunde inte hitta en kontakt med det namnet.");
        }
        else 
        {
            Console.WriteLine($"Förnamn: {contact.FirstName}");
            Console.WriteLine($"Efternamn: {contact.LastName}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Telefonnummer: {contact.Phone}");
            Console.WriteLine($"Adress: {contact.Address}");
        }
    }


    private void SelectFour() //Radera en specifik kontakt
    {
        Console.Clear();
        Console.WriteLine("TA BORT EN KONTAKT");
        Console.Write("Skriv in förnamnet följt av efternamnet på den person du vill ta bort, glöm inte att börja med stor bokstav:");
        Console.ReadLine();
        Console.ReadKey();
    }
}






//TEST:

//var contactlist = JsonConvert.DeserializeObject<List<Contact>>(file.ReadContacts(Path));
       // if (contactlist != null)
           // contacts = contactlist;
       // else
         //   contacts = new ();