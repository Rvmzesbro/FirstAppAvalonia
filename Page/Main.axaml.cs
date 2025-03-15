using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FirstAppAvalonia.Models;
using FirstAppAvalonia.Page;

namespace FirstAppAvalonia;

public partial class Main : UserControl
{
    public User ContextUser { get; set; }
    public Main()
    {
        InitializeComponent();
        ContextUser = new User();
    }
    private void Clear()
    {
        Email.Clear();
        Password.Clear();

    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var email = Email.Text;
        var password = Password.Text;
        
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || Agree.IsChecked == false || !email.Contains('@') || !email.Contains('.'))
        {
            StatusBar.Text = "All fields must be filled in.";
            return;
        }
        else
        {
            using (var db = new PostgresContext())
            {
                ContextUser = db.Users.FirstOrDefault(p => p.Email == email);
                if (ContextUser != null)
                {
                    // Переход на страницу пользователя, который авторизовался
                    App.MainWindow.Content = new Authorized();
                }
                else
                {
                    StatusBar.Text = "The user is not registered";
                }
            }
        }

        Clear();
        Agree.IsChecked = false;
        


    }

    private void TextBox_GotFocus(object? sender, Avalonia.Input.GotFocusEventArgs e)
    {
        if (Email.Text == "Enter your email")
        {
            Email.Text = "";
        }
    }

    private void TextBox_LostFocus_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Email.Text))
        {
            Email.Text = "Enter your email";
        }
    }

    private void TextBox_GotFocus_1(object? sender, Avalonia.Input.GotFocusEventArgs e)
    {
        if (Password.Text == "Enter your password")
        {
            Password.Text = "";
            Password.PasswordChar = '●';
        }
    }

    private void TextBox_LostFocus_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Password.Text))
        {
            Password.Text = "Enter your password";
            Password.PasswordChar = '\0';
        }
    }

    private void Button_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MyContent.Content = new Contacts(new User());
    }
}