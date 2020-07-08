using InteractiveStory.Dialogs;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class FireballTargets:Sequence
    {
        public FireballTargets()
        {
            if (GameState.learntFireball)
            {
                if (GameState.lionheartQuestState == 1)
                {
                    Add(new EnableIcon("Burn", firespellIcon, bandit, false, "Kill"));
                }
                Add(new EnableIcon("Burn", firespellIcon, storage + ".Barrel", false, "Burn the castle down"));
                Add(new EnableIcon("Burn", firespellIcon, emmilia, false, "Burn the library down"));
                Add(new EnableIcon("Burn", firespellIcon, necromancer, false, "Burn"));
                Add(new EnableIcon("Burn", firespellIcon, lionheart, false, "Burn"));
                Add(new Action("EnableEffect({0}, diamond)", storage + ".Barrel"));
            }
        }
    }
}
