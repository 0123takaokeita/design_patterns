//  委譲パターン
namespace Neogenia
{
    /// <summary>
    /// TeachLead抽象クラス
    /// Target
    /// </summary>
    public abstract class AbstractTechLead
    {
        public abstract void recreate();
    }

    /// <summary>
    /// 社員に指示を出すクラス
    /// Client
    /// </summary>
    class Neogneia
    {
        static void Main(string[] args)
        {
            AbstractTechLead techLead = new TechLead();
            techLead.recreate();
            Console.ReadLine();
        }
    }

    /// <summary>
    /// テックリードポジションのクラス
    /// Adapter
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
    /// Adaptee
    /// </summary>
    class Programmer
    {
        public void refactor()
        {
            Console.WriteLine("Programmer がリファクタリングします。");
        }
    }
}
