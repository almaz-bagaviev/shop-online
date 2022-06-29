namespace ShopOnline.Interfaces;

public interface ISQL
{
    string SelectSQL();
    string InsertSQL();
    string DeleteSQL();
    string UpdateSQL();
}
