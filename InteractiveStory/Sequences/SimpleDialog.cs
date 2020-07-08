using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class SimpleDialog:Sequence
    {
        public SimpleDialog(string dialog)
        {
            Add("ClearDialog()", true);
            Add("SetDialog(\"{0}\\n[leave|Leave]\")", dialog);
        }
    }
}
