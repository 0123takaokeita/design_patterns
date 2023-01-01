namespace singleton;

public class Tripple
{
    private int id;
    private static readonly Tripple[] tripple = new Tripple[]
    {
        new Tripple(0),
        new Tripple(1),
        new Tripple(2)
    };

    private Tripple(int id)
    {
        Console.WriteLine($"{id} が作られました。");
        this.id = id;

    }


    public Tripple getInstance(int id)
    {
        return tripple[id];
    }
}
