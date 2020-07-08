using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory.Dialogs
{
    public class GrandmaDialog : Dialog
    {
        internal static int dialogDepth;
        internal static bool talkedTo;
        protected override string SetAction()
        {
            var dialog = "Son! You have to help us! My grandson and I were looking for his father when we got captured. I'm scared to death what trouble my son could have gotten himself into.\\n" +
                "[whatson|Your son?]\\n[leave|There is nothing I can do]\\n[leave|I'll look for him]";
            if (dialogDepth == 0)
            {
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("whatson"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        SetDialog(SetAction())
                    },
                    changeState = () => { dialogDepth = 1; talkedTo = true; }
                });
            }
            else
            {
                if (dialogDepth == 1)
                {
                    dialog = "My son, Liam, he has short brown hair and a mustache. He said he had people looking for him and never came back. Please! There is noone else who can help us!";
                    dialog += "\\n[badson|Why are people looking for him?]";
                    if (GameState.lionheartQuestState == 1)
                        dialog += "\\n[badson|He is wanted for stealing and wrongdoings]";
                }
                else
                {
                    dialog = "My son would never hurt a fly! He marched a protest against Lionheart. Lionheart took everything from us and left all his people starving";
                }
                
                if (GameState.lionheartQuestState == 2)
                    dialog += "\\n[deadson|Your son is dead]";
                else if (BanditDialog.talkedTo)
                    dialog += "\\n[seenson|I have seen him! I'll tell him to find you]";
                dialog += "\\n[leave|Leave]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("badson"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        SetDialog(SetAction())
                    },
                    changeState = () => { dialogDepth = 2; GameState.knowsAboutHunger = true; }
                });
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("deadson"),
                    sequence = () => new Sequence()
                    {
                        new Action("SetExpression({0}, sad)", grandma),
                        new Action("PlaySound(cry1, {0}, true)", grandma),
                        new EndDialogSequence()
                    },
                });
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("seenson"),
                    sequence = () => new SimpleDialog("Oh thank you, son! Thank you! We are forever indebted to you!"),
                });
            }

            return dialog;
        }
    }
}
