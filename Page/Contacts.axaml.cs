using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FirstAppAvalonia.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using Npgsql;

namespace FirstAppAvalonia;

public partial class Contacts : UserControl
{
    public List<User> Users { get; set; }
    public User ContextUser { get; set; }

    public Contacts(User user)
    {
        InitializeComponent();
        Users = App.dbContext.Users.ToList();
        DataContext = this;
        ContextUser = user;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MyContent.Content = new Main();
    }

     private void TextBox_GotFocus(object? sender, Avalonia.Input.GotFocusEventArgs e)
     {
         if(Email.Text == "Enter your email")
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
     private void Clear()
     {
         Email.Clear();
         Password.Clear();
     }
     private void Button_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
     {
         var email = Email.Text;
         var password = Password.Text;
         if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || !email.Contains('@') || !email.Contains('.'))
         {
             StatusBar.Text = "All fields must be filled in";
             
             return;
         }
         else
         {
             using (var db = new PostgresContext())
             {
                 // string sql = "SELECT COUNT FROM users WHERE email = '" + email + "'AND password = '" + password + "'";
                 // NpgsqlCommand command = new NpgsqlCommand(sql);
                 // var result = command.ExecuteScalar();
                 // int i = Convert.ToInt32(result);
                 // if(i == 0)
                 
                 // if (db.Users.Any(x => x.Email == email))
                 
                 if (ContextUser.Id == 0)
                 {
                     User context = new User{Email = Email.Text, Password = Password.Text};
                     db.Users.Add(context);
                     App.MainWindow.MyContent.Content = new Main();
                 }
                 else
                 {
                     db.Entry(ContextUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                     App.MainWindow.MyContent.Content = new Main();
                 }
                 db.SaveChanges();
             }
             Clear();
             StatusBar.Text = "Saved";
         }
    }
}