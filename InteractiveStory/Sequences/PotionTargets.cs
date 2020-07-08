using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class PotionTargets:Sequence
    {
        public PotionTargets()
        {
            Add(new EnableIcon("Poison", poisonIcon, emmilia, false, "Poison"));
            Add(new EnableIcon("Poison", poisonIcon, dungeon + ".Chest", false, "Poison the food source"));
            Add(new EnableIcon("Poison", poisonIcon, storage + ".Chest", false, "Poison the food source"));
            Add(new EnableIcon("Poison", poisonIcon, lionheart, false, "Poison"));
            Add(new EnableIcon("Poison", poisonIcon, necromancer, false, "Poison"));
            Add(new Action("EnableEffect({0}, diamond)", dungeon + ".Chest"));
            Add(new Action("EnableEffect({0}, diamond)", storage + ".Chest"));

        }
    }
}
