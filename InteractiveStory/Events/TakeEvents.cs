using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.InputController;
using static InteractiveStory.Constants;

namespace InteractiveStory.Events
{
    public class TakeEvents:List<Event>
    {
        public TakeEvents()
        {
            Add(new Event()
            {
                input = "input Take " + hammer,
                sequence = () => new TakeSequence(hammer).Add(new Sequence()
                {
                    new EnableIcon("Put", forgeIcon, blacksmithshop+".Anvil", true, "Put the hammer on the anvil")
                }),
                changeState = () => Inventory.instance.Add(tom, hammer, hammerDescription)
            }) ;
            Add(new Event()
            {
                input = "input Take " + sword,
                sequence = ()=>new TakeSequence(sword).Add(new Sequence()
                {
                    new EnableIcon("Attack", swordIcon,bandit, false, "Kill the bandit"),
                    new EnableIcon("Practice", swordsIcon, blacksmithshop+".Target", false, "Practice swordmanship"),
                    new EnableIcon("Practice", swordsIcon, courtyard+".Target", false, "Practice swordmanship"),
                }),
                changeState = () => Inventory.instance.Add(tom, sword, swordDescription)
            });
            Add(new Event()
            {
                input = "input Take " + bread,
                sequence = () => new TakeSequence(bread, dungeon + ".Chest")
                .Add(new Sequence() { 
                    new EnableIcon("Give", breadIcon, grandma, false, "Give"),
                    new DisableIcon("Open", dungeon+".Chest")
                }),
                changeState = () => Inventory.instance.Add(tom, bread, breadDescription),
                condition = () => GameState.necroState == 0 && !Inventory.instance.Contains(tom, bread)
            });
            Add(new Event()
            {
                input = "input Take " + ruins + ".Plant",
                sequence=()=>new TakeSequence(bag, ruins+".Plant",false),
                changeState=()=> Inventory.instance.Add(tom, bag, "Some strange purple herbs with a floral scent"),
                condition=()=>!Inventory.instance.Contains(tom, bag)
            });
            Add(new Event()
            {
                input = "input Take " + path + ".Plant",
                sequence = () => new TakeSequence(bag, path + ".Plant",false),
                changeState = () => Inventory.instance.Add(tom, bag, "Some strange purple herbs with a floral scent"),
                condition = () => !Inventory.instance.Contains(tom, bag)
            });
            Add(new Event()
            {
                inputs=new List<string>() { "input Take " + ruins + ".Plant", "input Take " + path + ".Plant" },
                sequence = () => new Narration("I already have some"),
                condition = () => Inventory.instance.Contains(tom, bag)
            });
            Add(new Event()
            {
                input = "input Take " + library + ".Bookcase",
                sequence = () => new Sequence()
                {
                    new TakeSequence(spellBook, library+".Bookcase", false),
                    new DisableIcon("Take", library+".Bookcase"),
                    new Action("DisableEffect({0}, diamond)", lionheart+".Bookcase"),
                    new EnableIcon("Give", evilBookIcon, necromancer, false, "Give")
                },
                changeState = () => Inventory.instance.Add(tom, spellBook, "A book of spells written in an unknown language")
            });
            Add(new Event()
            {
                input = "input Take " + bread,
                sequence = () => new Narration("I don't need to take any more"),
                condition = () => Inventory.instance.Contains(tom, bread)
            });
            Add(new Event()
            {
                input = "input Take " + helmet,
                sequence = () => new TakeSequence(helmet).Add(new Sequence()
                {
                    new EnableIcon("Put", forgeIcon, blacksmithshop+".Anvil", true, "Put")
                }),
                changeState = () => Inventory.instance.Add(tom, helmet, helmetDescription)
            });
        }
    }
}
