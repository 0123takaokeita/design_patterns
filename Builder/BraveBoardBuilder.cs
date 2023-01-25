namespace Builder;

public class BraveBoardBuilder : BoardBuilder 
{
    private readonly BraveBoard _braveBoard;

    public BraveBoardBuilder()
    {
        this._braveBoard = new BraveBoard("", "", "", "");

    }
    
    public void selectDeck(decimal size)
    {
        this._braveBoard.deck = $"Deck の size 指定はできないので 規制品になります。";
    }

    public void addTape(int rough)
    {
        this._braveBoard.tape = $"blank {rough}";
        this._braveBoard.tape = $"荒くないほうがいいから blank 1 に変えておきました";
    }

    public void addTruck(int size)
    {
        this._braveBoard.truck= $"Truck の size 指定はできないので 規制品になります。";
    }

    public void addWheel(int size, int duro)
    {
        this._braveBoard.wheel= $"小さい方が使いやすいので 変更しておきました。";
    }
    public object getResult()
    {
        return this._braveBoard;
    }
}