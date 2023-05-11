namespace Flyweight;
/// <summary>
/// 登場済みのポケモンを管理する工場
/// </summary>
/// NOTE: singletonなので sealed で継承を禁止する必要あり。
public sealed class PokemonFactory
{
    private Dictionary<string, Pokemon> _pokemons = new Dictionary<string, Pokemon>();
    private static PokemonFactory Instance = null!;
    private static object LockObj = new object();

    private PokemonFactory() { }

    public static PokemonFactory GetInstance()
    {
        // NOTE: スレッドセーフになるようにlockをかける
        lock (LockObj)
        {
            return Instance ??= new();
        }
    }

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
            // TODO: 初期値は外からロードすれば？
            // とりあえず、100,10で初期設定
            var pokemon = new Pokemon(key, 100, 10);
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

