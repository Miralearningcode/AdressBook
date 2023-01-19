using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Models;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>();
        private readonly FileService file = new();

        public MainWindow()
        {
            InitializeComponent(); //Måste köras först, inget får ligga ovanför
            file.Path = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contentWpf.json";

            PopulateContactList();
        }

        private void PopulateContactList()
        {
            try
            {
                var items = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(file.ReadContacts());
                if (items != null)
                    contacts = items;
            } 
            catch { }

            lv_Contacts.ItemsSource = contacts;  
        }

        private void Btn_AddContact_Click(object sender, RoutedEventArgs e)
        {
            contacts.Add(new ContactModel
            {
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Email = tb_Email.Text,
                Phone = tb_Phone.Text,
                Address= tb_Address.Text
            });

            file.SaveContact(JsonConvert.SerializeObject(contacts));
            ClearForm();
        }

        private void ClearForm()
        {
            tb_FirstName.Text = "";
            tb_LastName.Text = "";
            tb_Email.Text = "";
            tb_Phone.Text = "";
            tb_Address.Text = "";
        }
    }
}
