classDiagram
    Companies         --|> CompaniesIterator  : 継承
    Companies         ..|> ICompanies         : 実装
    ICompanies        ..|> Iiterator          : 実装
    CompaniesIterator ..|> Iiterator          : 実装

    class ICompanies{
        Iiterator()
    }

    class Iiterator{
        hasNext()
        next()
    }

    class CompaniesIterator{
        hasNext()
        next()
    }

    class Companies{
        Iiterator iterator()
        Company[] companies
    }

