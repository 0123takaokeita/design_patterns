// 継承パターン
namespace Neogenia2
{
    /// <summary>
    /// TeachLeadのインターフェース
    /// </summary>
    interface ITechLead
    {
        public void recreate();
    }

    /// <summary>
    /// 社員に指示を出すクラス
    /// </summary>
    class Neogneia
    {

        static void Main(string[] args)
        {
            ITechLead techLead = new NewTechLead();
            techLead.recreate();
            Console.ReadLine();
        }
    }

    /// <summary>
    /// テックリードポジションのクラス
    /// </summary>
    class NewTechLead : Programmer, ITechLead
    {
        public void recreate()
        {
            //Console.WriteLine("TechLead が作り直します。");
            refactor();
        }
    }

    /// <summary>
    /// プログラマ
    /// </summary>
    class Programmer
    {
        public void refactor()
        {
            Console.WriteLine("Programmer がリファクタリングします。");
        }
    }

}
