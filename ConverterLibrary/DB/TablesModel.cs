namespace ConverterLibrary.DB;

public class TablesModel
{
    public SqlConnectionStringBuilder ConnectionStringBuilder { get; set; }
    public SqlConnection Connection { get; set; }
    public Order GetOrder { get; set; }
    public List<Order> ListOrders { get; set; }
    int clientId;
    public TablesModel(SqlConnectionStringBuilder sqlConnectionStringBuilder,
                        SqlConnection sqlConnection,
                        Order order)
    {
        this.ConnectionStringBuilder = sqlConnectionStringBuilder;
        this.Connection = sqlConnection;
        this.GetOrder = order;
    }

    public void TableApplication()
    {
        CheckAvailabilityTables();
        InsertIntoClientTable();
        this.clientId = GetClientId();
        InsertIntoLocationTable();
        InsertIntoContactsTable();
        InsertIntoOrderTable();
        SelectAllLines();
    }

    private int GetClientId()
    {
        string s = GetOrder.LastName;
        Debug.WriteLine(s);

        string id = @"select Client.Id from Client
                        where Client.LastName=N'" + GetOrder.LastName + "'";
        SqlCommand idcmd = new SqlCommand(id, Connection);
        int number = int.Parse(idcmd.ExecuteScalar().ToString());
        Debug.WriteLine(number);
        return number;
    }

    private void CreateTable(Tables tables)
    {

        string createTable;
        if (tables == Tables.Client)
        {
            createTable = @"CREATE TABLE[dbo].[Client]
                                    (
                                        [Id] INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
                                        [LastName] NVARCHAR(50) NOT NULL,
                                        [FirstName] NVARCHAR(50) NOT NULL,
                                        [MiddleName] NVARCHAR(50) NULL
                                    )";
        }

        else if (tables == Tables.Contacts)
        {
            createTable = @"CREATE TABLE[dbo].[Contacts]
                                      (
        
                                        [Id] INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,      
                                        [Phone] NVARCHAR(20) NOT NULL,       
                                        [Email] NVARCHAR(100) NOT NULL,       
                                        [ClientId] INT NOT NULL
                                      )";
        }

        else if (tables == Tables.Location)
        {
            createTable = @"CREATE TABLE[dbo].[Location]
                                     (
        
                                        [Id] INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,      
                                        [Country] NVARCHAR(50) NOT NULL,       
                                        [City] NVARCHAR(50) NOT NULL,        
                                        [ClientId] INT NOT NULL
                                     )";
        }
        else
        {
            createTable = @"CREATE TABLE[dbo].[Order]
                                   (
                                        [Id] INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
                                        [Number] INT NOT NULL,
                                        [Date] DATETIME NOT NULL,
                                        [ClientId] INT NOT NULL,
                                        [Product] NVARCHAR(MAX) NOT NULL,
                                        [Count] DECIMAL(18, 2) NOT NULL
                                   )";
        }

        SqlCommand create = new SqlCommand(createTable, Connection);
        create.ExecuteNonQuery();
    }

    private string CheckTableValue(Tables tables)
    {
        string check = @"select s.id from sysobjects s where xtype='U' and s.name='" + tables + "'";
        Debug.WriteLine(check);
        return check;
    }

    private void CheckAvailabilityTables()
    {
        GetCheckAvailabilityTable(Tables.Client);
        GetCheckAvailabilityTable(Tables.Contacts);
        GetCheckAvailabilityTable(Tables.Location);
        GetCheckAvailabilityTable(Tables.Order);
    }

    private void GetCheckAvailabilityTable(Tables tables)
    {
        SqlCommand sqlCommand = new SqlCommand(CheckTableValue(tables), this.Connection);
        object idClient = sqlCommand.ExecuteScalar();
        if (idClient == null) CreateTable(tables);
    }


    private void InsertIntoClientTable()
    {
        string addToClientTable = @"insert into Client values(N'" + GetOrder.LastName + "', N'" + GetOrder.FirstName + "', N'" + GetOrder.MiddleName + "')";
        SqlCommand cmd = new SqlCommand(addToClientTable, this.Connection);
        cmd.ExecuteNonQuery();
        Debug.WriteLine("InsertIntoClientTable is Done");
    }

    private void InsertIntoLocationTable()
    {
        string addToLocationTable = @"insert into Location values(N'" + GetOrder.Country + "', N'" + GetOrder.City + "', " + this.clientId + ")";
        SqlCommand locationCmd = new SqlCommand(addToLocationTable, this.Connection);
        locationCmd.ExecuteNonQuery();
        Debug.WriteLine("InsertIntoLocationTable is Done");
    }

    private void InsertIntoContactsTable()
    {
        string addToContactsTable = @"insert into Contacts values('" + GetOrder.Phone + "', '" + GetOrder.Email + "', " + this.clientId + ")";
        SqlCommand contactsCmd = new SqlCommand(addToContactsTable, this.Connection);
        contactsCmd.ExecuteNonQuery();
        Debug.WriteLine("InsertIntoContactsTable is Done");
    }

    private void InsertIntoOrderTable()
    {
        string count = GetOrder.Count.ToString().Contains(',') ? GetOrder.Count.ToString().Replace(',', '.') : GetOrder.Count.ToString();
        string addToOrderTable = @"insert into [Order] values (" + GetOrder.NumberOfOrders +
            ", " + "'" + GetOrder.Date.ToString("yyyy-MM-dd HH:mm:ss") + "', "
            + this.clientId + ", N'" + GetOrder.Product + "', " + count + ")";
        SqlCommand orderCommand = new SqlCommand(addToOrderTable, this.Connection);
        orderCommand.ExecuteNonQuery();
    }

    private SqlDataReader SelectAllLines()
    {
        string allLines = @"select c.LastName, c.FirstName, c.MiddleName,
                                l.Country, l.City,
                                ct.Phone, ct.Email,
                                o.Number, o.[Date], o.Product, o.[Count]
                                from Client c
                                left join [Location] l on c.Id=l.ClientId
                                left join Contacts ct on c.Id=ct.ClientId
                                left join [Order] o on c.Id=o.ClientId
                                where c.LastName = N'" + GetOrder.LastName + "'";

        SqlCommand selectCmd = new SqlCommand(allLines, this.Connection);
        SqlDataReader reader = selectCmd.ExecuteReader();
        return reader;
    }

    public Order GetOrders()
    {
        SqlDataReader reader = SelectAllLines();
        Order order = new(reader[0].ToString(),
            reader[1].ToString(),
            reader[2].ToString(),
            reader[3].ToString(),
            reader[4].ToString(),
            reader[5].ToString(),
            reader[6].ToString(),
            reader.GetInt32(7),
            reader.GetDateTime(8),
            reader[9].ToString(),
            reader.GetDecimal(10));

        return order;
    }
}
