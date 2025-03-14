using Avalonia.Controls;

namespace FirstAppAvalonia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MyContent.Content = new Main();
        App.MainWindow = this;
    }
}