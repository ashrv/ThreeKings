using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;

namespace InteractiveStory
{
    public abstract class Dialog
    {
        protected string Selected(string text)
        {
            return "input Selected " + text;
        }

        protected Action SetDialog(string dialog)
        {
            return new Action(string.Format("SetDialog(\"{0}\")", dialog), true);
        }

        public Sequence Generate(string right, string left = null, bool otherOnly = false)
        {
            var sequence = new Sequence();
            if (otherOnly)
            {
                sequence.Add(new Action(string.Format("SetLeft({0})", right)));
                sequence.Add(new Action("SetRight(null)"));
            }
            else
            {
                sequence.Add(new Action(string.Format("SetLeft({0})", left ?? tom)));
                sequence.Add(new Action(string.Format("SetRight({0})", right)));
                if (left == null)
                    sequence.Add(new Action(string.Format("WalkTo({0}, {1})", tom, right), true));
            }
            sequence.Add(SetDialog(SetAction()));
            sequence.Add(new Action("ShowDialog()"));
            return sequence;
        }

        protected abstract string SetAction();
        
    }
}
