using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class EscapeSequence:Sequence
    {
        public EscapeSequence(string targetPlace)
        {
            Add(new Sequence()
            {
                new Narration("I'd better get out of there!"),
                new Action("FadeOut()", true),
                new SetPosition(tom, targetPlace, waitFor:true),
                new Action("FadeIn()", true),
            });
        }
    }
}
