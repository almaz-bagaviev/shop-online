namespace ConverterLibrary.Model;

public class CheckDecimal
{
    public static string CheckDotOrComma(string doubleValueString)
    {
        string value;
        if (doubleValueString.Contains(' '))
        {
            string s = doubleValueString;
            int index = s.IndexOf(' ');
            string sUpDot = s[..index];
            string sAfterDot = s.Substring(index + 1);
            value = sUpDot + sAfterDot;
        }
        else
        {
            value = doubleValueString;
        }
        return value.Contains('.') ? value.Replace('.', ',') : value;
    }
}
