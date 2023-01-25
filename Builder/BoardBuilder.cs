namespace Builder;

/// <summary>
/// スケートボードを作るメソッドを定義しておく。
/// </summary>
public interface  BoardBuilder
{
    public void selectDeck(decimal size);
    public void addTape(int rough);
    public void addTruck(int size);
    public void addWheel(int size, int duro);
    public object getResult();
}
