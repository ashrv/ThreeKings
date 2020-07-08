using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class CreateCharacterSequence : Sequence
    {
        public CreateCharacterSequence(Character character)
        {
            Add(new Action(string.Format("CreateCharacter({0}, {1})", character.name, character.type), true));
            Add(new Action(string.Format("SetHairStyle({0}, {1})", character.name, character.hairStyle.ToString())));
            if (character.beard != Character.Beards.SHAVED)
                Add(new Action(string.Format("SetHairStyle({0}, {1})", character.name, character.beard.ToString())));
            Add(new Action(string.Format("SetHairColor({0}, {1})", character.name, character.hairColor.ToString())));
            Add(new Action(string.Format("SetEyeColor({0}, {1})", character.name, character.eyeColor.ToString())));
            Add(new Action(string.Format("SetClothing({0}, {1})", character.name, character.outfit.ToString())));
        }
    }
}
