namespace singleton;

/// <summary>
/// 問題５-1
/// </summary>
public class TicketMaker
{
    private int ticket = 1000;

    private static TicketMaker instancke = new TicketMaker();

    private TicketMaker() { }

    public int getNextTicketNumber()
    {
        return instancke.ticket++;

    }
}
