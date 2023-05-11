namespace Flyweight;

public class Client
{
    public static void Main()
    {
        var pokemonFactory = PokemonFactory.GetInstance();

        Console.WriteLine("\nプレイヤーAを作る。");
        var playerA = new Player("playerA");
        Console.WriteLine("\n連れて行くポケモンを決める");
        playerA.GetPokemon("hitokage");
        playerA.GetPokemon("zenigame");
        playerA.PrintPokemons();

        Console.WriteLine("\nプレイヤーBを作る。");
        var playerB = new Player("playerB");
        Console.WriteLine("\n連れて行くポケモンを決める");

        playerB.GetPokemon("zenigame");
        playerB.GetPokemon("furisigane");
        playerB.PrintPokemons();

        Console.WriteLine("\nポケモンpoolの確認");
        pokemonFactory.PrintPokemonsState();

        Console.WriteLine("\nバトル発生!!");
        playerA.EncountPokemon("hitokage", 10);
        playerA.EncountPokemon("zenigame", 100);

        playerB.EncountPokemon("zenigame", 10);

        Console.WriteLine("\nプレイヤーAのポケモンを回復させる。");
        var pokemonCenter = new PokemonCenter();
        pokemonCenter.RecoveryPokemon(playerA.pokemons);

        Console.WriteLine("\nプレイヤーAのポケモン");
        playerA.PrintPokemons();
        Console.WriteLine("\nプレイヤーBのポケモン");
        playerB.PrintPokemons();
        Console.WriteLine("\nポケモンpoolの確認");
        pokemonFactory.PrintPokemonsState();
    }
}
