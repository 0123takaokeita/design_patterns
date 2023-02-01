namespace AbstractFactory
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            IDbFactory factory = (IDbFactory)createFactory();
            
            factory.connector().connect();
            factory.releaseor().release();
        }

        private static object createFactory()
        {
            // var dbName = Environment.GetEnvironmentVariable("DB_NAME") + "connector";
            var dbName = "Mysql"; // for debug
            
            if (dbName.Equals("Mysql"))
            {
                return new MysqlConnector();
            }
            
            // default
            return new PostgresConnector();
        }
    }
}
