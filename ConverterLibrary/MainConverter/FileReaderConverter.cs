namespace ConverterLibrary.MainConverter;

public class FileReaderConverter
{
    public IOrderConvert OrderFile { get; set; }

    public FileReaderConverter(IOrderConvert orderFile)
    {
        this.OrderFile = orderFile;
    }

    public void Save(string fileName)
    {
        this.OrderFile.AddToTXT(fileName, this.OrderFile.GetOrder);
    }
}
