using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory.Dialogs
{
    public class LionheartDialog2 : Dialog
    {
        internal static int dialogDepth = 0;
        static int previousDepth = 0;
        protected override string SetAction()
        {
            var dialog = "Slendid! You have done the kingdom a favor. My people and I are greatful to you. I'd recon you are here to pledge your allegiance to me.\\n";
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("lionheartreset"),
                sequence = () => new Sequence()
                        {
                            new Action("ClearDialog()", true),
                            SetDialog(SetAction())
                        },
                changeState = () => LionheartDialog2.dialogDepth = previousDepth
            });
            if (dialogDepth == 0)
            {
                if (GameState.swordSkill < 3)
                {
                    dialog += "Indeed, you shall be a loyal gurdian to the realm, but first, you need to improve your swordsmanship (You require Swordsmanship skill of 3 to proceed)\\n[leave|Leave]";
                }
                else
                {
                    dialog += "Indeed, ou have proved your loyalty and mastered the skills to join my royalty. Before we proceed, I have another request.\\n[lionheartkillorder1|Next]";
                    InputController.instance.Add(new InputController.Event()
                    {
                        input = Selected("lionheartkillorder1"),
                        sequence = () => new Sequence()
                        {
                            new Action("ClearDialog()", true),
                            SetDialog(SetAction())
                        },
                        changeState = ()=>LionheartDialog2.dialogDepth = 1
                    });
                }
            }
            else if(dialogDepth==1)
            {
                dialog = "The kingdom is in peril as long as it is divided. The people are in constant fear and terror in the necromancer's domain.\\n" +
                    "Emmilia has forsaken her people and locked herself in her library.\\n" +
                    "I wouldn't hesitate to fight for my kingdom. However, breaking the truce wil ensue so many more deaths.\\n[lionheartkillorder2|Next]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("lionheartkillorder2"),
                    sequence = () => new Sequence()
                        {
                            new Action("ClearDialog()", true),
                            SetDialog(SetAction())
                        },
                    changeState = () => LionheartDialog2.dialogDepth = 2
                });
            }
            else if (dialogDepth == 2)
            {
                dialog = "You have the power to act and put an end to them\\nDo this and you shall have your place at my right hand.\\n" +
                    "Go to the blacksmith. He shall provide you with a blessed armour that is immune to any unearthly magic.\\n[lionheartkillorder3|Leave]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("lionheartkillorder3"),
                    sequence = () => new Sequence()
                        {
                            new EnableIcon("Take", handIcon, helmet, true, "Take"),
                            new DisableIcon("Inspect", helmet),
                            new EndDialogSequence()
                        },
                    changeState = () => GameState.lionheartQuestState=3
                });
            }
            else if (dialogDepth == 3)
            {
                dialog = "Fantastic! You are ready to face your foes and bring justice to the kingdom! Be on your way! [leave|Leave]";
            }
            else if (dialogDepth == -1)
            {
                dialog = "He was a threat to me and the kingdom! You have done the people a great service to put an end to his treachery.\\n[lionheartreset|(Say nothing)]\\n[lionheartconfront2|Your people are starving while you drown in riches]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("lionheartconfront2"),
                    sequence = () => new Sequence()
                        {
                            new Action("ClearDialog()", true),
                            SetDialog(SetAction())
                        },
                    changeState = () => LionheartDialog2.dialogDepth = -2
                });
                
            }
            else if (dialogDepth == -2)
            {
                dialog = "How dare you speak to your king in such vile words. I am LionHear the Just! The Just! My fairness is unmatched throughout the realm\\n[lionheartreset|(Say nothing)]\\n" +
                    "[lionheartconfront3|Your fairness seems to end beyond these doors]\\n" +
                    "[lionheartconfront3|I don't stand by while you ruin your share of the kingdom]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("lionheartconfront3"),
                    sequence = () => new Sequence()
                        {
                            new Action("ClearDialog()", true),
                            new Action("StandUp({0})",true, lionheart),
                            new Action("SetExpression({0}, angry)", lionheart),
                            SetDialog(SetAction())
                        },
                    changeState = () => LionheartDialog2.dialogDepth = -3
                });
            }
            else if (dialogDepth == -3)
            {
                dialog = "I will have my guard cut your tongue out, you imbecile! You are but a maggot against me! \\n" +
                    "This kingdom is mine and mine only! Leave before I have my guards cut off your head and feed it to the dogs!\\n[lionheartwar|Leave]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("lionheartwar"),
                    sequence = () => new Sequence()
                        {
                            new Action("ClearDialog()", true),
                            new DisableIcon("Talk", lionheart),
                            new EnableIcon("Attack", swordType, lionheart, true, "Kill"),
                            new EndDialogSequence()
                        },
                    changeState = () => GameState.lionheartQuestState = 100
                });
            }
            if (GameState.knowsAboutHunger&&dialogDepth>=0)
            {
                dialog += "\\n[lionheartconfront1|You lied about the bandit]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("lionheartconfront1"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()",true),
                        SetDialog(SetAction())
                    },
                    changeState = () => { previousDepth = dialogDepth; dialogDepth = -1; }
                });
            }
            return dialog;
        }
    }
}
