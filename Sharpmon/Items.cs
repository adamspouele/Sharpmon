using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpmon
{
    public class Items
    {
        //All Items
        public List<Item> All = new List<Item>();

        public Items()
        {
            All.Add(new Item("Potion",100, "Adds 5 HP to the current player’s Sharpmon.",5,0,0,0,0,0,0, null));
            All.Add(new Item("Super potion", 300, "Adds 10 HP to the current player’s Sharpmon.", 10, 0, 0, 0, 0, 0, 0, null));
            All.Add(new Item("Rare Candy", 700, "Adds one level to the current player’s Sharpmon.", 0, 0, 0, 0, 0, 0, 1, null));
            All.Add(new Item("Leppa Berry", 800, "Adds 12 HP to the current player’s Sharpmon.", 12, 0, 0, 0, 0, 0, 0, null));
            All.Add(new Item("Blue Berry", 500, "Adds 3 defense to the current player’s Sharpmon.", 0, 0, 3, 0, 0, 0, 1, null));
        }

        /// <summary>
        /// Allow to get the current sharpmon
        /// </summary>
        /// <param name="Target"></param>
        public void setTarget(Sharpmon Target)
        {
            foreach (var item in All)
            {
                item.setTarget(Target);
            }
            
        }
    }
}
