    classA --|> classB : Inheritance(継承)
    classM ..|> classN : Realization(実装)
    classC --*  classD : Composition(構成)
    classE --o  classF : Aggregation(集計)
    classG -->  classH : Association(関連)
    classI --   classJ : Link(Solid)(リンク)
    classO ..   classP : Link(Dashed)(リンク)
    classK ..>  classL : Dependency(依存関係)


# Iterator パターン
集合を繰り返すインターフェースを提供する設計

```mermaid
classDiagram
    IIterator   <|.. CompanyListIterator : 実装
    IAgregate   <..  CompanyList         : 依存
    IIterator   <--  IAgregate           : create
    Company     --o  CompanyList         : 集計
    CompanyList --o  CompanyListIterator : 集計

    class IIterator{
        +bool hasNext()
        -object next()
    }

    class IAgregate{
        +Iterator iterator()
    }

    class Company{
        -string name
        +string getName()
    }

    class CompanyList{
        -Company[] company
        -int last;
        +Company getCompanyAt(int index)
        +void appendCompany(Comapny company)
        +int getLength()
        +Iterator iterator()
    }


    class CompanyListIterator{
        -ComapnyList companyList
        -int index
        +bool hasNext()
        +object next()
    }
```

