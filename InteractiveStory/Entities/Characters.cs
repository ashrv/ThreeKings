using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class Characters : List<Character>
    {
        public static Characters instance;
        public Characters()
        {
            if (instance != null)
                throw new InvalidOperationException("Characters has already been instantiated");
            instance = this;

            AddRange(new List<Character>(){
                new Character()
                {
                    type= "D",
                    name = Constants.tom,
                    outfit = Character.Outfits.LIGHTARMOUR,
                    hairStyle = Character.HairStyles.SHORT
                },
                new Character()
                {
                    type= "D",
                    name = Constants.bob,
                    outfit = Character.Outfits.BANDIT,
                    eyeColor= Character.EyeColors.BLACK
                },
                new Character()
                {
                    name = Constants.lionheart,
                        outfit = Character.Outfits.KING,
                        eyeColor = Character.EyeColors.BLUE,
                        hairColor = Character.HairColors.BLONDE,
                        type = "F",
                        beard = Character.Beards.SHORT_BEARD,
                        hairStyle = Character.HairStyles.MUSKETEER
                    },
                    new Character()
                {
                    name = Constants.necromancer,
                        type = "H",
                        outfit = Character.Outfits.WARLOCK,
                        eyeColor = Character.EyeColors.RED,
                        hairColor = Character.HairColors.GRAY,
                        beard = Character.Beards.MAGE_BEARD,
                    },
                    new Character()
                {
                    name = Constants.emmilia,
                        type = "E",
                        outfit = Character.Outfits.PRIEST,
                        eyeColor = Character.EyeColors.GREEN,
                        hairColor = Character.HairColors.RED,
                        hairStyle = Character.HairStyles.LONG,
                    },
                 new Character()
                 {
                     name = Constants.child,
                     outfit = Character.Outfits.BEGGAR,
                     hairStyle= Character.HairStyles.LONG
                 },
                 new Character()
                 {
                     type="G",
                     name = Constants.grandma,
                     outfit = Character.Outfits.BEGGAR,
                     hairStyle = Character.HairStyles.STRAIGHT
                 },
                 new Character()
                 {
                     type= "D",
                     name = Constants.bandit,
                     outfit = Character.Outfits.PEASANT,
                     hairStyle = Character.HairStyles.SPIKY,
                     hairColor= Character.HairColors.BROWN,
                     eyeColor= Character.EyeColors.BROWN,
                     beard= Character.Beards.MUSKETEER_BEARD
                 },
                 new Character()
                 {
                     type= "H",
                     name = Constants.blacksmith,
                     outfit = Character.Outfits.LIGHTARMOUR,
                     hairColor= Character.HairColors.GRAY,
                     eyeColor= Character.EyeColors.WHITE,
                     beard= Character.Beards.MAGE_BEARD
                 },
                 new Character()
                 {
                     type= "F",
                     name = Constants.guard1,
                     outfit = Character.Outfits.HEAVYARMOUR,
                 },
                 new Character()
                 {
                     type= "F",
                     name = Constants.guard2,
                     outfit = Character.Outfits.HEAVYARMOUR,
                 },
        });
        }
    }
}
