namespace ShopOnline.ViewModels;

public class FullTableModel
{
    SqlConnectionStringBuilder sqlConnectionStringBuilder;
    SqlConnection connection;
    DataTable dataTable;
    SqlDataAdapter adapter;
    DataGrid fullGridView;
    SQLCommands sqlCommands;

    public FullTableModel(DataGrid grid)
    {
        connection = new(SqlCon.ADOConnectionStringBulder(sqlConnectionStringBuilder).ConnectionString);
        dataTable = new();
        adapter = new();
        this.fullGridView = grid;
        sqlCommands = new();
    }

    public void FullTable()
    {
        adapter.SelectCommand = new SqlCommand(sqlCommands.Join2Tables(), connection);
        adapter.Fill(dataTable);
        fullGridView.DataContext = dataTable.DefaultView;
    }
}
