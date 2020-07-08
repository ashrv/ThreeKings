using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class EndDialogSequence:Sequence
    {
        public EndDialogSequence()
        {
            Add("HideDialog()");
            Add("EnableInput()");
            Add("StopSound()");
        }
    }
}
