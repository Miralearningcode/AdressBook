namespace ConsoleApp.Models;

internal class Contact
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int PhoneNumber { get; set; } = 0;
    public string Address { get; set; } = null!;
}
