using csharp;
using Newtonsoft.Json.Linq;

public class Cheese : SellableItem
{
    public Cheese(Item item) : base(item)
    {
    }

    public override void Update()
    {
        Item.SellIn -= 1;
        ModifyQuality(Item, Item.SellIn < 0 ? 2 : 1);
    }

    private void ModifyQuality(Item item, int value)
    {
        if (item.Quality >= 0 && item.Quality < 50) item.Quality += value;
        if (item.Quality > 50) item.Quality = 50;
        if (item.Quality < 0) item.Quality = 0;
    }
}