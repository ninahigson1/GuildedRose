using csharp;

public abstract class SellableItem
{
    public static SellableItem FromItem(Item item)
    {
        if (item.Name == "Aged Brie")
        {
            return new Cheese(item);
        }

        if (item.Name.StartsWith("Conjured"))
        {
            return new ConjuredItem(item);
        }

        if (item.Name.StartsWith("Backstage passes"))
        {
            return new BackstagePassItem(item);
        }

        if (item.Name == "Sulfuras, Hand of Ragnaros")
        {
            return new LengendaryItem(item);
        }
        return new StandardItem(item); 
    }
    public Item Item { get; }

    protected SellableItem(Item item)
    {
        Item = item;
    }

    public abstract void Update();
}