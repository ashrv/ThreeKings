using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class EmmiliaDialog : Dialog
    {
        public static int spied = 0;
        public static int dialogDepth = 0;
        protected override string SetAction()
        {
            var dialog = "Ah! You must be here to read? Mustn't you? To learn about the herbs and chemistry. \\\"Why do you have to be so buoyant, Emmilia? He's illiterate.\\\" That is presumptuous of you! Are you, sir? Are you illiterate?\\n" +
                "[notilliterate|No, I am not. I am not here to read either]\\n[someoneelse|Is there someone else with us in this room?]";
            var monologue = "You see, I am the kingdom's brightest chemist. I can brew potions for every need! \\\"Do you want to find love? or do you want to have a courageous heart? or do you want to make one die a painful horrid death?\\\"\\n" +
                    "Now, now! Don't scare off this child!\\n[continue|Please continue]\\n[leave|Leave]";
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("continue"),
                sequence = () => new Sequence()
                {
                    new Action("ClearDialog()"),
                    new Action("SetExpression({0}, happy)",true, emmilia),
                    SetDialog(SetAction())
                },
                changeState = () => dialogDepth = 3
            });
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("emmOther"),
                sequence = () => new Sequence()
                {
                    new Action("ClearDialog()"),
                    new Action("SetExpression({0})",true, emmilia),
                    SetDialog(SetAction())
                },
                changeState = () => dialogDepth = 4
            });
            if (dialogDepth == 0)
            {
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("notilliterate"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        new Action("SetExpression({0}, happy)",true, emmilia),
                        SetDialog(SetAction())
                    },
                    changeState = () => dialogDepth = 2
                });
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("someoneelse"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        new Action("SetExpression({0}, disgusted)",true, emmilia),
                        SetDialog(SetAction())
                    },
                    changeState = () => dialogDepth = 1
                });
            }
            else if (dialogDepth == 1)
            {
                dialog = "Oh, don't mind her dear! " + monologue;
            }
            else if (dialogDepth == 2)
            {
                dialog = "Splendid! " + monologue;
            }
            else if (dialogDepth == 3)
            {
                dialog = "You're here to pledge allegiance with us, aren't you? I'm thrilled. We have the power to vanquish our competition. \\\"We hate sharing! We want it all!\\\" Calm yourself my dear. In due time!\\n" +
                    "[continue2|Carry on]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("continue2"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        new Action("SetExpression({0}, disgusted)",true, emmilia),
                        SetDialog(SetAction())
                    },
                    changeState = () => dialogDepth = 4
                });

            }
            else if (dialogDepth == 4)
            {
                dialog = "Go to LionHeart and " + necromancer + " and pretend you desire to serve them. Gather information that we can use against them in their demise.";
                if (LionheartDialog.dialogDepth == 2)
                {
                    dialog += "\\n[tellLionheart|Tell her about LionHeart]";
                }
                if (NecroDialog.dialogDepth == 10)
                {
                    dialog += "\\n[tellNecro|Tell her about " + necromancer + "]";
                }
                dialog += "\\n[leave|Leave]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("tellLionheart"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        new Action("SetExpression({0}, angry)",true, emmilia),
                        SetDialog(SetAction())
                    },
                    changeState = () => { spied++; dialogDepth = 5; }
                });
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("tellNecro"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        new Action("SetExpression({0}, angry)",true, emmilia),
                        SetDialog(SetAction())
                    },
                    changeState = () => { spied++; dialogDepth = 6; }
                });

            }
            else if (dialogDepth == 5)
            {
                dialog = "A bandit you say? \\\"He lies! There is no bandit! That's how he rids of those in his way. LionHeart the Just! Pff!\\\"\\n";
                if (spied == 2)
                {
                    dialog += "[emmQuest|Next]";
                }
                else
                    dialog += "[emmOther|Something else]";
            }
            else if (dialogDepth == 6)
            {
                dialog = "Feeding people? \\\"Don't be so naive! He's cursed with pyromania! He burnt down all the farms in his kingdom! His reign of terror must cease to exist!\\\"\\n";
                if (spied == 2)
                {
                    dialog += "[emmQuest|Next]";
                }
                else
                    dialog += "[emmOther|Something else]";
            }
            else if (dialogDepth == 7)
            {
                dialog = "Here! This will help you help me in a more timely fashion! \\\"What are you doing? That is very valuable Emmilia!\\\" He has earned it!" +
                    "\\n[emmQuest1.5|Thank you my lady!]\\n[emmQuest1.5|(Take the compass)]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("emmQuest1.5"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        new Action("SetExpression({0}, sad)",true, emmilia),
                        SetDialog(SetAction())
                    },
                    changeState = () => { Inventory.instance.Add(tom, compass, compassDescription); dialogDepth = 8; }
                });
            }
            else if (dialogDepth == 8)
            {
                dialog = "I deserve to rule this kingdom. \\\"WE deserve to rule this kingdom.\\\" They called me mad! \\\"Mad witch!\\\" Shut up! I have had enough. Oh! you're still here. Good! It's time to put those two unwitting gouls out of their misery\\n";
                if (GameState.alchemySkill > 2)
                    dialog += "[emmQuest2|I'm all ears]";
                else
                    dialog += "(You need Alchemy skill of 3 or higher to proceed)\\n[leave|Leave]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("emmQuest2"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        new Action("SetExpression({0}, disgusted)",true, emmilia),
                        new EnableIcon("Brew", cauldronIcon, library+".Cauldron", true, "Brew"),
                        SetDialog(SetAction())
                    },
                    changeState = () => dialogDepth = 10
                });
            }
            else if (dialogDepth == 10)
            {
                dialog = "The red viper is the most potent poison in all the realsm. Gather a purple herb and brew a purple potion in the cauldron. The red viper is a complex mixture of rudimentary potions.\\n[leave|Leave]";
            }
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("emmQuest"),
                sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        new Action("SetExpression({0}, happy)",true, emmilia),
                        new SkillEarned(),
                        SetDialog(SetAction())
                    },
                changeState = () => dialogDepth = 7
            });
            return dialog;
        }
    }
}
