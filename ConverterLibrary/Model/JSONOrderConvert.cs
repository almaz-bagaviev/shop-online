namespace ConverterLibrary.Model;

public class JSONOrderConvert : IOrderConvert
{
    string path;
    public Order GetOrder { get; set; }

    JToken mainTree;

    public JSONOrderConvert(string path)
    {
        this.path = path;
        this.GetOrder = ConverterToJson();
    }

    private Order ConverterToJson()
    {
        try
        {
            string json = File.ReadAllText(this.path);
            mainTree = JObject.Parse(json)["Order"]["Client"];

            GetOrder = new Order()
            {
                LastName = CheckIsNull("LastName"),
                FirstName = CheckIsNull("FirstName"),
                MiddleName = CheckIsNull("MiddleName"),
                Country = CheckIsNull("Country"),
                City = CheckIsNull("City"),
                Phone = CheckIsNull("Phone"),
                Email = CheckIsNull("Email"),
                NumberOfOrders = int.Parse(CheckIsNull("NumberOfOrder")),
                Date = DateTime.Parse(CheckIsNull("Date")),
                Product = CheckIsNull("Product"),
                Count = decimal.Parse(CheckIsNull("Count"))
            };


            Console.WriteLine(GetOrder);
            return GetOrder;
        }
        catch (Exception e)
        {
            GetOrder = new Order(true);
            FileError.ExceptionInfo(@"JsonOrderExceptionFile.json", e.Message);
            return GetOrder;
        }
    }

    private string CheckIsNull(string value)
    {
        string prop;
        if (mainTree[value] != null)
        {
            prop = mainTree[value].ToString();
        }
        else
        {
            if (value == "NumberOfOrder" || value == "Count") prop = "0";
            else if (value == "Date")
            {
                DateTime date = default;
                prop = date.ToString();
            }
            else
            {
                prop = "IsNull";
                string error = $"Поле имеет значение null. Проверьте файл: {this.path}";
                FileError.ExceptionInfo(@"JsonOrderExceptionFile.json", error);
            }
        }
        Debug.WriteLine(mainTree[value]);
        return prop;
    }
}
