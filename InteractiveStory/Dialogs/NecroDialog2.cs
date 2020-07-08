using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory.Dialogs
{
    public class NecroDialog2 : Dialog
    {
        static bool revivePlan;
        static int minimumDepth = 0;
        internal static int dialogDepth;
        public NecroDialog2()
        {
            if (revivePlan)
            {
                if (minimumDepth == 22)
                {
                    if (GameState.learntFireball)
                        dialogDepth = 12;
                    else
                        dialogDepth = 22;
                }
                else
                {
                    if (GameState.revived)
                        dialogDepth = 0;
                    else
                        dialogDepth = 12;
                }
            }
            else
            {
                if (minimumDepth == 22)
                {
                    if (GameState.learntFireball)
                        dialogDepth = 0;
                    else
                        dialogDepth = 22;
                }
                else
                    dialogDepth = 0;
            }
        }
        protected override string SetAction()
        {
            var dialog = "(...)\\n[fed|I fed your prisoners]\\n[prisoners|Who are the prisoners in the dungeon?]";
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("necroelse"),
                sequence = () => new Sequence()
                {
                    new Action("ClearDialog()"),
                    SetDialog(SetAction())
                },
                changeState = () => dialogDepth = 0
            });
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("hunger"),
                sequence = () => new Sequence()
                {
                    new Action("ClearDialog()"),
                    new Action("SetExpression({0}, angry)", necromancer),
                    SetDialog(SetAction())
                },
                changeState = () => dialogDepth = 21
            });

            if (dialogDepth == 0)
            {
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("fed"),
                    sequence = () => new SimpleDialog("Well then. Be on your way before I change my mind.")
                });
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("prisoners"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        SetDialog(SetAction())
                    },
                    changeState = () => dialogDepth = 1
                });

            }
            else if (dialogDepth == 1)
            {
                dialog = "I caught them trying to steal food from me! I was in a good mood that day, so I didn't execute them. Instead I'll leave them in my dungeon until they rot.\\n" +
                    "[feeding|But you're feeding them the food they were trying to steal]";
                if (GameState.necroState < 3 &&GameState.knowsAboutHunger)
                    dialog += "\\n[hunger|They said all people are starving in Lionheart's domain]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("feeding"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        SetDialog(SetAction())
                    },
                    changeState = () => dialogDepth = 2
                });
            }
            else if (dialogDepth == 2)
            {
                dialog = "How else would I keep them alive to suffer their sentence?\\n[necroelse|(Something else)]";
            }

            if (dialogDepth < 10||dialogDepth>=20)
            {
                if (GrandmaDialog.talkedTo && GameState.lionheartQuestState >= 2 && !GameState.revived)
                {
                    dialog += "\\n[revive1|I know the person your prisoners are looking for. I killed him]";
                    InputController.instance.Add(new InputController.Event()
                    {
                        input = Selected("revive1"),
                        sequence = () => new Sequence()
                        {
                            new Action("ClearDialog()"),
                            new Action("SetExpression({0}, happy)", necromancer),
                            new Action("PlaySound(laugh2)"),
                            SetDialog(SetAction())
                        },
                        changeState = () => dialogDepth = 10
                    });
                }
            }

            else if (dialogDepth == 10)
            {
                dialog = "Ha ha ha ha! You killed him? Indeed, you amuse me!\\n[necrolion|Lionheart told me he was a bandit]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("necrolion"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        new Action("SetExpression({0}, angry)", necromancer),
                        SetDialog(SetAction())
                    },
                    changeState = () =>
                    {
                        dialogDepth = 11;
                    }

                });
            }
            else if (dialogDepth == 11)
            {
                dialog = "That cunning rat! And you just followed his orders like a mindless minion. Using the book of spells, I shall resurrect him! That worthless fool doesn't deserve a win." +
                "\\n[book1|Book of spells?]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("revive2"),
                    sequence = () => new ReviveSequence(),
                    changeState = () => { GameState.revived = true; minimumDepth= minimumDepth == 22 ? 22 : 0; }
                });
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("book1"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        new EnableIcon("Take", evilBookIcon, library+".Bookcase", true, "Take"),
                        new Action("EnableEffect({0}, diamond)", library+".Bookcase"),
                        new Action("SetExpression({0})", necromancer),
                        SetDialog(SetAction())
                    },
                    changeState = () =>
                    {
                        dialogDepth = 12;
                        minimumDepth = Math.Max(minimumDepth, 12);
                        revivePlan = true;
                    }
                });
            }
            else if (dialogDepth == 12)
            {
                if (GameState.magicSkill < 2)
                    dialog = "You are not ready!\\n(Come back when you have a Magic skill of 2 or higher)";
                else if (!GameState.necroHasBook)
                    dialog = "The book of spells reside in Emmila's library. I would go and get it but I find any more bloodshed distasteful.";
                else
                    dialog = "Shall we proceed to resurrect the dead one?\\n[revive2|(Proceed)]";
                dialog += "\\n[necroelse|(Something else)]";
            }


            if (dialogDepth < 20)
            {
                dialog += "\\n[chest|Where is all that bread coming from in the dungeon?]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("chest"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        SetDialog(SetAction())
                    },
                    changeState = () => dialogDepth = 20
                });
            }
            if (dialogDepth == 20)
            {
                dialog = "You don't need to concern youself with that. As long as the spell persists, that chest will conjure more bread.\\n" +
                    "[necroelse|(Something else)]";
                if (GameState.necroState < 3&&GameState.knowsAboutHunger)
                    dialog += "\\n[hunger|You have unlimited amounts of food and Lionheart's people are starving]";
            }
            else if (dialogDepth == 21)
            {
                dialog = "Pff! Lionheart? He's but a tiny rat in a castle. You want to help the people in his domain? You bring me his head on a platter.\\n" +
                    "[necrohow|How would I do that? He is heavily guarded]";
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("necrohow"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        new Action("SetExpression({0})", necromancer),
                        SetDialog(SetAction())
                    },
                    changeState = () =>
                    {
                        dialogDepth = 22;
                        minimumDepth = 22;
                    }
                });
            }
            else if (dialogDepth == 22)
            {
                dialog = "Hmm... You're interested? I will teach you a powerful spell. It is up to you to find out how to use it. You kill Lionheart and Emmilia, and I will grant you enough power to rule under me.";
                if (GameState.magicSkill < 3)
                {
                    dialog += "\\n(You need Magic skill of 3 or more to learn this spell)\\n[necroelse|(Something else)]";
                }
                else
                {
                    dialog += "\\n[necrospell1|I'm listening]";
                }
                InputController.instance.Add(new InputController.Event()
                {
                    input = Selected("necrospell1"),
                    sequence = () => new Sequence()
                    {
                        new Action("ClearDialog()"),
                        new EnableIcon("Take", evilBookIcon, library+".Bookcase", true, "Take"),
                        new Action("EnableEffect({0}, diamond)", library+".Bookcase"),
                        new FireballTargets(),
                        SetDialog(SetAction())
                    },
                    changeState = () =>
                    {
                        dialogDepth = 23; GameState.necroState = 3;
                        GameState.learntFireball = GameState.necroHasBook ? true : false;
                    }
                });
            }
            else if (dialogDepth == 23)
            {
                if (GameState.necroHasBook)
                    dialog = "Ah there it is! This spell gives you the power to conjure fire orbs. No doubt that will prove useful to carry out your objective.\\n";
                else
                    dialog = "Bring me the book of spells and I will teach you. Unfortunately, the book was left in Emmila's library. I would go and get it but I find any more bloodshed distasteful.\\n";
                dialog += "[necroelse|(Something else)]";
            }

            dialog += "\\n[leave|Leave]";
            return dialog + "\\n[dungeon|(Go to the dungeon)]";
        }
    }
}
