namespace ConverterLibrary.Model;

public class XMLOrderConvert : IOrderConvert
{
    string path;
    public Order GetOrder { get; set; }

    public XMLOrderConvert(string path)
    {
        this.path = path;
        this.GetOrder = ConvertToXmlOrder();
    }

    private Order ConvertToXmlOrder()
    {
        List<string> texts;
        try
        {
            XmlDocument xmlDocument = new();
            xmlDocument.Load(path);
            texts = new()
            {
                xmlDocument.GetElementsByTagName("LastName")[0].InnerText,
                xmlDocument.GetElementsByTagName("FirstName")[0].InnerText,
                xmlDocument.GetElementsByTagName("MiddleName")[0].InnerText,
                xmlDocument.GetElementsByTagName("Country")[0].InnerText,
                xmlDocument.GetElementsByTagName("City")[0].InnerText,
                xmlDocument.GetElementsByTagName("Phone")[0].InnerText,
                xmlDocument.GetElementsByTagName("Email")[0].InnerText,
                xmlDocument.GetElementsByTagName("NumberOfOrder")[0].InnerText,
                xmlDocument.GetElementsByTagName("Date")[0].InnerText,
                xmlDocument.GetElementsByTagName("Product")[0].InnerText,
                xmlDocument.GetElementsByTagName("Count")[0].InnerText
            };

            GetOrder = new()
            {
                LastName = texts[0],
                FirstName = texts[1],
                MiddleName = texts[2],
                Country = texts[3],
                City = texts[4],
                Phone = texts[5],
                Email = texts[6],
                NumberOfOrders = int.Parse(texts[7]),
                Date = DateTime.Parse(texts[8]),
                Product = texts[9],
                Count = decimal.Parse(CheckDecimal.CheckDotOrComma(texts[10]))
            };

            Console.WriteLine(GetOrder);
            return GetOrder;
        }
        catch (Exception e)
        {
            GetOrder = new Order(true);
            FileError.ExceptionInfo(@"XmlOrderExceptionFile.json", e.Message);
            return GetOrder;
        }

    }
}
