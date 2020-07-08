using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class CastSequence:Sequence
    {
        public CastSequence(string target)
        {
            Add(new Action("DisableInput()"));
            Add(new Action("Cast({0}, {1})", true, tom, target));
            Add(new Action("PlaySound(fireplace, {0}, true)", target));
            Add(new Action("EnableEffect({0}, campfire)",true, target));
            Add(new Wait(1));
            Add(new Action("EnableInput()"));
        }
    }
}
