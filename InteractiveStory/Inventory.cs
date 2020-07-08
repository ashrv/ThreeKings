using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class Inventory
    {
        public static Inventory instance;
        public bool open;
        Dictionary<string, List<Item>> items;
        Dictionary<string, System.Func<string>> titles;
        public Inventory()
        {
            if (instance != null)
                throw new InvalidOperationException("Inventory has already been instantiated");
            instance = this;
            titles = new Dictionary<string, System.Func<string>>();
            titles.Add(tom, ()=>"You");
            titles.Add(dungeon + "." + chest, ()=>"Bottomless Chest");
            titles.Add(skills, ()=>"Skills "+GameState.skillPoints);
            items = new Dictionary<string, List<Item>>();
            items.Add(tom, new List<Item>());
            items.Add(dungeon+"."+chest, new List<Item>() { new Item(bread, ()=>breadDescription) });
            items.Add(skills, new List<Item>() {
                new Item(alchemySkill, ()=>"The ability to mix and brew rudimentary and complex potions\\nSkill Level:"+GameState.alchemySkill),
                new Item(swordSkill, ()=>"The ability to wield heavy weaponary and armour\\nSkill Level:"+GameState.swordSkill),
                new Item(magicSkill, ()=>"The ability to learn and cast novice and necromancy spells\\nSkill Level:"+GameState.magicSkill)
            });
        }

        internal void Remove(string owner, string item)
        {
            if (items.ContainsKey(owner))
                items[owner].RemoveAll(z => z.item == item);
        }

        public bool Contains(string owner, string item)
        {
            return items[owner].Any(z => z.item == item);
        }

        internal Sequence Show(string owner)
        {
            if (!open)
            {
                open = true;
                var sequence = new Sequence();
                sequence.Add(new Action("ClearList()", true));
                foreach (var item in items[owner])
                {
                    sequence.Add(new Action("AddToList({0}, {1})", item.item, item.description()));
                }
                var ownerEntity = owner == "Skills" ? tom : owner;
                sequence.Add(new Action("ShowList({0}, {1})", ownerEntity, titles[owner]()));
                return sequence;
            }
            return new Sequence();
        }

        internal Sequence Hide()
        {
            open = false;
            return new Sequence() { new Action("HideList()") };
        }

        internal void Add(string owner, string item, string description)
        {
            items[owner].Add(new Item(item, description));
        }

        class Item
        {
            public Item(string item, Func<string> description)
            {
                this.item = item;
                this.description = description;
            }

            public Item(string item, string description):this(item, () => description) { }

            public string item { get; set; }
            public Func<string> description { get; set; }
        }
    }
}
