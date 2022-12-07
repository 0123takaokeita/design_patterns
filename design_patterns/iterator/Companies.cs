
namespace CEO
{
    /// <summary>
    /// Iteratorと委譲関係のインターフェース
    /// </summary>
    public interface IAggregate
    {
        public IIterator iterator();
    }

    /// <summary>
    /// Iterator インターフェース
    /// </summary>
    public interface IIterator
    {
        public bool hasNext();
        public object next();
    }

    /// <summary>
    /// 集合の中のパーツのインターフェース
    /// </summary>
    interface IPart
    {
        public string getName();
        public int getPrice();
    }

    /// <summary>
    /// 会社リスト用のIterator実装
    /// </summary>
    public class CompanyListIterator : IIterator
    {
        private CompanyList CompanyList;
        private int index;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CompanyListIterator(CompanyList CompanyList)
        {
            this.CompanyList = CompanyList;
            this.index = 0;
        }

        /// <summary>
        /// index が最大値を超えていないかどうかを判定する。
        /// </summary>
        /// <returns></returns>
        public Boolean hasNext()
        {
            if (index < CompanyList.getLastNum())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// indexで指定されたObjectを取得
        /// </summary>
        /// <returns></returns>
        public Object next()
        {
            Company company = CompanyList.getCompanytAt(index);
            index++;
            return company;
        }
    }

    /// <summary>
    /// 会社のリスト
    /// </summary>
    /// <note>ここでIAggregateを実装することでIteratorの実装には依存しなくなる。</note>
    public class CompanyList : IAggregate
    {
        protected Company[] companies;
        private int last = 0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="companyCount"></param>
        public CompanyList(int companyCount)
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

        /// <summary>
        /// Iterator を実装しているClassを生成する。
        /// </summary>
        /// <returns></returns>
        /// <note>包含関係となっているため、iterator側に次へ送る動作を任せることができる</note>
        public IIterator iterator()
        {
            return new CompanyListIterator(this);
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
    public abstract class AbstractPerson
    {
        private CompanyList companies;
        public abstract void createCompanyList();
        public abstract void callCompanyList();
    }

    /// <summary>
    /// 社長の実装
    /// </summary>
    public class Takao : AbstractPerson
    {
        private CompanyList companies;

        /// <summary>
        /// 会社リストを作成する
        /// </summary>
        public override void createCompanyList()
        {
            companies = new CompanyList(5);
            companies.add(new Company("Google", 1));
            companies.add(new Company("Apple", 2));
            companies.add(new Company("Neogenia", 3));
            companies.add(new Company("Mercari", 4));
            companies.add(new Company("DeNA", 8));
        }

        /// <summary>
        /// 会社リストの一覧を読み上げる。
        /// </summary>
        public override void callCompanyList()
        {
            IIterator iterator = companies.iterator();
            while (iterator.hasNext())
            {
                Company company = (Company)iterator.next();
                Console.WriteLine(company.getName());
                Console.WriteLine(company.getPrice());
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
            Takao takao = new Takao();
            takao.createCompanyList();
            takao.callCompanyList();
            Console.ReadLine();
        }
    }
}
