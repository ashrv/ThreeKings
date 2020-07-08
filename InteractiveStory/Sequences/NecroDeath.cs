using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory.Sequences
{
    public class NecroDeath : Sequence
    {
        public NecroDeath()
        {
            Add(new Sequence()
                {
                    new DisableIcon("Talk", necromancer),
                    new DisableIcon("Travel"+castle, courtyard+".Horse"),
                    new Action("HideFurniture({0})", path+".WestEnd")
                });
        }
    }
}
