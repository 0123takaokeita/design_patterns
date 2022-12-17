    classA --|> classB : Inheritance(継承)
    classM ..|> classN : Realization(実装)
    classC --*  classD : Composition(構成)
    classE --o  classF : Aggregation(集計)
    classG -->  classH : Association(関連)
    classI --   classJ : Link(Solid)(リンク)
    classO ..   classP : Link(Dashed)(リンク)
    classK ..>  classL : Dependency(依存関係)
# FactoryMethod Pattern

```mermaid
classDiagram
    AbstractCreator <|.. ConcreteCreator : 実装
    AbstractProduct <--  AbstractCreator : create
    AbstractProduct <|.. ConcreteProduct : 実装
    ConcreteProduct <--  ConcreteCreator : create
    ConcreteCreator <--  Program         : use

    class AbstractCreator{
        abstract create()
        abstract factoryMethod()
    }

    class  ConcreteCreator{
        factoryMethod()
    }

    class AbstractProduct{
        restore()
        delete()
        show()
    }

    class ConcreteProduct{
        restore()
        delete()
        show()
    }

    class Program{
        AbstractCreator creator
    }
```
