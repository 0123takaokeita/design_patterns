namespace Builder;

/// <summary>
/// ここでスケートボードを作る。
/// </summary>
public class BoardDirector
{
    private BoardBuilder builder;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="builder"></param>
    public BoardDirector(BoardBuilder builder)
    {
        this.builder = builder;
    }

    public void constract()
    {
        builder.selectDeck(8);
        builder.addTape(3);
        builder.addTruck(144);
        builder.addWheel(54, 99);
    }
}