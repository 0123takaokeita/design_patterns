    classA --|> classB : Inheritance(継承)
    classM ..|> classN : Realization(実装)
    classC --*  classD : Composition(構成)
    classE --o  classF : Aggregation(集計)
    classG -->  classH : Association(関連)
    classI --   classJ : Link(Solid)(リンク)
    classO ..   classP : Link(Dashed)(リンク)
    classK ..>  classL : Dependency(依存関係)

```mermaid
classDiagram
    AbstractTechLeader <|-- TechLead : 継承
    AbstractTechLeader <--  Neogenia : Use
    Programmer         <|.. TechLead : 委譲

    class AbstractTechLeader {
        string recreate()
    }

    class Neogenia {
        main()
    }

    class TechLead {
        string recreate()
    }

    class Programmer{
        string refactor()
    }
```

```mermaid
classDiagram
    ITechLead <|.. TechLead : 実装
    ITechLead <--  neogenia : use
    Programmer  <|-- TechLead : 継承

    class ITechLead {
        string recreate()
    }

    class neogenia {
        main()
    }

    class TechLead {
        string recreate()
    }

    class Programmer{
        string refactor()
    }

```
