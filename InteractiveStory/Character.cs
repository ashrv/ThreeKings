using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class Character
    {
        public string name { get; set; }
        public string type { get; set; }
        public EyeColors eyeColor { get; set; }
        public Beards beard { get; set; }
        public HairColors hairColor { get; set; }
        public Outfits outfit { get; set; }
        public HairStyles hairStyle { get; set; }

        public Character()
        {
            type = "B";
            beard = Beards.SHAVED;
            eyeColor = EyeColors.BROWN;
            hairColor = HairColors.BLACK;
        }

        public enum EyeColors
        {
            RED = 0, WHITE = 1, BLACK = 2, GREEN = 3, BLUE = 4, BROWN = 5
        }

        public enum HairColors
        {
            RED = 0, BLONDE = 1, BLACK = 2, BROWN = 3, GRAY = 4
        }

        public enum Beards
        {
            MUSKETEER_BEARD,
            MUSKETEER_FULL,
            MAGE_BEARD,
            SHORT_BEARD,
            SHORT_FULL,
            MAGE_FULL,
            SHAVED
        }

        public enum HairStyles
        {
            BALD,
            BUN,
            STRAIGHT,
            SHORT,
            LONG,
            SPIKY,
            PONYTAIL,
            MAGE,
            MUSKETEER,
        }

        public enum Outfits
        {
            BEGGAR,
            PEASANT,
            HEAVYARMOUR,
            LIGHTARMOUR,
            NAKED,
            NOBLE,
            MERCHANT,
            PRIEST,
            QUEEN,
            KING,
            WITCH,
            WARLOCK,
            BANDIT
        }
    }
}
