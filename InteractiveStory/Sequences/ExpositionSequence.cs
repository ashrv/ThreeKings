using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class ExpositionSequence:Sequence
    {
        public ExpositionSequence()
        {
            Add("ClearDialog()", true);
            Add("PlaySound(Danger3)");
            Add(new BobExpoDialog().Generate(bob));
        }
    }
}
