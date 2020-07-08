using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class ExpositionFinishDialog : Dialog
    {
        protected override string SetAction()
        {
            var dialog = "Whatever domain you decide to reside in, you have to pledge allegiance to its ruler. Be wary newcomer, it is nothing but a daunting task!\\n[expoEnd|We will see about that!]\\n[expoEnd|I did not expect you to talk for so long.]";
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("expoEnd"),
                sequence = ()=>new AfterExpositionSequence()
            });
            return dialog;
        }
        class AfterExpositionSequence : Sequence
        {
            public AfterExpositionSequence()
            {
                Add("HideDialog()");
                Add("StopSound()");
                Add(new SetPosition(blacksmith, blacksmithshop, "Chest"));
                Add(new EnableControlsSequence());
            }
        }
    }
}
