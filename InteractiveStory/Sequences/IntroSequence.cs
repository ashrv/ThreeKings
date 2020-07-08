using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class IntroSequence:Sequence
    {
        public IntroSequence()
        {
            Add("Face({0}, {1})",true, tom, crossroads + "." + gate);
            Add(new EnableIcon("Talk", talkIcon, bob, true, "Talk to the "+bob));
            Add("SetPosition({0}, {1})", true, bob, crossroads + "." + gate);
            Add("MoveAway({0})", true, crossroads + "." + gate);
            Add("Face({0}, {1})",true, bob, tom);
            Add("FadeIn()");


        }
    }
}
