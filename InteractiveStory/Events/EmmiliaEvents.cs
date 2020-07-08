using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.InputController;
using static InteractiveStory.Constants;
using InteractiveStory.Sequences;

namespace InteractiveStory.Events
{
    public class EmmiliaEvents : List<Event>
    {
        public EmmiliaEvents()
        {
            Add(new Event()
            {
                input = "input Brew " + library + ".Cauldron",
                sequence = () => new Sequence()
                {
                    new Action("WalkTo({0}, {1})",true, tom, library+".Cauldron"),
                    new Action("DisableInput()"),
                    new Action("Put({0}, {1}, {2})",true, tom, bag, library+".Cauldron"),
                    new Action("PlaySound(brew, {0})", library+".Cauldron"),
                    new Action("CreateEffect({0}, brew)", library+".Cauldron"),
                    new Wait(4f),
                    new Action("Take({0}, {1}, {2})",true, tom, purplePotion, library+".Cauldron"),
                    new Action("Pocket({0}, {1})",true, tom, purplePotion),
                    new DisableIcon("Take", path+".Plant"),
                    new DisableIcon("Take", ruins+".Plant"),
                    new Action("EnableInput()")
                },
                changeState = () =>
                  {
                      Inventory.instance.Add(tom, purplePotion, purplePotionDescription);
                      Inventory.instance.Remove(tom, bag);
                  },
                condition = () => Inventory.instance.Contains(tom, bag)
            });
            Add(new Event()
            {
                input = "input Brew " + library + ".Cauldron",
                sequence = () => new Narration("I need a special kind of purple flowers to start brewing"),
                condition = () => !Inventory.instance.Contains(tom, bag)
            });
            Add(new Event()
            {
                input = "input Poison " + emmilia,
                sequence = () => new Narration("Pointless! She's immune to all types of poison")
            });
            Add(new Event()
            {
                input = "input Poison " + dungeon + ".Chest",
                sequence = () =>new Sequence(){
                    new Action("DisableEffect({0}, diamond)", dungeon + ".Chest"),
                    new Action("StopSound({0})", dungeon),
                    new Action("PlaySound(danger1, {0})",dungeon),
                    new PoisonSequence(dungeon + ".Chest", path) ,
                    new NecroDeath() ,
                    new Action("StopSound()")
                }.Add(GameState.necroDead && GameState.emmiliaDead && GameState.lionheartDead ? new SecretEndingSequence() : new Sequence()),
                changeState = () => { 
                    GameState.necroDead = true;
                    if (GameState.emmiliaDead)
                        GameState.lionheartQuestState = 5;
                }
            });
            Add(new Event()
            {
                input = "input Poison " + storage + ".Chest",
                sequence = () => new Sequence(){
                    new Action("DisableEffect({0}, diamond)", storage + ".Chest"),
                    new Action("PlaySound(danger1, {0})",storage),
                    new PoisonSequence(storage + ".Chest", courtyard),
                    new LionheartDeath(),
                    new EnableIcon("DeadKing", magnifierIcon, courtyard+".Gate", true, "Inspect"),
                    new Action("StopSound()")
                }.Add(GameState.necroDead&&GameState.emmiliaDead&&GameState.lionheartDead?new SecretEndingSequence():new Sequence()),
                changeState = () => { 
                    GameState.lionheartDead = true;
                    if (GameState.emmiliaDead)
                        GameState.necroState = 4;
                }
            });
        }
    }
}
