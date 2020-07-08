using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class NecroDialog3 : Dialog
    {
        protected override string SetAction()
        {
            var dialog = "You never cease to amase me! We can finally turn away from the other ruler's mistakes and foolishness. Well done, my apprentice. Henceforth, you shall rule over what's left of Lionheart's domain.\\n" +
                "[necroEnd|Pledge]\\n[leave|Leave]";
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("necroEnd"),
                sequence = () => new Sequence()
                {
                    new Action("DisableInput()"),
                    new Action("HideDialog()"),
                    new Action("FadeOut()", true),
                    new Action("SetClothing({0}, warlock)", tom),
                    new SetPosition(necromancer, ruins, "Throne", waitFor:true),
                    new SetPosition(tom, ruins, "Altar", waitFor:true),
                    new Action("ShowFurniture({0})", ruins+".Altar"),
                    new Action("EnableEffect({0}, blackflame)", ruins+".Altar"),
                    new Action("SetCameraMode({0})", track),
                    new Action("PlaySound(danger3)"),
                    new Action("FadeIn()", true),
                    new Wait(10f),
                    new Narration("You united the kingdom and chose to pledge allegiance to "+necromancer)
                },
                changeState=()=>GameState.end=true
            });
            return dialog + "\\n[dungeon|(Go to the dungeon)]";
        }
    }
}
