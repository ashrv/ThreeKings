using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class EmmiliaDialog2 : Dialog
    {
        protected override string SetAction()
        {
            var dialog = "You have done it! I am in awe of your tenacity! \\\"It's our time! WE finally get what we deserve!\\\" Come child! Come with me to claim our kingdom!" +
                "\\n[emmiliaEnd|Pledge]\\n[leave|Leave]";
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("emmiliaEnd"),
                sequence = () => new Sequence()
                {
                    new Action("DisableInput()"),
                    new EndDialogSequence(),
                    new Action("SetExpression({0}, happy)", emmilia),
                    new Action("FadeOut()", true),
                    new Action("SetClothing({0}, priest)", tom),
                     new Action("PlaySound(kingdom)"),
                     new Action("SetCameraMode(track)"),
                    new SetPosition(lionheart, "",waitFor:true),
                    new SetPosition(guard1, ""),
                    new SetPosition(guard2, ""),
                    new SetPosition(tom, castle, "LeftThrone", waitFor:true),
                    //new Action("Sit({0}, {1})", true, tom, castle+".LeftThrone"),
                    new SetPosition(emmilia, castle, "Throne", waitFor:true),
                    //new Action("Sit({0}, {1})", true, emmilia, castle+".Throne"),
                         new Action("CreateItem(g1, GoldCup)",true),
                    new Action("CreateItem(g2, GoldCup)", true),
                    new Action("Unpocket({0}, g1)", tom),
                    new Action("Unpocket({0}, g2)", emmilia),
                    new Action("FadeIn()",true),
                    new Wait(5f),
                    new Narration("You united the kingdom and chose to pledge allegiance to "+emmilia)

                },
                changeState=()=>GameState.end=true
            });
            return dialog;
        }
    }
}
