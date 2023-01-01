using System.Runtime.CompilerServices;

namespace singleton;

/// <summary>
/// 問題５-1
/// </summary>
public class TicketMaker
{
    private int ticket = 1000;

    private static TicketMaker singleton = new TicketMaker();

    private TicketMaker() { }

    public TicketMaker getInstance()
    {
        return singleton;
    }
    [MethodImpl(MethodImplOptions.Synchronized)]
    public int getNextTicketNumber()
    {
        return ticket++;

    }
}
