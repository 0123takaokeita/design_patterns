namespace Strategy;

public class Recommend
{
    private IRecommend rec;

    public Recommend(IRecommend rec)
    {
        this.rec = rec;
    }

    public void setCalc(IRecommend rec)
    {
        this.rec = rec;
    }

    public void ExecuteRecommend()
    {
        rec.Execute();
    }
}
