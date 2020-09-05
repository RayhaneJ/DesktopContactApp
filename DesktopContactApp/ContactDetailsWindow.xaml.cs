using DesktopContactApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopContactApp
{
    /// <summary>
    /// Logique d'interaction pour ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact contact;

        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();

            this.contact = contact;

            nameTextBox.Text = contact.Name;
            emailTextBox.Text = contact.Email;
            phoneNumberTexBox.Text = contact.Phone;
        }

        private void UpdateButton_Clicked(object sender, RoutedEventArgs e)
        {
            contact.Name = nameTextBox.Text;
            contact.Email = emailTextBox.Text;
            phoneNumberTexBox.Text = phoneNumberTexBox.Text;

            using(SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.Update(contact);
            }

            Close();
        }

        private void DeleteButton_Clicked(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.Delete(contact);
            }

            Close();
        }
    }
}
