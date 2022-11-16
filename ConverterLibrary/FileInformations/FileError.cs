namespace ConverterLibrary.FileInformations;

public class FileError
{
    public static void ExceptionInfo(string path, string message)
    {
        Debug.WriteLine(message);
        File.WriteAllText(path, message);
    }
}