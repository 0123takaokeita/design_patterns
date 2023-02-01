namespace AbstractFactory
{
    /// <summary>
    /// Factory 具象クラス
    /// </summary>
    public class PostgresConnector: IDbFactory
    {
        public IConnect connector() => new Connector();

        public IRelease releaseor() => new Releasor();
    }
}


