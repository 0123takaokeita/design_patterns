
/// <summary>
/// ポケモンFactory
/// </summary>
public class PokemonFactory
{
    // pokemonのpool 
    private Dictionary<string, Pokemon> _pokemons = new Dictionary<string, Pokemon>();

    private PokemonFactory() { }

    // ポケモンセンターからFactoryを参照したかったので、Factoryをシングルトンにした。
    public static PokemonFactory GetInstance { get; } = new PokemonFactory();

    /// <summary>
    /// ポケモンを取得する
    /// </summary>
    public Pokemon GetPokemon(string key)
    {
        if (_pokemons.ContainsKey(key))
        {
            return _pokemons[key];
        }
        else
        {
            Pokemon pokemon = new Pokemon(key);
            _pokemons.Add(key, pokemon);
            return pokemon;
        }
    }

    // poolの中身を表示する
    public void PrintPokemonsState()
    {
        foreach (var pokemon in _pokemons)
        {
            var _pokemon = pokemon.Value;
            Console.Write($"{_pokemon.name}: ");
            _pokemon.PrintState();
        }
    }
}

public class PokemonCenter
{
    // ポケモンを回復させる
    public void RecoverPokemon(string key)
    {
        var _pokemonFactory = PokemonFactory.GetInstance;
        var _pokemon = _pokemonFactory.GetPokemon(key);
        _pokemon.RecoveryHealth();
    }
}

/// <summary>
/// ポケモンObject
/// </summary>
public class Pokemon
{
    public string name;
    private int _health;
    private int _maxHealth;
    private int _attack;
    public bool isDead { get; set; }

    public Pokemon(string name)
    {
        isDead = false;
        this.name = name;
    }

    public void RecoveryHealth()
    {
        _health = _maxHealth;
    }

    public void SetHealth(int health)
    {
        _maxHealth = health;
        _health = _maxHealth;
    }

    public void SetAttack(int attack)
    {
        _attack = attack;
    }

    /// <summary>
    /// ゲームオブジェクトのダメージ判定
    /// </summary>
    public void ReceiveDamage(int damage)
    {
        _health -= damage;
        Console.WriteLine($"{name}は{damage}のダメージを受けた");

        // _healthが0以下になったら死亡フラグを立てる
        if (_health <= 0)
        {
            Console.WriteLine($"{name}は力尽きた");
            isDead = true;
        }
    }

    public void PrintState()
    {
        Console.WriteLine($"Health: {_health}, Attack: {_attack}, isDead: {isDead}");
    }
}

public class Client
{
    public static void Main()
    {
        Console.WriteLine("\n連れて行くポケモンを決める");
        PokemonFactory pokemonFactory = PokemonFactory.GetInstance;

        // hitokageを生成する。
        Pokemon hitokage = pokemonFactory.GetPokemon("hitokage");
        hitokage.SetHealth(100);
        hitokage.SetAttack(5);

        // zenigameを生成する。
        Pokemon zenigame = pokemonFactory.GetPokemon("zenigame");
        zenigame.SetHealth(50);
        zenigame.SetAttack(10);

        // fusigidaneを生成する。
        Pokemon fusigidane = pokemonFactory.GetPokemon("fusigidane");
        fusigidane.SetHealth(80);
        fusigidane.SetAttack(8);

        pokemonFactory.PrintPokemonsState();

        Console.WriteLine("\nポケモンがダメージを受けた");
        hitokage.ReceiveDamage(50);
        hitokage.PrintState();
        zenigame.ReceiveDamage(80);
        zenigame.PrintState();
        fusigidane.ReceiveDamage(70);
        fusigidane.PrintState();

        Console.WriteLine("\nポケモンを回復させる。");
        PokemonCenter pokemonCenter = new PokemonCenter();
        pokemonCenter.RecoverPokemon("hitokage");
        pokemonCenter.RecoverPokemon("zenigame");
        pokemonCenter.RecoverPokemon("fusigidane");

        pokemonFactory.PrintPokemonsState();

        Console.WriteLine(hitokage.GetHashCode());
        Console.WriteLine(pokemonFactory.GetPokemon("hitokage").GetHashCode());
    }
}
