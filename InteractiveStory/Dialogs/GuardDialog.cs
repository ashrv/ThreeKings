using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.InputController;

namespace InteractiveStory
{
    public class GuardDialog:Dialog
    {
        protected override string SetAction()
        {
            var dialog = "Newcomers are strongly...encouraged...to pay their respects to King Lionheart the Just before going on their way\\n[sure|Suuure!]\\n[whatif|And what if they don't?]\\n[sure|Leave]";
            InputController.instance.Add(new Event()
            {
                input = Selected("sure"),
                sequence = ()=>new EndDialogSequence()
            });
            InputController.instance.Add(new Event()
            {
                input = Selected("whatif"),
                sequence = ()=>new Sequence()
                {
                    new Action("ClearDialog()", true),
                    MustRespect()
                }
            });
            return dialog;
        }

        public Action MustRespect()
        {
            var dialog = "I insist... Sir [sure|Leave]";
            return SetDialog(dialog);
        }
    }
}
