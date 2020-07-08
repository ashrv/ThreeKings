using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class DieSequence:Sequence
    {
        public DieSequence(string target)
        {
            Add(new Sequence(){new Action("WalkTo({0}, {1})", true, tom, target),
                    new Action("DisableInput()"),
                    new Action("Draw({0}, {1})", true, tom, sword),
                    new Action("Attack({0}, {1})", true, tom, target),
                    new Action("Sheathe({0}, {1})", tom, sword),
                    new Action("SetExpression({0}, scared)", target),
                    new Action("Die({0})", true, target),
                    new Action("SetExpression({0}, asleep)", target),
                    new DisableIcon("Talk", target),
                    new DisableIcon("Attack", target), 
            });
        }
    }
}
