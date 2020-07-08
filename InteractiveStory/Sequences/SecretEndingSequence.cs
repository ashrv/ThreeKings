using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class SecretEndingSequence:Sequence
    {
        public SecretEndingSequence()
        {
            GameState.end = true;
            Add(new Sequence()
            {
                new Action("HideDialog()"),
                new Action("HideNarration()"),
                new Action("DisableInput()"),
                    new Action("FadeOut()", true),
                    new Action("SetPosition({0})", true, lionheart),
                    new Action("SetClothing({0}, king)", tom),
                     new Action("PlaySound(tavern)"),
                     new Action("SetCameraMode(track)"),
                    new SetPosition(tom, castle, "Throne", waitFor:true),
                         new Action("CreateItem(g1, GoldCup)",true),
                    new Action("Unpocket({0}, g1)", tom),
                    new Action("FadeIn()",true),
                    new Wait(5f),
                    new Narration("Oh wow! You killed everyone! Well Congratulations! You denied to pledge allegiance to anyone!")
            });
        }
    }
}
