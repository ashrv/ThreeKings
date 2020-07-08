using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class StarterSequence : Sequence
    {
        public StarterSequence()
        {
            Add("SetTitle(The Three Kings)");

            foreach (var character in Characters.instance)
            {
                AddRange(new CreateCharacterSequence(character));
            }
            
            Add("CreatePlace({0}, {1})", blacksmithshop, blacksmithshop);

            Add("CreatePlace({0}, {1})", true, castle, castle);
            Add("SetPosition({0}, {1})",true, lionheart, castle + ".Throne");
            Add("Sit({0}, {1})", lionheart, castle + ".Throne");

            Add("CreatePlace({0}, {1})", courtyard, courtyard);

            Add("CreatePlace({0}, {1})",true, crossroads, crossroads);
            Add("SetPosition({0}, {1})", tom, crossroads);
            Add(new SetPosition(blacksmith, blacksmithshop, "Chest"));
            Add("SetPosition({0}, {1})", guard1, crossroads + ".WestEnd");
            Add("SetPosition({0}, {1})", guard2, crossroads + ".EastEnd");

            Add("CreatePlace({0}, {1})",true, dungeon, dungeon);
            Add("SetPosition({0}, {1})", child, dungeon + ".Bed");
            Add("SetPosition({0}, {1})", grandma, dungeon + ".CellDoor.Inside");

            Add("CreatePlace({0}, {1})",true, library, library);
            Add("SetPosition({0}, {1})",true, emmilia, library + ".Cauldron");
            Add("Face({0}, {1})", emmilia, library + ".Cauldron");

            Add("CreatePlace({0}, {1})",true, path, path);
            Add("SetPosition({0}, {1})", bandit, path + ".Well");

            Add("CreatePlace({0}, {1})", ruins, ruins);
            Add("SetPosition({0}, {1})",true, necromancer, ruins + ".Throne");
            Add("Sit({0}, {1})", necromancer, ruins + ".Throne");

            Add("CreatePlace({0}, {1})",true, storage, storage);

            Add("SetExpression({0}, sad)", grandma);
            foreach (var place in Places.instance)
            {
                foreach (var portal in place.portals)
                {
                    var action = portal.EnableIcon();
                    if (action != null)
                        Add(action);
                }
            }

            Add(CreateItem(compass, compassType),true);
            Add(new EnableIcon("Touch", handIcon, compass, false, "Touch the glass"));
            Add(CreateItem(scroll, scrollOpenType), true);
            Add(new SetPosition(scroll, dungeon, "Bookshelf"));
            Add(new EnableIcon("Inspect", magnifierIcon, scroll, true, "Inspect"));
            Add(CreateItem(spellBook, spellBookType));
            Add(CreateItem(swordBandit, swordType));
            Add(CreateItem(swordSkill, blueBookType),true);
            Add(new EnableIcon("Upgrade", researchIcon, swordSkill, false, "Use 1 Skill point to upgrade"));
            Add(CreateItem(alchemySkill, spellBookType),true);
            Add(new EnableIcon("Upgrade", researchIcon, alchemySkill, false, "Use 1 Skill point to upgrade"));
            Add(CreateItem(magicSkill, evilBookType),true);
            Add(new EnableIcon("Upgrade", researchIcon, magicSkill, false, "Use 1 Skill point to upgrade"));


            Add(CreateItem(sword, swordType), true);
            Add(new EnableIcon("Take", handIcon, sword, true, "Take"));
            Add(CreateItem(armour, helmetType),true);
            Add(new EnableIcon("Wear", armourIcon, armour, true, "Armour up"));

            Add(CreateItem(bread, breadType), true);
            Add(new EnableIcon("Take", handIcon, bread, true, "Take"));

            Add(CreateItem(hammer, hammerType), true);
            Add(new SetPosition(hammer, blacksmithshop, "Table", "FrontLeft"));
            Add(new EnableIcon("Inspect", handIcon, hammer, true, "Inspect"));
            
            Add(CreateItem(helmet, helmetType), true);
            Add(new SetPosition(helmet, blacksmithshop, "Table", "FrontRight"));
            Add(new EnableIcon("Inspect", handIcon, helmet, true, "Inspect"));

            Add(CreateItem(bluePotion, bluePotionType),true);
            Add(new EnableIcon("Combine", potionIcon, bluePotion, false, "Combine two potions"));
            Add(CreateItem(redPotion, redPotionType));
            Add(CreateItem(greenPotion, greenPotionType),true);
            Add(new EnableIcon("Combine", potionIcon, greenPotion, false, "Combine two potions"));

            Add(CreateItem(purplePotion, purplePotionType), true);
            Add(new EnableIcon("Combine", potionIcon, purplePotion, false, "Combine two potions"));

            Add(CreateItem(bag, bagType));
            Add(new EnableIcon("Inspect", magnifierIcon, courtyard + ".Horse", true, "Inspect"));
            Add(new EnableIcon("Inspect", magnifierIcon, library + ".Cauldron", true, "Inspect"));
            Add(new EnableIcon("Inspect", magnifierIcon, courtyard + ".Target", true, "Inspect"));
            Add(new EnableIcon("Inspect", magnifierIcon, blacksmithshop + ".Target", true, "Inspect"));
            Add(new EnableIcon("Inspect", magnifierIcon, storage + ".Barrel", true, "Inspect"));
            Add(new EnableIcon("Inspect", magnifierIcon, courtyard + ".Fountain", true, "Inspect"));
            Add(new EnableIcon("Inspect", magnifierIcon, ruins + ".Plant", true, "Inspect"));
            Add(new EnableIcon("Inspect", magnifierIcon, path + ".Plant", true, "Inspect"));
            Add(new EnableIcon("Take", plantIcon, ruins + ".Plant", true, "Take"));
            Add(new EnableIcon("Take", plantIcon, path + ".Plant", true, "Take"));
            Add(new EnableIcon("Inspect", magnifierIcon, library + ".Bookcase", true, "Inspect"));
            Add(new EnableIcon("Inspect", magnifierIcon, library + ".Bookcase3", true, "Inspect"));
            Add(new EnableIcon("Inspect", magnifierIcon, library + ".Bookcase2", true, "Inspect"));
            Add(new EnableIcon("Inspect", magnifierIcon, bandit, true, "Inspect"));
            Add(new EnableIcon("Inspect", magnifierIcon, storage+".Chest", true, "Inspect"));
            Add(new EnableIcon("Talk", talkIcon, lionheart, true, "Talk"));
            Add(new EnableIcon("Talk", talkIcon, blacksmith, true, "Talk"));
            Add(new EnableIcon("Talk", talkIcon, necromancer, true, "Talk"));
            Add(new EnableIcon("Talk", talkIcon, grandma, true, "Talk"));
            Add(new EnableIcon("Talk", talkIcon, emmilia, true, "Talk"));
            Add(new EnableIcon("Talk", talkIcon, bandit, false, "Talk"));
            Add(new EnableIcon("Open", chestIcon, dungeon + ".Chest", true, "Open Chest"));

            Add(new EnableIcon("Sit", chairIcon, courtyard + ".RightBench", true, "Take a moment of peace"));

            Add(HideFurniture(blacksmithshop, "BackDoor"));
            Add(HideFurniture(blacksmithshop, "Chest"));
            Add(HideFurniture(courtyard, "SmallStall"));
            Add(HideFurniture(courtyard, "BigStall"));
            Add(HideFurniture(courtyard, "LeftBench"));
            Add(HideFurniture(courtyard, "Barrel"));
            Add(HideFurniture(castle, "BasementDoor"));
            Add(HideFurniture(castle, "Table"));
            Add(HideFurniture(dungeon, "Table"));
            Add(HideFurniture(dungeon, "Chair"));
            Add(HideFurniture(dungeon, "DirtPile"));
            Add(HideFurniture(ruins, "DirtPile"));
            Add(HideFurniture(path, "DirtPile"));
            Add(HideFurniture(storage, "Shelf"));
            Add(HideFurniture(library, "Table"));
            Add(HideFurniture(library, "Chair"));
            Add(HideFurniture(ruins, "Altar"));
            Add(HideFurniture(path, "Well"));
            Add(HideFurniture(ruins, "Chest"));

            Add(new EnableIcon("Talk", talkIcon, guard1, true, "Talk"));
            Add(new EnableIcon("Talk", talkIcon, guard2, true, "Talk"));
            //debugging
#if DEBUG
            Inventory.instance.Add(tom, compass, compassDescription);
            //////Add(new EnableIcon("Fireball", handIcon, compass, false, "Fireball"));
            ////Add(new EnableIcon("Necro", handIcon, compass, false, "Necro"));
            Add(new EnableIcon("Library", handIcon, compass, false, "Library"));
            Add(new EnableIcon("Castle", handIcon, compass, false, "Castle"));
            //////Add(new EnableIcon("Lionheart", handIcon, compass, false, "Lionheart"));
            Add(new EnableIcon("Ruins", handIcon, compass, false, "Ruins"));
            ////Add(new EnableIcon("Ending", handIcon, compass, false, "Ending"));
            Add(new EnableIcon("Storage", handIcon, compass, false, "Storage"));
            ////Add(new EnableIcon("Emmilia", handIcon, compass, false, "Emmilia"));
            ////Add(new EnableIcon("Dungeon", handIcon, compass, false, "Dungeon"));
            Add(new EnableIcon("Path", handIcon, compass, false, "Path"));
            //Add(new EnableIcon("King", handIcon, compass, false, "King"));
#endif
            //end debugging

            Add("FadeOut");
            Add("ShowMenu()");
        }

        private string CreateItem(string name, string type)
        {
            return string.Format("CreateItem({0}, {1})", name, type);
        }

        public string HideFurniture(string place, string furniture)
        {
            return string.Format("HideFurniture({0})", place + "." + furniture);
        }
    }
}
