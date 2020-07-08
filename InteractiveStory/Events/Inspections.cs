using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.InputController;
using static InteractiveStory.Constants;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics.Eventing.Reader;

namespace InteractiveStory.Events
{
    public class Inspections:List<Event>
    {
        public Inspections()
        {
            Add(new Event()
            {
                input = "input Inspect " + library + ".Bookcase",
                sequence = () => new Narration(GameState.magicSkill > 2 ? "A book of spells featuring dark magic and necromancy":
                  "A strange book written in an unknown language (You need Magic skill of 3 or higher to read this)")
            });
            Add(new Event()
            {
                input = "input Inspect " + library + ".Bookcase2",
                sequence = () => new Narration(GameState.alchemySkill>2 ? "Purple potions x 2 = Blue potion\\nPurple potion + Blue potion = Green potion\\n" +
                  "Blue potion + Green potion = Red Viper" : "Some excerpts about mixology and potions (You need Alchemy skill of 3 or higher to read this)")
            });
            Add(new Event()
            {
                input = "input Inspect " + library + ".Bookcase3",
                sequence = () => new Narration("All about potions and constellations and chemistry and moon phases and so on")
            });
            Add(new Event()
            {
                input = "input Inspect " + hammer,
                sequence = () => new Narration("Sturdy-looking hammer, but I don't need to take it right now"),
                condition = () => GameState.lionheartQuestState == 0,
            
            });
            Add(new Event()
            {
                input = "input Inspect " + scroll,
                sequence = () => new Narration("\"Day 4068\\n" + "More complaints about wild animal attacks from the woodsman family.\\n" +
                  "I had it with their nagging and whining, so I burnt their tiny wood house down,\\n" +
                  "and put them all in large stone houses I had conjured many moons ago.\\n" +
                  "That will teach them a lesson to stop bothering me." +
                  "Day 4071\\n" +
                  "I had to burn down all the farms in my domain today.\\n" +
                  "Though I take joy in igniting flames, I forsaw locusts. Burning the crops were the fastest route to clear the farms for my nourishment spell.\\n" +
                  "[Sounds like two entries from " + necromancer + "'s diary!]\"")
            });
            Add(new Event()
            {
                input = "input Inspect " + library + ".Cauldron",
                sequence = () => new Narration("A large black cauldron to mix and brew all kinds of potions, I assume!")
            });
            Add(new Event()
            {
                input = "input Inspect " + helmet,
                sequence = () => new Narration("An uncanny helmet engraved with runes, but I don't need to take it right now"),
           
            });
            Add(new Event()
            {
                input = "input Inspect " + courtyard + ".Fountain",
                sequence = () => new Narration("The fountain has a strange mystical feeling to it"),
            });
            Add(new Event()
            {
                inputs = new List<string>() { "input Inspect " + ruins + ".Plant", "input Inspect " + path + ".Plant" },
                sequence = () => new Narration("A strange-looking purple flower. It's probably an ingredient to some potion")
            });
            Add(new Event()
            {
                input = "input BurntCastle "+courtyard+".Gate",
                sequence = () => new Narration("The castle suffered an explosion that killed anyone inside")
            });
            Add(new Event()
            {
                input = "input DeadKing "+courtyard+".Gate",
                sequence = () => new Narration("The king gave in to a sudden and fatal illness")
            });
            Add(new Event()
            {
                input = "input Inspect " + courtyard + ".Horse",
                sequence = () => new Narration("I can travel faster using a horse after I've visited more places")
            });
            Add(new Event()
            {
                input = "input Inspect " + storage + ".Barrel",
                sequence = () => new Narration("A few barrels containing highly flamable oils. Quite hazardous.")
            });
            Add(new Event()
            {
                input = "input Inspect " + storage + ".Chest",
                sequence = () => new Narration("A stash of spices that most likely add flavor to royal dishes.")
            });
            Add(new Event()
            {
                input = "input Inspect " + courtyard + ".Target",
                sequence = () => new Narration("I can practive my skills here when I learn more")
            });
            Add(new Event()
            {
                input = "input Inspect " + blacksmithshop + ".Target",
                sequence = () => new Narration("I can practive my skills here when I learn more")
            });
            Add(new Event()
            {
                input = "input Inspect " + bandit,
                sequence = () => new Narration("This is the bandit that Lionheart was talking about")
            });
        }
    }
}
