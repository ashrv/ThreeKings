using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class Narration:Sequence
    {
        public Narration(string msg)
        {
            Add("SetNarration({0})", msg);
            Add("ShowNarration()");
        }
    }
}
