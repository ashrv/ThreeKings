using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;

namespace InteractiveStory
{
    public class EmmiliaDeath:Sequence
    {
        public EmmiliaDeath()
        {
            Add(new Sequence()
            {  
                new Action("HideFurniture({0})", crossroads+".WestEnd"),
                new DisableIcon("Travel"+library, courtyard+".Horse")
            });
        }
    }
}
