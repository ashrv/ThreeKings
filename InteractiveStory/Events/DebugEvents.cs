using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.InputController;
using static InteractiveStory.Constants;
using InteractiveStory.Dialogs;

namespace InteractiveStory
{
    public class DebugEvents : List<Event>
    {
        public DebugEvents()
        {
            Add(new Event()
            {
                input = "input Ending " + compass,
                sequence = () => new Sequence()
                {

                },
                changeState = () => { GameState.lionheartDead = true;GameState.emmiliaDead = true;GameState.necroDead = true; }

            });
            Add(new Event()
            {
                input = "input Lionheart " + compass,
                sequence = () => new Sequence()
                {

                },
                changeState = () => { GameState.lionheartQuestState = 5; }

            });
            Add(new Event()
            {
                input = "input Library " + compass,
                sequence = () => new Sequence()
                 {
                    new SetPosition(emmilia, library),
                     new SetPosition(tom, library)
                 },
                changeState = () => { NecroDialog.dialogDepth = 10;LionheartDialog.dialogDepth = 2; Inventory.instance.Add(tom, bag,""); }
            });
            Add(new Event()
            {
                input = "input Emmilia " + compass,
                sequence = () => new Sequence()
                {

                },
                changeState = () => { GameState.necroDead = true; GameState.lionheartDead = true; }
            });
            Add(new Event()
            {
                input = "input Castle " + compass,
                sequence = () => new Sequence()
                 {
                    new SetPosition(blacksmith, blacksmithshop+".Chest"),
                     new SetPosition(tom, castle+".Supplicant")
                 }
            });
            Add(new Event()
            {
                input = "input Path " + compass,
                sequence = () => new Sequence()
                 {
                     new SetPosition(tom, path)
                 }
            });
            Add(new Event()
            {
                input = "input Dungeon " + compass,
                sequence = () => new Sequence()
                 {
                     new SetPosition(tom, dungeon)
                 }
            });
            Add(new Event()
            {
                input = "input Ruins " + compass,
                sequence = () => new Sequence()
                 {
                     new SetPosition(tom, ruins+".Altar")
                 }
            });
            Add(new Event()
            {
                input = "input Sword " + compass,
                sequence = () => new Sequence()
                 {
                    new EnableIcon("Attack", swordType, bandit, false,"Kill")
                 },
                changeState=()=>Inventory.instance.Add(tom, sword, "")
            });
            Add(new Event()
            {
                input = "input King " + compass,
                sequence = () => new Sequence()
                 {
                 },
                changeState = () => GameState.lionheartQuestState=2
            });
            Add(new Event()
            {
                input = "input Necro " + compass,
                sequence = () => new Sequence()
                {
                    new Action("Die({0})", bandit),
                },
                changeState = () =>
                {
                    GameState.necroState = 4;
                }
            });
            Add(new Event()
            {
                input = "input Storage " + compass,
                sequence = () => new Sequence()
                {
                    new SetPosition(tom, storage)
                }
            });
            Add(new Event()
            {
                input = "input Fireball " + compass,
                sequence = () => new Sequence()
                {
                    new FireballTargets()
                },
                changeState = () => GameState.learntFireball = true
            });
        }
    }
}
