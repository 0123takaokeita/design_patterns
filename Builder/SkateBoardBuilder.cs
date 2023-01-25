namespace Builder;

public class SkateBoardBuilder : BoardBuilder 
{
    private readonly SkateBoard _skateBoard;

    public SkateBoardBuilder()
    {
        this._skateBoard = new SkateBoard("", "", "", "");

    }
    
    public void selectDeck(decimal size)
    {
        this._skateBoard.deck = $"santa {size}";
    }

    public void addTape(int rough)
    {
        this._skateBoard.tape = $"blank {rough}";
    }

    public void addTruck(int size)
    {
        this._skateBoard.truck = $"independent {size}";
    }

    public void addWheel(int size, int duro)
    {
        _skateBoard.wheel= $"OJ {size}mm {duro}";
    }

    public object getResult()
    {
        return this._skateBoard;
    }
}
