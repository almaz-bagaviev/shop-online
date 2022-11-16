using ConverterLibrary.DB;
using ConverterLibrary.Entities;
using ConverterLibrary.MainConverter;
using ConverterLibrary.Model;
using ConverterLibrary.Repositories;
using System.Collections.Generic;

namespace ShopOnline.Models;

public class ViewModel
{
    public List<Order> Orders { get; set; }

    public ViewModel()
    {
        Orders = new List<Order>();

        string newFile = @"Resources\Order.csv";
        IOrderConvert orderCSV = Repository.GetOrders(FileType.csv, newFile);
        FileReaderConverter fileReaderCSV = new(orderCSV);
        fileReaderCSV.Save("order1.txt");

        string newFile2 = @"Resources\Order.json";
        IOrderConvert orderJson = Repository.GetOrders(FileType.json, newFile2);
        FileReaderConverter fileReaderJson = new(orderJson);
        fileReaderJson.Save("order2.txt");

        string newFile3 = @"Resources\Order.xml";
        IOrderConvert orderXml = Repository.GetOrders(FileType.xml, newFile3);
        FileReaderConverter fileReaderXml = new(orderXml);
        fileReaderXml.Save("order4.txt");

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\GitFilesInF\Shop\Shop\ShopDatabase.mdf;Integrated Security=True";

        OrderDbConnection db = new(orderCSV, connectionString);
        OrderDbConnection db1 = new(orderJson, connectionString);
        OrderDbConnection db2 = new(orderXml, connectionString);

        Orders.Add(db.TablesModel.GetOrder);
        Orders.Add(db1.TablesModel.GetOrder);
        Orders.Add(db2.TablesModel.GetOrder);
    }
}
