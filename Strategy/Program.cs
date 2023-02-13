using Strategy;

namespace Sgrategy;
public static class Program
{
    public static void Main(string[] args)
    {
        var rec = new Recommend(new CalcCosine());
        rec.ExecuteRecommend();

        // アルゴリズムを切り替えたい。
        rec.setCalc(new CalcEuclid());
        // ここ以降はずっとEuclidで計算してくれる。
        rec.ExecuteRecommend();
    }
}
