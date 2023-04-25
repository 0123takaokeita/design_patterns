# 用途、ユースケースを自分の言葉で説明 (約1分)

# サンプルの概要説明 (約1分)
名前： 〜〜システム

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
    IArticleState ..|> PublishedState : Realization
    IArticleState ..|> DeletedState   : Realization
    IArticleState ..|> DraftState     : Realization
    IContext      ..|> Article        : Realization
    IArticleState ..o Article         : Aggregation

    class IArticleState { 
        Show(IContext article) void
        Publish(IContext article) void
        Hide(IContext article) void
        Delete(IContext article) void
    }
    class IContext {
        title() string
        GetState(IArticleState state) void
    }
    class Article {
        -IArticleState state 
        +string title
        +Article(string title)
        +Show() void
        +Hide() void
        +Delete() void
        +Publish() void
        +ChangeState(IArticleState state) void
    }
    class PublishedState { 
        Show(IContext article) void
        Publish(IContext article) void
        Hide(IContext article) void
        Delete(IContext article) void
    }
    class DraftState {  
        Show(IContext article) void
        Publish(IContext article) void
        Hide(IContext article) void
        Delete(IContext article) void
    }
    class DeletedState { 
        Show(IContext article) void
        Publish(IContext article) void
        Hide(IContext article) void
        Delete(IContext article) void
    }

```
# ソースコードの説明 (約1分)

# メリットを、サンプルコードを用いて自分の言葉で説明 (約1分)
