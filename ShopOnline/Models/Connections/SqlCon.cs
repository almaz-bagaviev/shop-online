namespace ShopOnline.Models.Connections;

public static class SqlCon
{
    public static SqlConnectionStringBuilder ADOConnectionStringBulder(SqlConnectionStringBuilder sql)
    {
        try
        {
            sql = new()
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = "Your AttachDBFilename", //You need to specify the AttachDBFilename of Db yourself
                IntegratedSecurity = true
            };
        }
        catch (FileNotFoundException e)
        {
            Debug.WriteLine(e);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
        }

        return sql;
    }
}
