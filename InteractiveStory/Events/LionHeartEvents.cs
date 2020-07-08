using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.InputController;
using static InteractiveStory.Constants;
using InteractiveStory.Dialogs;

namespace InteractiveStory.Events
{
    public class LionHeartEvents:List<Event>
    {
        public LionHeartEvents()
        {
            Add(new Event()
            {
                inputs = new List<string>()
                    {
                        "input arrived "+tom+" position "+guard1,
                        "input arrived "+tom+" position "+guard2,
                    },
                condition = () => !Portal.setup,
                sequence = () => new Sequence(){
                    new GuardDialog().Generate(guard2),
                    new Action("EnableEffect({0}, diamond)", crossroads+".Gate") 
                }
            });
            Add(new Event()
            {
                input = "input Put " + blacksmithshop + ".Anvil",
                condition=()=>Inventory.instance.Contains(tom, hammer),
                changeState=()=>
                {
                    Inventory.instance.Remove(tom, hammer);
                    BlacksmithDialog.forgedSword = true;
                },
                sequence = () => new Sequence() { new EnableIcon("Take", handIcon, sword, true, "Take") }.Add(new ForgeSequence(hammer, sword))
            });
            Add(new Event()
            {
                input = "input Put " + blacksmithshop + ".Anvil",
                condition = () => Inventory.instance.Contains(tom, helmet),
                changeState = () =>
                {
                    Inventory.instance.Remove(tom, helmet);
                    BlacksmithDialog.forgedHelm = true;
                },
                sequence = () => new ForgeSequence(helmet, armour).Add(new Sequence() { new DisableIcon("Take", helmet)})
            });
            Add(new Event()
            {
                input = "input Wear " + armour,
                changeState = () => { GameState.lionheartQuestState = 4; LionheartDialog2.dialogDepth = 3; },
                sequence = () => new Sequence()
                {
                    new Action("DisableInput()"),
                    new Action("FadeOut()", true),
                    new Action("SetClothing({0}, HeavyArmour)",true, tom),
                    new EnableIcon("Attack", swordType, emmilia, false, "Kill"),
                    new EnableIcon("Attack", swordType, necromancer, false, "Kill"),
                    new SetPosition(necromancer, ruins, "Altar"),
                    new Action("FadeIn()"),
                    new Action("EnableInput()")
                }
            });
            Add(new Event()
            {
                input = "input Attack " + necromancer,
                sequence = () => new Sequence()
                {
                    new Action("StopSound({0})", ruins),
                    new Action("PlaySound(danger1, {0})",ruins),
                    new DieSequence(necromancer),
                    new NecroAttackDialog().Generate(necromancer),
                    new Action("EnableInput()"),
                    new Action("StopSound()")
                },
                changeState = () => { 
                    GameState.necroDead = true; 
                    if (GameState.emmiliaDead) 
                        GameState.lionheartQuestState = 5;
               }
            });
            Add(new Event()
            {
                input = "input Attack " + emmilia,
                sequence = () => new Sequence()
                {
                    new Action("StopSound({0})", library),
                    new Action("PlaySound(danger1, {0})",library),
                    new DieSequence(emmilia),
                    new EmmiliaAttackDialog().Generate(emmilia),
                },
                changeState = () => { GameState.emmiliaDead = true; 
                    if (GameState.necroDead) 
                        GameState.lionheartQuestState = 5;
                    if (GameState.lionheartDead)
                        GameState.necroState = 4;
                }
            });
            Add(new Event()
            {
                input = "input Practice " + blacksmithshop + ".Target",
                sequence = () => new Sequence()
                    {
                        new Action("DisableInput()", true),
                        new Action("Draw({0}, {1}", true, tom, sword),
                        new Action("Bash({0}, {1})", true, tom, blacksmithshop+".Target"),
                        new Action("Sheathe({0}, {1})", true, tom, sword),
                        new Action("EnableInput()")
                    }
            });
            Add(new Event()
            {
                input = "input Practice " + courtyard + ".Target",
                sequence = () => new Sequence()
                    {
                        new Action("DisableInput()", true),
                        new Action("Draw({0}, {1}", true, tom, sword),
                        new Action("Bash({0}, {1})", true, tom, courtyard+".Target"),
                        new Action("Sheathe({0}, {1})", true, tom, sword),
                        new Action("EnableInput()")
                    }
            });
            Add(new Event()
            {
                input = "input Practice2 " + blacksmithshop + ".Target",
                sequence = () => new Sequence()
                    {
                        new Action("DisableInput()", true),
                        new Action("Cast({0}, {1})", true, tom, blacksmithshop+".Target"),
                        new Action("EnableInput()")
                    }
            });
            Add(new Event()
            {
                input = "input Practice2 " + courtyard + ".Target",
                sequence = () => new Sequence()
                    {
                        new Action("DisableInput()", true),
                        new Action("Cast({0}, {1})", true, tom, courtyard+".Target"),
                        new Action("EnableInput()")
                    }
            });
            Add(new Event()
            {
                input = "input Attack " + bandit,
                condition=()=>Inventory.instance.Contains(tom, sword),
                sequence = () => new Sequence()
                {
                    new DieSequence(bandit),
                    new SkillEarned(),
                    new Action("EnableInput()")
                },
                changeState=()=>GameState.lionheartQuestState=2
            }) ;
            Add(new Event()
            {
                input = "input Attack " + lionheart,
                sequence = () => new Narration("(You require swordsmanship 10 to overpower " + lionheart + ")")
            });
        }
    }
}
