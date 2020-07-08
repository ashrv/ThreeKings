using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class ReviveSequence:Sequence
    {
        public ReviveSequence()
        {
            Add("DisableInput()");
            Add("HideDialog()");
            Add("FadeOut()", true);
            Add("PlaySound({0})", grandma);
            Add("SetCameraMode({0})", track);
            Add("SetCameraFocus({0})", necromancer);
            Add("StandUp({0})", true, necromancer);
            Add(new SetPosition(necromancer, dungeon,"Chair"));
            Add(new SetPosition(tom, dungeon, "Door"));
            Add(new Action("StopSound({0})", dungeon));
            Add(new Action("StopSound({0})", bandit));
            Add(new Action("StopSound({0})", grandma));
            Add(new Action("PlaySound(danger3)"));
            Add("FadeIn()", true);
            Add("EnableEffect({0}, {1})", bandit, "skulls");
            Add("EnableEffect({0}, {1})", bandit, "resurrection");
            Add("Cast({0})",true, necromancer);
            Add("PlaySound(spell)");
            Add(new SetPosition(bandit, dungeon, "Table", waitFor: true));
            Add("CreateEffect({0}, {1})", bandit, "death");
            Add("CreateEffect({0}, {1})", bandit, "death");
            Add("CreateEffect({0}, {1})", bandit, "poof");
            Add("CreateEffect({0}, {1})", bandit, "poof");
            Add("SetExpression({0}, happy)", grandma);
            Add("SetExpression({0}, happy)", bandit);
            Add(new Wait(2f));
            Add("DisableEffect({0})", bandit);
            Add(new ReviveDialog().Generate(bandit, grandma));
        }
    }
}
