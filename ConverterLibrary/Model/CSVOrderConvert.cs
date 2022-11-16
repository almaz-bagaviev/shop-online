namespace ConverterLibrary.Model;

public class CSVOrderConvert : IOrderConvert
{
    string path;
    public Order GetOrder { get; set; }

    public CSVOrderConvert(string path)
    {
        this.path = path;
        GetOrder = ConverterToCSV();
    }

    private Order ConverterToCSV()
    {
        try
        {
            using (StreamReader reader = new StreamReader(this.path))
            {
                string line;
                string[] column;

                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    column = line.Split(';');

                    GetOrder = new(column[0],
                        column[1],
                        column[2],
                        column[3],
                        column[4],
                        column[5],
                        column[6],
                        int.Parse(column[7]),
                        DateTime.Parse(column[8]),
                        column[9],
                        decimal.Parse(CheckDecimal.CheckDotOrComma(column[10]))
                        );
                }
                Console.WriteLine(GetOrder);
                return GetOrder;
            }
        }
        catch (Exception e)
        {
            GetOrder = new Order(true);
            FileError.ExceptionInfo(@"CsvOrderExceptionFile.json", e.Message);
            return GetOrder;
        }
    }
}