// 継承パターン
namespace Neogenia
{
    /// <summary>
    /// TeachLeadのインターフェース
    /// </summary>
    public abstract class AbstractTechLead
    {
        public abstract void recreate();
    }

    /// <summary>
    /// 社員に指示を出すクラス
    /// </summary>
    class Neogneia
    {

        static void Main(string[] args)
        {
            TechLead techLead = new TechLead();
            techLead.recreate();
            Console.ReadLine();
        }
    }

    /// <summary>
    /// テックリードポジションのクラス
    /// </summary>
    class TechLead : AbstractTechLead
    {
        private Programmer _programmer = new Programmer();

        public override void recreate()
        {
            //Console.WriteLine("TechLead が作り直します。");
            //呼び出し側からは見えないが、より効率の良い関数に切り替える。
            _programmer.refactor();
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
