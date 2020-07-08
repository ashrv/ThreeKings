using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.InputController;
using static InteractiveStory.Constants;
using System.Configuration;

namespace InteractiveStory.Events
{
    public class NecromancerEvents:List<Event>
    {
        public NecromancerEvents()
        {
            Add(new Event()
            {
                input = "input Open " + dungeon + ".Chest",
                sequence = () => new ChestSequence(dungeon + ".Chest"),
            });
            Add(new Event()
            {
                input = "input Give " + necromancer,
                sequence = () => new Sequence()
                {
                    new Action("WalkTo({0}, {1})", tom, necromancer),
                    new Action("DisableInput()"),
                    new DisableIcon("Give", necromancer),
                    new Action("Give({0}, {1}, {2})",true, tom, spellBook, necromancer),
                    new Action("Pocket({0}, {1})", necromancer, spellBook),
                    new Action("EnableInput()")
                },
                changeState = () => GameState.necroHasBook = true
            });
            Add(new Event()
            {
                input = "input Give " + grandma,
                sequence = () => new Sequence()
                {
                    new Action("DisableInput()"),
                    new DisableIcon("Give", grandma),
                    new Action("WalkTo({0}, {1})",true, tom,dungeon+".CellDoor"),
                    new Action("Put({0}, {1}, {2})", tom, bread, dungeon+".CellDoor"),
                    new Action("Take({0}, {1}, {2})",true, grandma, bread, dungeon+".CellDoor"),
                    new SkillEarned(),
                    new Action("Put({0}, {1}, {2})", true, grandma, bread, dungeon+".RoundTable"),
                    new Action("WalkTo({0}, {1})", grandma, dungeon+".CellDoor"),
                    new Action("EnableInput()")
                },
                condition=()=>Inventory.instance.Contains(tom, bread)&&GameState.necroState==0,
                changeState = () => { GameState.necroState = 1; Inventory.instance.Remove(tom, bread); }
            });
            Add(new Event()
            {
                input = "input Burn " + lionheart,
                sequence = () => new Narration("I'll risk getting caught by his guards. I have to find another way. The castle storage maybe?")
            });
            Add(new Event()
            {
                input = "input Poison " + lionheart,
                sequence = () => new Narration("I can't just feed it to him! I gotta find another way. The castle storage maybe?")
            });
            Add(new Event()
            {
                input = "input Poison " + lionheart,
                sequence = () => new Narration("I can't just feed it to him! I gotta find another way. Where does he get his food from?")
            });
            Add(new Event()
            {
                input = "input Burn " + storage + ".Barrel",
                sequence = () => new Sequence()
                {
                    new Action("DisableEffect({0}, diamond)", storage + ".Barrel"),
                    new Action("PlaySound(danger1, {0})",storage),
                    new CastSequence(storage+".Barrel"),
                    new LionheartDeath(),
                    new EnableIcon("BurntCastle", magnifierIcon, courtyard+".Gate", true, "The castle suffered an explosion that killed anyone inside"),
                    new EscapeSequence(courtyard),
                    new Action("StopSound()")
                }.Add(GameState.necroDead && GameState.emmiliaDead && GameState.lionheartDead ? new SecretEndingSequence() : new Sequence()),
                changeState = () =>
                {
                    GameState.lionheartDead = true;
                    if (GameState.emmiliaDead)
                        GameState.necroState = 4;
                }
            });
            Add(new Event()
            {
                input = "input Burn " + bandit,
                sequence = () => new Sequence()
                {
                    new CastSequence(bandit),
                    new Action("Die({0})", bandit),
                    new DisableIcon("Talk", bandit),
                    new DisableIcon("Attack", bandit),
                    new DisableIcon("Burn", bandit),
                    new Action("DisableEffect({0})", bandit)
                },
                changeState = () => GameState.lionheartQuestState = 2
            });
            Add(new Event()
            {
                input = "input Burn " + emmilia,
                sequence = () => new Sequence()
                {
                    new Action("StopSound({0})", library),
                    new Action("PlaySound(danger2, {0})", library),
                    new CastSequence(library+".Cauldron"),
                    new DisableIcon("Talk", emmilia),
                    new Action("EnableEffect({0}, wildfire)", library+".SpellBook"),
                    new Action("EnableEffect({0}, wildfire)", library+".AlchemistTable"),
                    new Wait(1f),
                    new Action("SetExpression({0}, scared)",true, emmilia),
                    new EmmiliaDeathDialog().Generate(emmilia,otherOnly:true)
                }
            });
            Add(new Event()
            {
                input = "input Burn " + necromancer,
                sequence = () => new Sequence()
                {
                    new Action("DisableInput()"),
                    new Action("Cast({0}, {1})",true, tom, necromancer),
                    new Action("PlaySound(laugh2)"),
                    new Action("EnableInput()")
                }
            });
        }
    }
}
