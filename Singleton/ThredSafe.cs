using System.Runtime.CompilerServices;

namespace singleton;

public class ThreadSafe
{
    private static ThreadSafe? singleton = null;

    private ThreadSafe()
    {
        slowdown();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static ThreadSafe? getInstance()
    {
        return singleton ??= new ThreadSafe();
    }

    private static void slowdown()
    {
        try
        {
            Thread.SpinWait(1000);
        }
        catch (ThreadInterruptedException e)
        {
            Console.WriteLine(e);
        }
    }

}