using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class LionheartDialog3 : Dialog
    {
        protected override string SetAction()
        {
            var dialog = "Valiant defender of the realms. My people and I are forever in your debt. Come! Sit next to me where you belong! We shall rule this kingdom in exchange for limitless wealth and fortune!" +
                "\\n[lionheartEnd|Pledge]\\n[leave|Leave]";
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("lionheartEnd"),
                sequence = () => new Sequence()
                {
                    new Action("DisableInput()"),
                    new Action("StopSound({0})", castle),
                    new EndDialogSequence(),
                    new Action("PlaySound(danger3)"),
                    new Action("FadeOut()", true),
                    new Action("SetCameraMode({0})", track),
                    new Action("SetClothing({0}, noble)", tom),
                    new SetPosition(tom, castle,"LeftThrone", waitFor:true),
                    //new Action("Sit({0}, {1})", lionheart, castle+".Throne"),
                    new Action("CreateItem(g1, GoldCup)",true),
                    new Action("CreateItem(g2, GoldCup)", true),
                    new Action("Unpocket({0}, g1)",true, tom),
                    new Action("Unpocket({0}, g2)",true, lionheart),
                    new Action("FadeIn()",true),
                    new Wait(5f),
                    new Narration("You united the kingdom and chose to pledge allegiance to "+lionheart)
                },
                changeState=()=>GameState.end=true
            });
            return dialog;
        }
    }
}
