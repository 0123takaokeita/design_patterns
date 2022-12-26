namespace template_method;

public abstract class AbstractWork
{
    protected abstract void startCall();
    protected abstract void printWork();
    protected abstract void endCall();

    public void display()
    {
        startCall();
        printWork();
        endCall();
    }
}
