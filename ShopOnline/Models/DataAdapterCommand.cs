namespace ShopOnline.Models;

public class DataAdapterCommand
{
    public SqlDataAdapter dataAdapter { get; set; }

    public DataAdapterCommand(SqlDataAdapter dataAdapter)
    {
        this.dataAdapter = dataAdapter;
    }

    private void InsertCommandParametersAdd()
    {
        dataAdapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id")
            .Direction = ParameterDirection.Output;
        dataAdapter.InsertCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 100, "LastName");
        dataAdapter.InsertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 30, "FirstName");
        dataAdapter.InsertCommand.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 30, "MiddleName");
        dataAdapter.InsertCommand.Parameters.Add("@Phone", SqlDbType.NVarChar, 10, "Phone");
        dataAdapter.InsertCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 30, "Email");
    }

    private void UpdateCommandParametersAdd()
    {
        dataAdapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id")
            .SourceVersion = DataRowVersion.Original;
        dataAdapter.UpdateCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 100, "LastName");
        dataAdapter.UpdateCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 30, "FirstName");
        dataAdapter.UpdateCommand.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 30, "MiddleName");
        dataAdapter.UpdateCommand.Parameters.Add("@Phone", SqlDbType.NVarChar, 10, "Phone");
        dataAdapter.UpdateCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 30, "Email");
    }

    private void DeleteCommandParametersAdd()
    {
        dataAdapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
    }

    public void Data(Params @params)
    {
        switch (@params)
        {
            case Params.Insert: InsertCommandParametersAdd(); break;
            case Params.Update: UpdateCommandParametersAdd(); break;
            case Params.Delete: DeleteCommandParametersAdd(); break;
            default: break;
        }
    }
}
