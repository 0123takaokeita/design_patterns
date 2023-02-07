namespace Bridge;

public class KeyBoard : IKeyBoard
{
    public string token { get; set; } = "";

    public void copyCmd(string token)
    {
        this.token = token;
    }

    public void pastCmd()
    {
      Console.WriteLine(this.token);
    }

    public void trimCmd(string token)
    {
        this.token = token;
    }
}

