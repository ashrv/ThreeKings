using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class SkillEarned:Sequence
    {
        public SkillEarned()
        {
            GameState.availableSkillPoints++;
            Add("DisableInput()");
            Add("CreateEffect({0}, Resurrection)", tom);
            Add("PlaySound(spell)");
            Add(new Wait(1));
            Add(new Narration("You earned a new skill point. Press E to open the skills menu and upgrade your skills."));
            Add("EnableInput()");


        }
    }
}
