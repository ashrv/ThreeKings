using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class NecroIntroDialog : Dialog
    {
        protected override string SetAction()
        {
            var dialog = "Any land beyond the dark forest is ruled by the ruthless Necromancer! His name strikes fear into the hearts of the brave! His dabbling with dark magic makes him a formidable foe for anyone who dares to oppose him.\\n[emmiliaintro|Next]";
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("emmiliaintro"),
                sequence = ()=>new EmmiliaIntro()
            });
            return dialog;
        }

        class EmmiliaIntro:Sequence
        {
            public EmmiliaIntro()
            {
                Add("HideDialog()");
                Add("FadeOut()",true);
                Add("SetCameraFocus({0})", emmilia);
                Add("FadeIn()",true);
                Add("SetExpression({0}, Disgusted)", emmilia);
                Add("CreateItem({0}, {1})",true, "potion", "PurplePotion");
                Add("Put({0}, {1}, {2})", true, emmilia, "potion", library + ".Cauldron");
                Add("CreateEffect({0}, {1})", true, library + ".Cauldron", "Brew");
                Add(new Wait());
                Add(new EmmiliaIntroDialog().Generate(emmilia,otherOnly: true));
            }
        }
    }
}
