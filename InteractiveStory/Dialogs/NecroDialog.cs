using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class NecroDialog : Dialog
    {
        internal static int dialogDepth;
        protected override string SetAction()
        {
            var dialog = "You must have a death wish to walk into my sanctum like this. Give me one good reason why I shouldn't turn you into ash right this moment.\\n" +
                "[nodisrespect|I meant no disrespect. I'm new to this dominion]\\n" +
                "[straightshooter|I'm not here to die. I'm here to learn]\\n" +
                "[foolish|I don't take joy in empty threats, old one]";

            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("serve"),
                sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        new Action("SetExpression({0})", necromancer),
                        SetDialog(SetAction())
                    },
                changeState = () => dialogDepth = 10
            });

            if (dialogDepth == 0)
            {
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("nodisrespect"),
                    sequence = () => new Sequence() {
                    new Action("ClearDialog()"),
                    SetDialog(SetAction())
                },
                    changeState = () => dialogDepth = 1
                });
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("straightshooter"),
                    sequence = () => new Sequence()
                {
                    new Action("ClearDialog()"),
                    new Action("SetExpression({0}, happy)", necromancer),
                    new Action("PlaySound(laugh2)"),
                    SetDialog(SetAction())
                },
                    changeState = () => dialogDepth = 2
                });
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("foolish"),
                    sequence = () => new Sequence()
                {
                    new Action("ClearDialog()"),
                    new Action("SetExpression({0}, happy)", necromancer),
                    new Action("PlaySound(laugh2)"),
                    SetDialog(SetAction())
                },
                    changeState = () => dialogDepth = 3
                });
            }
            else if (dialogDepth == 1)
            {
                dialog = "That still doesn't justify you being here. If you're not here to serve, you have little time to leave to whatever hole you crawled out of.\\n" +
                    "[serve|What do you need me to do?]\\n[leave|Leave]";
            }
            else if (dialogDepth == 2)
            {
                dialog = "Learn? Ha ha ha hah! Learn what? What word of mine is your miniscule brain capable to fathom?\\n" +
                    "[serve|I'll do whatever it takes]\\n[leave|Leave]";
            }
            else if (dialogDepth == 3)
            {
                dialog = "Ha ha ha hah! Fascinating! Your dimwittedness amuses me! I could use an amusing underling!\\n" +
                    "[serve|For what?]\\n[leave|Leave]";
            }
            else if (dialogDepth == 10)
            {
                dialog = "Hmm. The prisoners must be fed in the dungeon. Since there are no minions around, I recon you could handle a trivial task as such." +
                    "\\n[leave|Leave]";
              
            }
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("dungeon"),
                sequence = () => new Sequence()
                    {
                        new Action("DisableInput()"),
                        new EndDialogSequence(),
                        new Action("FadeOut()", true),
                        new SetPosition(tom, dungeon, waitFor:true),
                        new Action("FadeIn()"),
                        new Action("EnableInput()")
                    }
            });
            return dialog + (dialogDepth == 10 ? "\\n[dungeon|(Go to the dungeon)]":"") ;
        }
    }
}
