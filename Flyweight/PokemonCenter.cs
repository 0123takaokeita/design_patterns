namespace Flyweight;

// プレイヤーのポケモンを回復させるクラス
public class PokemonCenter
{
    public void RecoveryPokemon(Dictionary<string, Pokemon> pokemons)
    {
        foreach (var pokemon in pokemons)
        {
            var _pokemon = pokemon.Value;
            _pokemon.health = _pokemon.maxHealth;
            _pokemon.isDead = false;
        }
    }
}

