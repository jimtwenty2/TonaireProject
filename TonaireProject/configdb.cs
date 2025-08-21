using System.Configuration;


namespace TonaireProject
{
    public class ConfigDb
    {
        public static string ConnectionString =>
           ConfigurationManager.ConnectionStrings["saledb"].ConnectionString;
    }
}
