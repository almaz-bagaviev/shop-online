namespace ShopOnline.Models;

public class SQLCommands : ISQL
{
    public SQLCommands() { }

    public string SelectSQL()
    {
        string sql = "SELECT * FROM Clients";
        return sql;
    }

    public string InsertSQL()
    {
        string sql = @"INSERT INTO Clients VALUES (@LastName, @FirstName, @MiddleName, @Phone, @Email);
                         SET @Id=@@IDENTITY";
        return sql;
    }

    public string UpdateSQL()
    {
        string sql = @"UPDATE Clients SET
                                      LastName = @LastName,
                                      FirstName = @FirstName,
                                      MiddleName = @MiddleName,
                                      Phone = @Phone,
                                      Email = @Email
                                      WHERE Id = @Id";

        return sql;
    }

    public string DeleteSQL()
    {
        string sql = "DELETE FROM Clients WHERE Id = @Id";
        return sql;
    }
    public string Join2Tables()
    {
        string sql = @"SELECT Clients.Id, Clients.LastName, Clients.FirstName,
                              Clients.MiddleName, Clients.Phone, Clients.Email,
                              Purchases.ItemCode, Purchases.Product
                     FROM Clients
                     JOIN Purchases
                     ON Clients.Id = Purchases.Id";

        return sql;
    }
}
