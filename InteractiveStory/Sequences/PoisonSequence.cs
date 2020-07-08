using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class PoisonSequence:Sequence
    {
        public PoisonSequence(string target,string targetPlace)
        {
            Add(new Sequence()
            {
                new Action("WalkTo({0}, {1})", true, tom, target),
                new Action("Put({0}, {1}, {2})", true, tom, redPotion, target),
                new DisableIcon("Poison", target),
                new Action("CreateEffect({0},poison)", target),
                new Wait(3f),
                new EscapeSequence(targetPlace)
            });
        }
    }
}
