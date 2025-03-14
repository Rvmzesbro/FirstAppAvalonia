using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FirstAppAvalonia.Models;

namespace FirstAppAvalonia;

public partial class Main : UserControl
{
    public Main()
    {
        InitializeComponent();
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

        Clear();
        Agree.IsChecked = false;
        StatusBar.Text = "User saved";


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