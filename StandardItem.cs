using csharp;

public class StandardItem : SellableItem
{
    public StandardItem(Item item) : base(item)
    {
    }

    private void ModifyQuality(Item item, int v)
    {
        if (item.Quality >= 0 && item.Quality < 50) item.Quality += v;
        if (item.Quality > 50) item.Quality = 50;
        if (item.Quality < 0) item.Quality = 0;
    }

    public override void Update()
    {
        if (Item.SellIn > 0)
        {
            ModifyQuality(Item, -1);
        }

        if (Item.SellIn <= 0)
        {
            ModifyQuality(Item, -2);
        }

        Item.SellIn -= 1;

    }
}