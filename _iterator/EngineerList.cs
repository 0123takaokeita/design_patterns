namespace CEO
{
    public class EngineerListIterator : IIterator
    {
        private EngineerList EngineerList;
        private int index;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EngineerListIterator(EngineerList list)
        {
            this.EngineerList = list;
            this.index = 0;
        }

        /// <summary>
        /// index が最大値を超えていないかどうかを判定する。
        /// </summary>
        /// <returns></returns>
        public Boolean hasNext()
        {
            if (index < EngineerList.getLastNum())
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
            Engineer engineer = EngineerList.getCompanytAt(index);
            index++;
            return engineer;
        }
    }


    public class EngineerList : IAggregate
    {
        protected Engineer[] engineers;
        private int last = 0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="count"></param>
        public EngineerList(int count)
        {
            this.engineers = new Engineer[count];
        }

        /// <summary>
        /// 集合に追加する
        /// </summary>
        /// <param name="engineer"></param>
        public void add(Engineer engineer)
        {
            engineers[last] = engineer;
            last++;
        }

        /// <summary>
        /// Indexで指定した場所を取得
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Engineer getCompanytAt(int index)
        {
            return engineers[index];
        }

        /// <summary>
        /// 最後の数字を取得
        /// </summary>
        /// <returns></returns>
        public int getLastNum()
        {
            return last;
        }

        /// <summary>
        /// エンジニアのIteratorを包含する
        /// </summary>
        /// <returns></returns>
        public IIterator iterator()
        {
            return new EngineerListIterator(this);
        }
    }

    /// <summary>
    /// エンジニア
    /// </summary>
    public class Engineer : IPart
    {
        private string name;
        private int price;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public Engineer(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        /// <summary>
        /// 名前を返す
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
}
