namespace ConverterTest;

public class MainUnitTest
{
    [Fact]
    public void CSVTest()
    {
        CSVOrderConvert convert = new(@"Order.csv");
        Order order = convert.GetOrder;
        Order newOrder = new("Абрамов", "Александр", "Иванович", "Россия", "Москва", "555-87-85", "abramov@mail.ru", 501, DateTime.Parse("10.11.2022 9:07:00"), "Сыр", 0.50M);
        Assert.Equal(newOrder, order);
    }

    [Fact]
    public void JSonText()
    {

        JSONOrderConvert convert = new(@"Order.json");
        Order order = convert.GetOrder;
        Order newOrder = new("Мамаева", "Олеся", "Александровна", "Россия", "Хабаровск", "44-74-85", "xab@mail.ru", 604, DateTime.Parse("11.11.2022 17:00:30"), "Краб", 10.6M);
        Assert.Equal(newOrder, order);
    }

    [Fact]
    public void XmlText()
    {

        XMLOrderConvert convert = new(@"Order.xml");
        Order order = convert.GetOrder;
        Order newOrder = new("Соколов", "Максим", "Петрович", "Россия", "Мурманск", "555-91-74", "sokolov@gmail.com", 745, DateTime.Parse("2022-11-10 15:14:00"), "Свежемороженые овощи", 5.7M);
        Assert.Equal(newOrder, order);
    }
}