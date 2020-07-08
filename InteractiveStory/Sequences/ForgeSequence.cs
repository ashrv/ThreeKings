using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class ForgeSequence:Sequence
    {
        public ForgeSequence(string first, string second)
        {
            Add("Put({0}, {1}, {2})", true, tom, first, blacksmithshop + ".Anvil");
            Add("DisableInput()");
            Add("FadeOut()", true);
            Add("PlaySound(Sheathe)");
            Add(new Wait(.2f));
            Add("PlaySound(Sheathe)");
            Add(new Wait(.2f));
            Add("PlaySound(Fireball)");
            Add(new Wait(.2f));
            Add("PlaySound(Draw)");
            Add("SetPosition({0})", first);
            Add(new SetPosition(second, blacksmithshop, "Anvil"));
            Add(new DisableIcon("Put", blacksmithshop + ".Anvil"));
            Add("FadeIn()", true);
            Add("EnableInput()");
        }
    }
}
