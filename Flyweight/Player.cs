namespace Flyweight;

// プレイヤーのクラス。
// リュックを持っていて、そこにポケモンを入れる。
// ポケモンを捕まえることもできる。
public class Player
{
    string name;
    // pool
    public Dictionary<string, Pokemon> pokemons = new Dictionary<string, Pokemon>();

    public Player(string name)
    {
        this.name = name;
    }

    // ポケモンを捕まえる
    // Factoryを参照して、ポケモンを取得する
    public void GetPokemon(string key)
    {
        var pokemonFactory = PokemonFactory.GetInstance();
        var _key = $"{this.name}_{key}";
        var pokemon = pokemonFactory.GetPokemon(_key);
        pokemons.Add(_key, pokemon);
    }

    public void EncountPokemon(string key, int damage)
    {
        var pokemonFactory = PokemonFactory.GetInstance();
        var _key = $"{this.name}_{key}";
        var pokemon = pokemonFactory.GetPokemon(_key);
        pokemon.ReceiveDamage(damage);
    }

    // poolの中身を表示する
    public void PrintPokemons()
    {
        Console.WriteLine($"{name}のポケモン");
        foreach (var pokemon in pokemons)
        {
            var _pokemon = pokemon.Value;
            Console.Write($"{_pokemon.name}: ");
            _pokemon.PrintState();
        }
    }
}

