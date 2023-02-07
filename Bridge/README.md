
    classA --|> classB : Inheritance(継承)
    classM ..|> classN : Realization(実装)
    classC --*  classD : Composition(構成)
    classE --o  classF : Aggregation(集計)
    classG -->  classH : Association(関連)
    classI --   classJ : Link(Solid)(リンク)
    classO ..   classP : Link(Dashed)(リンク)
    classK ..>  classL : Dependency(依存関係)
    + Public
    - Private
    # Protected
    * Abstract e.g.: someAbstractMethod()*
    $ Static e.g.: someStaticMethod()$

```mermaid
classDiagram
    Abstraction <-- RefinedAbstraction: 実装
    Implementor o-- Abstraction : 集合
    Implementor <-- ConcreteImplementor : 実装

    %% 機能クラス
    class Abstraction {
        -impl
        method1()
        method2()
        method3()
    }
    class RefinedAbstraction {
        refineMethod1()
        refineMethod2()
    }

    %% 実装クラス
    class Implementor {
        <<abstract>>
        impleMethod1()*
        impleMethod1()*
    }

    class ConcreteImplementor {
        impleMethod1()
        impleMethod1()
    }
```
