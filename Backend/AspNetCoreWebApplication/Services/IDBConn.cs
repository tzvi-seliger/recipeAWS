namespace AspNetCoreWebApplication.Services
{
    public interface IDBConn
    {
        string getConnString();
        string getDevString();

        string getQuery(string query);
    }
}