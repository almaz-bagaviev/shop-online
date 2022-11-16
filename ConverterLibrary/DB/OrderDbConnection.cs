namespace ConverterLibrary.DB;

public class OrderDbConnection
{

    SqlConnectionStringBuilder sqlConnectionStringBuilder;
    SqlConnection sqlConnection;
    Order order;

    public TablesModel TablesModel { get; set; }

    public OrderDbConnection(IOrderConvert orderfile, string connectionString)
    {
        order = orderfile.GetOrder;

        sqlConnectionStringBuilder = new()
        {
            ConnectionString = connectionString
        };
        sqlConnection = new SqlConnection() { ConnectionString = sqlConnectionStringBuilder.ConnectionString };
        TablesModel = new(sqlConnectionStringBuilder, sqlConnection, order);

        try
        {
            sqlConnection.Open();
            TablesModel.TableApplication();
            TablesModel.ListOrders.Add(TablesModel.GetOrders());
        }
        catch (Exception e)
        {
            FileError.ExceptionInfo("SqlOpenError.txt", e.Message);
        }
        finally
        {
            sqlConnection.Close();
        }
    }
}