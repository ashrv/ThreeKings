using InteractiveStory.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class ReviveDialog : Dialog
    {
        protected override string SetAction()
        {
            var dialog = bandit + ": Where am I? What happened?\\n" +
                grandma + ": Son! My dear son! You're here with us! You are well!\\n" +
                bandit + ": Mother? What are you doing here? Where are we?\\n" +
                grandma + ": All is well my son! Do not worry yourself!\\n[reviveNext|Leave]";
            InputController.instance.Add(new InputController.Event()
            {
                input = "input Selected reviveNext",
                sequence = () => new Sequence()
                {
                    new Action("HideDialog()"),
                    new Action("FadeOut()",true),
                    new Action("SetCameraMode({0})", follow),
                    new Action("SetCameraFocus({0})", tom),
                    new SetPosition(necromancer,ruins, "Altar"),
                    new SetPosition(tom, ruins, waitFor:true),
                    new Action("StopSound()"),
                    new SetPosition(bandit, dungeon, "RoundTable"),
                    new Action("FadeIn()", true),
                    new SkillEarned(),
                    new Action("EnableInput()")
                },
                changeState = () => GameState.revived = true
            });
            return dialog;
        }
    }
}
