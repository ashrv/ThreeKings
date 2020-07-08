using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory.Dialogs
{
    public class BanditDialog : Dialog
    {
        static int dialogDepth;
        internal static bool talkedTo;
        protected override string SetAction()
        {
            talkedTo = true;
            string dialog;
            if (dialogDepth == 0)
            {
                dialog = "What? Who are you? What do you want with me?";
                if (GameState.lionheartQuestState == 1)
                {
                    dialog += "\\n[killyou|I'm here to kill you]\\n[stopbandit|You have to stop your debauchery]\\n[turnin|You must hand yourself to the king and confess to your crimes]";
                }
                if (GrandmaDialog.talkedTo)
                {
                    dialog += "\\n[foundfamily|I found your family]";
                }
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("foundfamily"),
                    sequence = () => new Sequence() {
                    new Action("SetExpression({0}, happy)", bandit),
                    new Action("ClearDialog()"),
                    SetDialog(SetAction())
                },
                    changeState = () => dialogDepth = 1
                });
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("killyou"),
                    sequence = () => new Sequence()
                {
                    new Action("HideDialog()"),
                    new DisableIcon("Talk", bandit),
                    new Action("SetExpression({0}, angry)", bandit),
                    new Action("Draw({0}, {1})", true, bandit, swordBandit)
                },

                });
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("stopbandit"),
                    sequence = () => new Sequence()
                {
                    new SimpleDialog("Stop? Debauchery? Someone has to do it! I can't stop! I mustn't!")
                }
                });
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("turnin"),
                    sequence = () => new Sequence()
                {
                    new SimpleDialog("Oh no! He will have me killed! I won't! You can't make me!")
                }
                });
            }
            else
            {
                dialog = "Oh thank you stranger!Please! Please take me to them!\\n[reunite|Leave]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("reunite"),
                    sequence = () => new Sequence()
                    {
                        new DisableIcon("Talk", bandit),
                        new DisableIcon("Attack", bandit),
                        new DisableIcon("Talk", grandma),
                        new Action("SetExpression({0}, happy)", grandma),
                        new Action("SetExpression({0}, happy)", child),
                        new Action("DisableInput()"),
                        new EndDialogSequence(),
                        new Action("FadeOut()",true),
                        new SetPosition(bandit, dungeon, "RoundTable", waitFor:true),
                        new SetPosition(tom, dungeon,waitFor:true),
                        new Action("FadeIn()", true),
                        new Action("EnableInput()")
                    }
                });
            }
            return dialog;
        }
    }
}
