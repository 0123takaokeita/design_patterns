namespace CEO
{
    /// <summary>
    /// 会社のリスト
    /// </summary>
    public class Companies
    {
        protected Company[] companies;
        private int last = 0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="companyCount"></param>
        public Companies(int companyCount)
        {
            this.companies = new Company[companyCount];
        }

        /// <summary>
        /// 会社をリストに追加する
        /// </summary>
        /// <param name="company"></param>
        public void add(Company company)
        {
            companies[last] = company;
            last++;
        }

        /// <summary>
        /// 指定した会社を取得する
        /// </summary>
        /// <param name="index"></param>
        /// 
        /// <returns></returns>
        public Company getCompanytAt(int index)
        {
            return companies[index];
        }

        /// <summary>
        /// 最後のインデックスを取得する
        /// </summary>
        /// <returns></returns>
        public int getLastNum()
        {
            return last;
        }
    }

    /// <summary>
    /// 会社
    /// </summary>
    public class Company
    {
        private string name;
        private int price;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public Company(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        /// <summary>
        /// 名前をかえす
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return name;
        }

        /// <summary>
        /// 値段を返す
        /// </summary>
        /// <returns></returns>
        public int getPrice()
        {
            return price;
        }
    }

    /// <summary>
    /// 社長の抽象クラス
    /// </summary>
    public abstract class Person
    {
        protected Companies companies;

        public abstract void createCompanies();
        public abstract void callCompanies();
    }

    /// <summary>
    /// 社長の実装
    /// </summary>
    public class Takao : Person
    {
        private Companies companies;

        /// <summary>
        /// 会社リストを作成する
        /// </summary>
        public override void createCompanies()
        {
            companies = new Companies(5);
            companies.add(new Company("Google", 1));
            companies.add(new Company("Apple", 2));
            companies.add(new Company("Neogenia", 3));
            companies.add(new Company("Mercari", 4));
            companies.add(new Company("DeNA", 8));
        }

        /// <summary>
        /// 会社リストの一覧を読み上げる。
        /// </summary>
        public override void callCompanies()
        {
            int size = companies.getLastNum();
            for (int n = 0; n < size; n++)
            {
                Console.WriteLine(companies.getCompanytAt(n).getName());
            }
        }
    }

    /// <summary>
    /// プログラムルート
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Person takao = new Takao();
            takao.createCompanies();
            takao.callCompanies();
            Console.WriteLine("end");
        }

    }
}