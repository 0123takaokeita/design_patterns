# 用途、ユースケースを自分の言葉で説明 (約1分)

# サンプルの概要説明 (約1分)
名前： ポケモンの状態管理システム

# クラス図の説明 (約1分)
    classA --|> classB : Inheritance
    classC --* classD : Composition
    classE --o classF : Aggregation
    classG --> classH : Association
    classI -- classJ : Link(Solid)
    classK ..> classL : Dependency
    classM ..|> classN : Realization
    classO .. classP : Link(Dashed)

```mermaid
classDiagram
    PokemonFactory --> Pokemon : create
    PokemonFactory o-- Pokemon : Aggregation
    PokemonFactory <.. PokemonCenter : Dependency
    PokemonFactory <-- Client : create
    PokemonCenter <-- Client : create

    class PokemonFactory{
        -Dictionary~string, Pokemon~ _pokemons
        -PokemonFactory()
        +GetInstance() PokemonFactory
        +GetPokemon(string key) Pokemon
        +PrintPokemonState void
    }

    class Pokemon{
        +string name
        +bool isDead
        -int _health
        -int _maxHealth
        -int _attack
        +Pokemon(string name) void
        +RecoveryHealth() void
        +SetHealth(int health) void
        +SetAttach(int attack) void
        +ReceiveDamage(int damage) void
        +PrintState() void
    }

    class PokemonCenter{
        +RecoveryPokemon(string key)
    }

    class Client{
        +Main()
    }
```
# ソースコードの説明 (約1分)

# メリットを、サンプルコードを用いて自分の言葉で説明 (約1分)


