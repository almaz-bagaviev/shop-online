namespace ConverterLibrary.Model;

public interface IOrderConvert
{
    Order GetOrder { get; set; }

    void AddToTXT(string savePath, Order order)
    {
        File.WriteAllText(savePath, order.ToString());
    }
}
