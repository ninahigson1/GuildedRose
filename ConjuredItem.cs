using csharp;
using Newtonsoft.Json.Linq;
using System;

public class ConjuredItem : SellableItem
{
    public ConjuredItem(Item item) : base(item)
    {
    }

    public override void Update()
    {
        switch (Item.SellIn)
        {
            case > 0:
                ModifyQuality(Item, -2);
                break;
            case <= 0:
                ModifyQuality(Item, -4);
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