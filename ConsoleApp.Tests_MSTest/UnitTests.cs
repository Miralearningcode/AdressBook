using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsoleApp.Tests_MSTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Should_Add_Contact_To_List()
        {
            //arrange
            StartMenuServices startMenuServices = new StartMenuServices();
            Contact contact= new Contact();
            StartMenuServices.ContactList = new List<Contact>();

            //act
            StartMenuServices.ContactList.Add(contact);

            //assert

            Assert.AreEqual(1, StartMenuServices.ContactList.Count);
        }
    }
}