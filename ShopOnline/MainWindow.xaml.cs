using System.Windows;
using ShopOnline.Models;

namespace ShopOnline;

public partial class MainWindow : Window
{
    ViewModel model;

    public MainWindow()
    {
        InitializeComponent();

        model = new();
        OrdersListBox.ItemsSource = model.Orders;
    }
}
