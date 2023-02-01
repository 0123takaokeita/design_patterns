namespace AbstractFactory
{
    public class MysqlConnector: IDbFactory
    {
        public IConnect connector() => new Connector();
        public IRelease releaseor() => new Releasor();
    }
}


