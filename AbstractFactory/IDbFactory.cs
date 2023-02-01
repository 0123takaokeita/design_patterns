namespace AbstractFactory
{
    public interface IDbFactory
    {
        public IConnect connector();
        public IRelease releaseor();
    }
}