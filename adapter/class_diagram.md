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
    ITechLeader <|.. TechLead : 実装
    ITechLeader <--  Neogenia : Use
    TechLead    <--  Neogenia : Create
    Programmer  <|.. TechLead : 委譲

    class ITechLeader {
        string recreate()
    }

    class Neogenia {
        main()
    }

    class TechLead {
        Programmer programmer
        string recreate()
    }

    class Programmer{
        string refactor()
    }

```

```mermaid
classDiagram
    Itechleader <|.. techlead   : 実装
    Itechleader <--  neogenia   : use
    programmer  <--  neogenia   : create
    techlead    <|-- programmer : 継承

    class Itechleader {
        string recreate()
    }

    class neogenia {
        main()
    }

    class techlead {
        string recreate()
    }

    class programmer{
        string refactor()
    }

```
