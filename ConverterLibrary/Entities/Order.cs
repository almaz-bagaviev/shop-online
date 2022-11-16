namespace ConverterLibrary.Entities;

public class Order : IEquatable<Order>
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int NumberOfOrders { get; set; }
    public DateTime Date { get; set; }
    public string Product { get; set; }
    public decimal Count { get; set; }

    public bool IsNull { get; set; }

    public Order(string lastName,
        string firstName,
        string middleName,
        string country,
        string city,
        string phone,
        string email,
        int numberOfOrder,
        DateTime date,
        string product,
        decimal count)
    {
        this.LastName = lastName;
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.Country = country;
        this.City = city;
        this.Phone = phone;
        this.Email = email;
        this.NumberOfOrders = numberOfOrder;
        this.Date = date;
        this.Product = product;
        this.Count = count;
    }

    public Order()
    {

    }

    public Order(bool isNull)
    {
        this.IsNull = isNull;
        string sNull = "isNull";

        this.LastName = sNull;
        this.FirstName = sNull;
        this.MiddleName = sNull;
        this.Country = sNull;
        this.City = sNull;
        this.Phone = sNull;
        this.Email = sNull;
        this.NumberOfOrders = default;
        this.Date = default;
        this.Product = sNull;
        this.Count = default;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"Фамилия: {this.LastName}\n");
        stringBuilder.Append($"Имя: {this.FirstName}\n");
        stringBuilder.Append($"Отчество: {this.MiddleName}\n");
        stringBuilder.Append($"Страна: {this.Country}\n");
        stringBuilder.Append($"Город: {this.City}\n");
        stringBuilder.Append($"Номер телефона: {this.Phone}\n");
        stringBuilder.Append($"Номер заказа: {this.NumberOfOrders}\n");
        stringBuilder.Append($"Дата совершения заказа: {this.Date}\n");
        stringBuilder.Append($"Товар: {this.Product}\n");
        stringBuilder.Append($"Кол-во/Вес: {this.Count}\n");

        return stringBuilder.ToString();
    }

    public bool Equals(Order other)
    {
        if (this.LastName == other.LastName &&
            this.FirstName == other.FirstName &&
            this.MiddleName == other.MiddleName &&
            this.Country == other.Country &&
            this.City == other.City &&
            this.Phone == other.Phone &&
            this.Email == other.Email &&
            this.NumberOfOrders == other.NumberOfOrders &&
            this.Date == other.Date &&
            this.Product == other.Product &&
            this.Count == other.Count)

            return true;
        else return false;
    }
}