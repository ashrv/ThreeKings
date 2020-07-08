using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class LionheartDialog : Dialog
    {
        public static int dialogDepth = 0;
        protected override string SetAction()
        {
            var dialog = "";
            if (dialogDepth == 0)
            {
                dialog = "Greetings and welcome to my humble dominion. I do appreciate your courtesy to come and pay your respects to me first.\\n" +
                    "[nochoice|Your guards left me not much of a choice]\\n" +
                    "[nochoice|(Say nothing)]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("nochoice"),
                    sequence = () => new Sequence() {
                            new Action("ClearDialog()", true),
                            SetDialog(SetAction())
                        },
                    changeState = () => dialogDepth=1
                });
            }
            else if (dialogDepth == 1)
            {
                dialog = "I suppose you desire to pledge allegience to me. But please, be patient with me. " +
                "First, I have a request for you\\n[lionheartrequest|Next]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("lionheartrequest"),
                    sequence = () => new Sequence() {
                            new Action("ClearDialog()", true),
                            new EnableIcon("Take", handIcon, hammer, true, "Take"),
                            new DisableIcon("Inspect", hammer),
                            SetDialog(SetAction())
                        },
                    changeState = () =>
                    {
                        dialogDepth = 2;
                        InputController.instance.EnablePathways();
                    }
                });
            }
            else if (dialogDepth == 2)
            {
                dialog = "My people have been complaining about a vicious bandit roaming the eastern premises. " +
                    "Not only does he steal from the people in need, he shows no mercy to the helpless.\\n" +
                    "However, the east is outside my dominion and thus I ask you to put an end to this predicament.\\n" +
                    "[lionheartaccepted1|I'll see what I can do]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("lionheartaccepted1"),
                    sequence = () => !Inventory.instance.Contains(tom, sword) ?
                    new SimpleDialog("You have my gratitude! All I ask is for you to consider this favor.\\n" +
                "Visit the blacksmith and tell him that I sent you. He will grant you a worthy sword for you to wield.") :
                new SimpleDialog("You have my gratitude! All I ask is for you to consider this favor of mine."),
                    changeState = () =>GameState.lionheartQuestState=1
                });
            }



            return dialog;
        }

    }
}
