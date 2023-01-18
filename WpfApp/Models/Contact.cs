namespace WpfApp.Models;

internal interface IContact
{
    string FirstName { get; set; }
    string LastName { get; set; } 
    string Email { get; set; } 
    string Phone { get; set; } 
    string Address { get; set; }
}

internal class Contact : IContact
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;


    public string DisplayName => $"{FirstName} {LastName}";
}