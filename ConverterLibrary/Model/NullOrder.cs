namespace ConverterLibrary.Model;

public class NullOrder : IOrderConvert
{
    string path;
    public Order GetOrder { get; set; }

    public NullOrder(string path)
    {
        this.path = path;
        GetOrder = new Order(true);
    }
}
