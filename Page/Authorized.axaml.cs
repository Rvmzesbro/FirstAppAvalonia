using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using FirstAppAvalonia.Models;

namespace FirstAppAvalonia.Page;

public partial class Authorized : UserControl
{
    public User ContextUser { get; set; }
    public Authorized()
    {
        InitializeComponent();
        
    }
    
}