using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveStory
{
    class BobDialog : Dialog
    {
        protected override string SetAction()
        {
            var dialog = "Hey! You must be new to these parts, aren't ya? Just passing through? There's a bunch of things you need to know, lad! You wanna hear them out?\\n[exposition|Sure! Go ahead!]\\n[notime|Thanks! I'm good!]";
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("exposition"),
                sequence = ()=>new ExpositionSequence()
            });
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("notime"),
                sequence = ()=>new EndDialogSequence()
            });
            return dialog;
        }
    }
}
