using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace KundRegister
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Customer _customer;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _customer;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //Get the customer and display it in search window
            var searchText = SearchBox.Text;
            Customer selectedCustomer = SearchDatabase(searchText);
            Window mySearchWindow = new SearchResult(selectedCustomer);
            mySearchWindow.ShowDialog();
        }

        private Customer SearchDatabase(string searchText)
        {
            if (rbPhone.IsChecked == true && !string.IsNullOrEmpty(searchText))
            {
                using (var db = new CustomerContext())
                {
                    _customer = db.Customers.FirstOrDefault(x => x.PhoneNumber == searchText);
                    if (_customer != null)
                        return _customer;
                }
            }
            else if (rbEmail.IsChecked == true && !string.IsNullOrEmpty(searchText))
            {
                using (var db = new CustomerContext())
                {
                    _customer = db.Customers.FirstOrDefault(x => x.Email == searchText);
                    if (_customer != null)
                        return _customer;
                }
            }
            return null;
        }

        //Saves the customer to the database
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PhoneTextBox.Text) && string.IsNullOrEmpty(EmailTextBox.Text))
            {
                PhoneInvalid.Content = "You must input a phone number";
                EmailInvalid.Content = "You must input a email";
            }
            else if (string.IsNullOrEmpty(PhoneTextBox.Text))
                PhoneInvalid.Content = "You must input a phone number";
            else if (string.IsNullOrEmpty(EmailTextBox.Text))
                EmailInvalid.Content = "You must input a email";
            else
            {
                SaveCustomer();
                Success.Content = "Successfully registered!";
            }
        }

        //Makes sure the right values are set before saving to database
        private void SaveCustomer()
        {
            bool companySelected = rbPrivate.IsChecked != true;
            bool wantsNewsLetter = NewsLetterCheckBox.IsChecked == true;

            _customer = new Customer(companySelected, FirstNameTextBox.Text, LastNameTextBox.Text, 
                BirthdatePicker.DisplayDate, StreetNameTextBox.Text, ZipCodeTextBox.Text, CityTextBox.Text,
                PhoneTextBox.Text, EmailTextBox.Text, wantsNewsLetter, NotesTextBox.Text, CompanyNameTextBox.Text);

            DatabaseSaving(_customer);
        }

        private void DatabaseSaving(Customer customer)
        {
            using (var db = new CustomerContext())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }

        #region UICheckboxes
        private void rbPrivate_Checked(object sender, RoutedEventArgs e)
        {
            CompanyNameTextBox.IsEnabled = false;
        }

        private void RbCompany_Checked(object sender, RoutedEventArgs e)
        {
            CompanyNameTextBox.IsEnabled = true;
        }
#endregion
    }
}
