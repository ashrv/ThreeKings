using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class DisableIcon:Action
    {
        public DisableIcon(string actionName, string entity)
        {
            action = string.Format("DisableIcon({0}, {1})", actionName, entity);
        }
    }
}
