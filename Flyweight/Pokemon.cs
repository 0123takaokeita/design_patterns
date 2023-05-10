namespace Flyweight;
/// <summary>
/// ポケモンObject
/// </summary>
/// NOTE: level up などの場合にattackやhealthを変更する必要がある
public class Pokemon
{
    public string name;
    public int health;
    public int maxHealth { get; private set; }
    private int _attack;
    public bool isDead { get; set; }

    public Pokemon(string name, int maxHealth, int attack)
    {
        this.name = name;
        this.maxHealth = maxHealth;
        this.health = maxHealth;
        this._attack = attack;
        this.isDead = false;
    }

    /// <summary>
    /// ゲームオブジェクトのダメージ判定
    /// </summary>
    public void ReceiveDamage(int damage)
    {
        health -= damage;
        Console.WriteLine($"{name}は{damage}のダメージを受けた");

        // _healthが0以下になったら死亡フラグを立てる
        if (health <= 0)
        {
            Console.WriteLine($"{name}は力尽きた");
            isDead = true;
        }
    }

    /// <summary>
    /// Pokemonの状態表示
    /// </summary>
    public void PrintState()
    {
        Console.WriteLine($"Health: {health}, Attack: {_attack}, isDead: {isDead}");
    }
}

