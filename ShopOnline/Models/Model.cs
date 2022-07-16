namespace ShopOnline.Models;

public class Model
{
    SqlConnectionStringBuilder sqlConnectionStringBuilder;
    SqlConnection connection;
    SQLCommands commands;

    SqlDataAdapter dataAdapter;
    DataRowView rowView;
    DataTable dataTable;
    DataRow dataRow;
    DataGrid dataGrid;

    DataAdapterCommand dataAdapterCommand;

    public Model(DataGrid dataGrid)
    {
        commands = new();
        dataTable = new();
        dataAdapter = new();
        dataAdapterCommand = new(dataAdapter);
        this.dataGrid = dataGrid;
    }

    public void MainSQL()
    {
        try
        {
            connection = new(SqlCon.ADOConnectionStringBulder(sqlConnectionStringBuilder).ConnectionString);

            dataAdapter.SelectCommand = new SqlCommand(commands.SelectSQL(), connection);
            dataAdapter.InsertCommand = new SqlCommand(commands.InsertSQL(), connection);
            dataAdapterCommand.Data(Params.Insert);


            dataAdapter.UpdateCommand = new SqlCommand(commands.UpdateSQL(), connection);
            dataAdapterCommand.Data(Params.Update);


            dataAdapter.DeleteCommand = new SqlCommand(commands.DeleteSQL(), connection);
            dataAdapterCommand.Data(Params.Delete);

            dataAdapter.Fill(dataTable);
            dataGrid.DataContext = dataTable.DefaultView;
        }

        catch (NullReferenceException)
        {
            Debug.WriteLine("Не удалось подкючиться к базе данных. Была допущена ошибка в Строке подключения");
        }
        catch (InvalidOperationException)
        {
            Debug.WriteLine("Невозможно в DataAdapter добавить и обновить строку у DataTable");
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
        }

    }

    public void CellEditEnding()
    {
        rowView = (DataRowView)dataGrid.SelectedItem;
        rowView.BeginEdit();
    }

    public void CurrentCellChanged()
    {
        if (rowView == null) return;
        rowView.EndEdit();
        DataAdapterUpdate();
    }

    private void DataAdapterUpdate()
    {
        try
        {
            dataAdapter.Update(dataTable);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
        }
    }

    public void MenuItemAdd(object s, RoutedEventArgs e)
    {
        dataRow = dataTable.NewRow();
        AddNewClientWindow addNewClientWindow = new(dataRow);
        addNewClientWindow.ShowDialog();

        if (addNewClientWindow.DialogResult.Value)
        {
            dataTable.Rows.Add(dataRow);
            DataAdapterUpdate();
        }
    }

    public void FullTable() => new FullTableWindow().ShowDialog();

    private void WarningMessage()
    {
        MessageBox.Show("Выберите, кого нужно удалить из списка!",
            "Ошибка",
            MessageBoxButton.OK,
            MessageBoxImage.Warning);
    }

    public void Remove()
    {
        try
        {
            rowView = (DataRowView)dataGrid.SelectedItem;
            rowView.Row.Delete();
            DataAdapterUpdate();
        }
        catch (Exception exception)
        {
            Debug.WriteLine($"Error MenuItemDeleteClick {exception}");
            WarningMessage();
        }
    }
}
