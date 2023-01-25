using ConsoleApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp.Services;

internal class StartMenuServices
{
    private List<Contact> contacts = new List<Contact>();  
    private FileService file = new FileService();


    public string FilePath { get; set; } = null!;
    public void StartMenu()
    {
        file.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json"; 

        PopulateContactList();


        Console.Clear();
        Console.WriteLine("VÄLKOMMEN TILL ADRESSBOKEN");
        Console.WriteLine();
        Console.WriteLine("1.Skapa en kontakt");
        Console.WriteLine("2.Visa alla kontakter");
        Console.WriteLine("3.Visa en specifik kontakt");
        Console.WriteLine("4.Ta bort en specifik kontakt");
        Console.WriteLine();
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
    private void SelectOne()  //Add a new contact
    {
        var contact = new Contact();

        Console.Clear();
        Console.WriteLine("SKAPA EN KONTAKT");
        Console.WriteLine();
        Console.Write("Skriv in förnamn, börja med stor bokstav:");
        contact.FirstName = Console.ReadLine() ?? "";
        Console.Write("Skriv in efternamn, börja med stor bokstav:");
        contact.LastName = Console.ReadLine() ?? "";
        Console.Write("Skriv in email:");
        contact.Email = Console.ReadLine() ?? "";
        Console.Write("Skriv in telefonnummer:");
        contact.Phone = Console.ReadLine() ?? "";
        Console.Write("Skriv in adress:");
        contact.Address = Console.ReadLine() ?? "";
        Console.WriteLine();
        Console.WriteLine("Kontakten är nu sparad, tryck på valfri tangent för att komma tillbaka till huvudmenyn");
        Console.ReadKey();

        contacts.Add(contact);
        file.SaveContact(JsonConvert.SerializeObject(contacts)); 
    }
    private void SelectTwo() //Show all contacts
    {
        Console.Clear();
        Console.WriteLine("ALLA KONTAKTER");
        Console.WriteLine();

        foreach (var contact in contacts) 
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}>");
        }

        Console.WriteLine();
        Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn");
        Console.ReadKey();
    }

    private void SelectThree() //Show a contact
    {
        Console.Clear();
        Console.WriteLine("VISA EN KONTAKT");
        Console.WriteLine();
        Console.Write("Skriv in förnamnet på den kontakt du vill visa, börja med stor bokstav:");
        var inputName = Console.ReadLine();
        DisplayContact(inputName);
        Console.WriteLine();
        Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn");
        Console.ReadKey();
    }

    public void DisplayContact(string? firstName)
    {
        var findContact = contacts.FirstOrDefault(c => c.FirstName == firstName);
        if (findContact == null)
        {
            Console.WriteLine("Kunde inte hitta en kontakt med det namnet.");
        }
        else
        {
            Console.WriteLine($"Förnamn: {findContact.FirstName}");
            Console.WriteLine($"Efternamn: {findContact.LastName}");
            Console.WriteLine($"Email: {findContact.Email}");
            Console.WriteLine($"Telefonnummer: {findContact.Phone}");
            Console.WriteLine($"Adress: {findContact.Address}");
        }
    }

    private void SelectFour() //Remove a contact
    {

        Console.Clear();
        Console.WriteLine("TA BORT EN KONTAKT");
        Console.WriteLine();
        Console.Write("Skriv in förnamnet på den person du vill ta bort, glöm inte att börja med stor bokstav:");
        var inputContact = Console.ReadLine() ?? null!; // ?? null!;
        DisplayContact(inputContact);
        Console.WriteLine();

        var findContact = contacts.FirstOrDefault(c => c.FirstName == inputContact);
        bool selected = false; //START
        while (!selected)
        {
            Console.WriteLine("Är du säker på att du vill ta bort kontakten? Skriv in [j] för ja, skriv in [n] så kommer du tillbaka till huvudmenyn");
            var key = Console.ReadLine();

            if (key == "j")
            {
                selected = true;
                contacts.Remove(findContact);
                file.SaveContact(JsonConvert.SerializeObject(contacts));

                Console.WriteLine("Kontakten är nu raderad, tryck på valfri tangent för att komma tillbaka till huvudmenyn");
                Console.ReadKey();
            }
            else if (key == "n")
            {
                selected = true;
            }



            // bool selected = false; //START
            //while (!selected)
            //{
            //Console.WriteLine("Är du säker på att du vill ta bort kontakten? Skriv in [y] för ja, skriv in [n] så kommer du tillbaka till huvudmenyn");
            //var key = Console.ReadLine();

            //if (key == "y")
            //{
            //selected = true;
            //contacts.Remove(inputContact);
            //file.SaveContact(JsonConvert.SerializeObject(contacts));

            //Console.WriteLine("Kontakten är nu raderad, tryck på valfri tangent för att komma tillbaka till huvudmenyn");
            //Console.ReadKey();
            //}
            //else if (key == "n")
            //{
            // selected = true;
            //}
        }
    }
}

    
