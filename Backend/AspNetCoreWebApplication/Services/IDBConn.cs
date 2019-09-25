namespace AspNetCoreWebApplication.Services
{
    public interface IDBConn
    {
        string getConnString();

        string getQuery(string query);
    }
}