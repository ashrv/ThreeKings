using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class EnableIcon:Action
    {
        public EnableIcon(string actionName, string icon, string target, bool @default=false, string description="")
        {
            this.action = string.Format("EnableIcon({0}, {1}, {2}, {3}, {4})",
                actionName, icon, target,description??"", @default.ToString().ToLower());
        }
    }
}
