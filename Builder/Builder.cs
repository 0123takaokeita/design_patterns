namespace nuilder;

public interface Builder
{
    public void addSolute(decimal soluteAmount);
    public void addSolvent(decimal solventAmount);
    public void abandonSolution(decimal solutionAmount);
    public object getResult();
}
