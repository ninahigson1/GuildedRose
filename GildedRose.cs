using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace csharp
{
    public class GildedRose
    {
        private static List<SellableItem> _items;
        public GildedRose(IList<Item> items)
        {
            _items = items.Select(SellableItem.FromItem).ToList();
        }

        public void UpdateQuality()
        {
            foreach (var sellableItem in _items)
            {
                sellableItem.Update();
            }
        }
    }
}