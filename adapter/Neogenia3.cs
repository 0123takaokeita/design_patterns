namespace Neogenia3
{
    /// <summary>
    /// TeachLeadのインターフェース
    /// </summary>
    public interface ITechLead
    {
        public void recreate();
    }

    /// <summary>
    /// 社員に指示を出すクラス
    /// </summary>
    class Neogneia
    {
        /// <summary>
        /// ルート
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ITechLead techLead = new NewTechLead();
            techLead.recreate();
            Console.ReadLine();
        }
    }

    /// <summary>
    /// プログラマ
    /// </summary>
    class Programmer
    {
        /// <summary>
        /// リファクタリングを行う
        /// </summary>
        public void refactor()
        {
            Console.WriteLine("Programmer がリファクタリングします。");
        }
    }

    /// <summary>
    /// 新しいテックリード
    /// </summary>
    class NewTechLead : ITechLead
    {
        Programmer programmer = new Programmer();

        /// <summary>
        /// 作り直します。
        /// </summary>
        public void recreate()
        {
            programmer.refactor();
        }
    }
}
