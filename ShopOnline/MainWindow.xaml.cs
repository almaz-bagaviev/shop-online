namespace ShopOnline;

public partial class MainWindow : Window
{
    Model model;
    
    public MainWindow()
    {
        InitializeComponent();
        model = new(mainDataGrid);
        model.MainSQL();
    }

    private void DataGrid_CurrentCellChanged(object sender, EventArgs e) => model.CurrentCellChanged();
    private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) => model.CellEditEnding();
    private void MenuItemAddClick(object sender, RoutedEventArgs e) => model.MenuItemAdd(sender, e);
    private void MenuItemRemoveClick(object sender, RoutedEventArgs e) => model.Remove();
    private void FullTable_Click(object sender, RoutedEventArgs e) => model.FullTable();
}
