
/// <summary>
/// Mediator役
/// </summary>
public interface IChatMediator
{
    void SendMessage(string message, IColleague user);
    void AddUser(IColleague user);
    void RemoveUser(IColleague user);
}

/// <summary>
/// ConcreteMediator役
/// </summary>
public class ChatMediator : IChatMediator
{
    private List<IColleague> _users;
 
    public ChatMediator()
    {
        _users = new List<IColleague>();
    }
 
    public void AddUser(IColleague user)
    {
        _users.Add(user);
    }
    
    /// <summary>
    /// TODO: ここにremoveを作ってしまうと mediatorからは消えるが、userはmediatorを持ったままになる。
    /// </summary>
    /// <param name="user"></param>
    public void RemoveUser(IColleague user)
    {
        _users.Remove(user);
    }
 
    public void SendMessage(string message, IColleague user)
    {
        foreach (var u in _users)
        {
            if (u != user && !u.CanSend())
                u.ReceiveMessage(message);
        }
    }
}

/// <summary>
/// Colleague役
/// </summary>
public interface IColleague
{
    void SendMessage(string message);
    void ReceiveMessage(string message);
    bool CanSend();
}
 
/// <summary>
/// ConcreteColleague役
/// </summary>
public class User : IColleague
{
    private string _name;
    private IChatMediator _chatMediator;
    // ミュート機能追加
    private bool _mute;
    public User(string name, IChatMediator chatMediator, bool mute)
    {
        _name = name;
        _chatMediator = chatMediator;
        _chatMediator.AddUser(this);
        _mute = mute;
    }
 
    public void SendMessage(string message)
    {
        Console.WriteLine(_name + " sends message: " + message);
        _chatMediator.SendMessage(message, this);
    }
 
    public void ReceiveMessage(string message)
    {
        // 送信可能の条件がここにあるが、本来はMediatorがやるべきでは？
        // CanSend()を実装して送信可能かどうかは設定を見る。
        // 他には受信拒否ユーザーとかの設定もあり。 ルームから来た場合はいいが、1対1の場合は拒否するとか。
        // 判断するための材料はUserが保持するべきだが、送信の判断はMediatorが行う？
        // if (_mute) return;
        Console.WriteLine($"{_name} receives message: ${message}");
    }

    public bool CanSend()
    {
        return _mute;
    }
}

/// <summary>
/// Client役
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        // mediator を一つのチャットルームと見立てる。
        var mediator = new ChatMediator();
         
        // 同じmediatorを渡すと同じチャットルームに所属する。
        var user1 = new User("M", mediator, false);
        var user2 = new User("J", mediator, false);
        var user3 = new User("K", mediator, true);
        
        user1.SendMessage("Hi, everyone!");
        //
        // mediator.RemoveUser(user1);
        // user2.SendMessage("Hi, everyone!");
    }
}


