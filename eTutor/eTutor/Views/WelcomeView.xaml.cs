using eTutor.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace eTutor.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomeView : Page
    {
        public WelcomeView()
        {
            this.InitializeComponent();
        }
        String _username, _password, _mail, _paypal, _type;

        private void sign_in_Click(object sender, RoutedEventArgs e)
        {
            welcome_panel.Visibility = Visibility.Collapsed;
            sign_in_panel.Visibility = Visibility.Visible;
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            welcome_panel.Visibility = Visibility.Collapsed;
            register_panel.Visibility = Visibility.Visible;
            img.Visibility = Visibility.Collapsed;
        }

        private void sign_in_proceed_Click(object sender, RoutedEventArgs e)
        {
            _username = username.Text;
            _password = password.Password;
            if (new WelcomeViewModel().FindUser(_username, _password))
            {
                this.Frame.Navigate(typeof(Views.NavPaneHomeView));
            }
            else invalid_combo.Visibility = Visibility.Visible;
            //TODO: make else go back to sign up or register
        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            _type = rb.Content.ToString();
        }

        private void register_proceed_Click(object sender, RoutedEventArgs e)
        {
            _username = new_username.Text;
            _password = new_password.Password;
            _mail = new_e_mail.Text;
            _paypal = new_paypal_e_mail.Text;
            if(String.IsNullOrEmpty(_username) || String.IsNullOrEmpty(_password) || String.IsNullOrEmpty(_mail) || String.IsNullOrEmpty(_paypal) || String.IsNullOrEmpty(_type))
            {
                empty_field_alert.Visibility = Visibility.Visible;
            }
            else if(new WelcomeViewModel().FindByName(_username))
            {
                username_alert.Visibility = Visibility.Visible;
            }
            else if(!_password.Equals(confirm_password.Password))
            {
                username_alert.Text = "Password and confirm password fields don't match!";
                username_alert.Visibility = Visibility.Visible;
            }
            else
            {
                new WelcomeViewModel().addUser(new Models.User(_username, _mail, _password, _paypal, _type));
                this.Frame.Navigate(typeof(Views.NavPaneHomeView));
            }
        }
        //TODO: placeholder for textbox and check that every field is not empty and hide password

    }
}
