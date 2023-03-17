using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace P1PhoneJohan
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<Contact> _contacts;
        private Contact? _editContact = null;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _contacts = new List<Contact>();
            ReadDataFromFile();
            AddColorsToCombobox();
            ContactsListBox.ItemsSource = _contacts;
            RefreshContacts();
        }

        private void Window_Closed(object sender, CancelEventArgs e) {
            WriteDataToFile();
        }

        private void AddContact(string firstName, string lastName, string phoneNumber, Brush brush)
        {
            var contact = new Contact()
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Color = brush
            };
            if (_contacts.Contains(contact))
            {
                MessageBox.Show("Den här kontakten existerar redan!", "Fel");
            }
            else
            {
                _contacts.Add(contact);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string phoneNumber = PhoneNumberTextBox.Text;
            if(firstName == "" && lastName == "" && phoneNumber == "")
            {
                MessageBox.Show("Du måste fylla i alla fält!", "Fel");
            }
            else if(firstName == "")
            {
                MessageBox.Show("Du måste fylla i förnamnet!", "Fel");
            }
            else if(lastName == "")
            {
                MessageBox.Show("Du måste fylla i efternamnet!", "Fel");
            }
            else if(phoneNumber == "")
            {
                MessageBox.Show("Du måste fylla i telefonnumret!", "Fel");
            }
            else
            {
                if (_editContact == null)
                {
                    AddNewToContacts();
                }
                else
                {
                    UpdateCurrentContact();
                }
            }
        }

        private void AddNewToContacts()
        {
            var selectedItem = (ComboBoxItem)SelectColorComboBox.SelectedItem;
            AddContact(FirstNameTextBox.Text,
                LastNameTextBox.Text,
                PhoneNumberTextBox.Text,
                new SolidColorBrush(((SolidColorBrush)selectedItem.Background).Color));
            ContactsListBox.Items.Refresh();
            RefreshContacts();
            ClearTextBoxes();
        }

        private void UpdateCurrentContact()
        {
            var selectedItem = (ComboBoxItem)SelectColorComboBox.SelectedItem;
            var backgroundBrush = (SolidColorBrush)selectedItem.Background;
            _editContact.FirstName = FirstNameTextBox.Text;
            _editContact.LastName = LastNameTextBox.Text;
            _editContact.PhoneNumber = PhoneNumberTextBox.Text;
            _editContact.Color = new SolidColorBrush(backgroundBrush.Color);
            _editContact = null;
            ContactsListBox.Items.Refresh();
            RefreshContacts();
            ContactsListBox.SelectedIndex = -1;
            AddButton.Content = "Lägg till";
            ClearTextBoxes();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (_editContact != null)
            {
                _contacts.Remove(_editContact);
                ContactsListBox.Items.Refresh();
                RefreshContacts();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Finns ingen att radera. Markera en!", "Fel");
            }
        }

        private void Sorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshContacts();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshContacts();
        }
        private void ContactsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {       
            if (ContactsListBox.SelectedItem != null)
            {
               
                _editContact = (Contact)ContactsListBox.SelectedItem;
                var index = SelectColorComboBox.Items
                    .Cast<ComboBoxItem>()
                    .ToList()
                    .FindIndex(item => item.Background.ToString() == _editContact.Color.ToString());
                SelectColorComboBox.SelectedIndex = index;
                FirstNameTextBox.Text = _editContact.FirstName;
                LastNameTextBox.Text = _editContact.LastName;
                PhoneNumberTextBox.Text = _editContact.PhoneNumber; 
                AddButton.Content = "Ändra";
            }
        }

        private void RefreshContacts()
        {
            if (IsLoaded)
            {
                if (SortOrderComboBox.SelectedIndex == 0)
                {
                    ContactsListBox.ItemsSource = _contacts.Where(FilterContact).OrderBy(OrderParameter);
                }
                else
                {
                    ContactsListBox.ItemsSource = _contacts.Where(FilterContact).OrderByDescending(OrderParameter);
                }
            }
        }

        private bool FilterContact(Contact contact)
        {
            string searchText = SearchTextBox.Text.ToLower().ToString();
            return contact.FirstName.ToLower().Contains(searchText) || contact.LastName.ToLower().Contains(searchText) || contact.PhoneNumber.ToLower().Contains(searchText);
        }

        private object OrderParameter(Contact contact)
        {
            int option = SortItemComboBox.SelectedIndex;
            if(option == 0) {
                return contact.FirstName;
            }
            else
            {
                return contact.LastName;
            }
        }
        private void ClearTextBoxes()
        {
            FirstNameTextBox.Clear();
            LastNameTextBox.Clear();
            PhoneNumberTextBox.Clear();
        }
        private void AddColorsToCombobox()
        {
            foreach (var color in typeof(Colors).GetProperties())
            {
                if (color.PropertyType == typeof(Color))
                {
                    var brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color.Name));
                    var item = new ComboBoxItem
                    {
                        Content = color.Name,
                        Background = brush,
                    };
                    SelectColorComboBox.Items.Add(item);
                }
            }
            SelectColorComboBox.SelectedIndex = 0;
        }

        private void ReadDataFromFile()
        {
            foreach (var line in File.ReadAllLines("../../../ContactList.txt"))
            {
                var values = line.Split(",");
                if (values.Length == 4)
                {
                    var firstName = values[0].ToString();
                    var lastName = values[1].ToString();
                    var phoneNumber = values[2].ToString();
                    var color = (Color)ColorConverter.ConvertFromString(values[3]);
                    var brush = new SolidColorBrush(color);
                    AddContact(firstName, lastName, phoneNumber, brush);
                }
            }
        }
        private void WriteDataToFile()
        {
            using (var writer = new StreamWriter("../../../ContactList.txt"))
            {
                foreach (var contact in _contacts)
                {
                    writer.Write(string.Format("{0},{1},{2},{3}", contact.FirstName, contact.LastName, contact.PhoneNumber, contact.Color));
                    writer.WriteLine();
                }
            }
        }
    }
}
