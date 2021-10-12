using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArmy
{
    abstract class Item
    {
        public string Name { get; protected set; }
        protected Item(string itemName)
        {
            Name = itemName;
        }

        public override abstract string ToString();
    }
}
