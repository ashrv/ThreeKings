using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class ChestSequence : Sequence
    {
        string chest;
        internal static ChestSequence chestIsOpen;

        public ChestSequence()
        {
            this.chest = ChestSequence.chestIsOpen.chest;
            Inventory.instance.Hide();
            Add("CloseFurniture({0}, {1})", true, tom, chest);
            ChestSequence.chestIsOpen = null;

        }
        public ChestSequence(string chest)
        {
            this.chest = chest;
            Add("WalkTo({0}, {1})", tom, chest);
            Add("OpenFurniture({0}, {1})", true, tom, chest);
            Add(Inventory.instance.Show(chest));
            ChestSequence.chestIsOpen = this;
        }
    }
}
