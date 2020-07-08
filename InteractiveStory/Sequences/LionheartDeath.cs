using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class LionheartDeath : Sequence
    {
        public LionheartDeath()
        {
            Add(new Sequence()
            {
                new DisableIcon("Talk", lionheart),
                    new DisableIcon("Travel"+castle, courtyard+".Horse"),
                    new DisableIcon("Travel"+blacksmithshop, courtyard+".Horse"),
                    new DisableIcon("Leave", courtyard+".Gate"),
            });
        }
    }
}
