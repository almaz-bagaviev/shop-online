namespace ConverterLibrary.Repositories;

public class Repository
{
    public static IOrderConvert GetOrders(FileType type, string filePath)
    {
        IOrderConvert saveOrder = type switch
        {
            FileType.csv => new CSVOrderConvert(filePath),
            FileType.json => new JSONOrderConvert(filePath),
            FileType.xml => new XMLOrderConvert(filePath),
            _ => new NullOrder(filePath)
        };
        return saveOrder;
    }
}
