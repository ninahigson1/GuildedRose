using System;
using csharp;

public class BackstagePassItem : SellableItem
{
    public BackstagePassItem(Item item) : base(item)
    {
    }
    public override void Update()
    {
        switch (Item.SellIn)
        {
            case <= 0:
                Item.Quality = 0;
                break;
            case <= 5:
                ModifyQuality(Item, 3);
                break;
            case <= 10:
                ModifyQuality(Item, 2);
                break;
            default:
                ModifyQuality(Item, 1);
                break;
        }
        Item.SellIn -= 1;
    }
    private void ModifyQuality(Item item, int v)
    {
        if (item.Quality >= 0 && item.Quality < 50) item.Quality += v;
        if (item.Quality > 50) item.Quality = 50;
        if (item.Quality < 0) item.Quality = 0;
    }
}