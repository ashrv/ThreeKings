using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class SetPosition:Action
    {
        public SetPosition(string entity, string place, string furniture=null, string position=null, bool waitFor=false)
        {
            this.waitFor = waitFor;
            action = string.Format("SetPosition({0}, {1})", entity, 
                furniture == null ? place : 
                position == null ? place + "." + furniture: place+"."+furniture+"."+position);
        }
    }
}
