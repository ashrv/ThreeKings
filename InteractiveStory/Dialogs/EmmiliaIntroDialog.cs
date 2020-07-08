using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class EmmiliaIntroDialog : Dialog
    {
        protected override string SetAction()
        {
            var dialog = "Last but not the least, the brewmaster priestess Emmilia rules the eastern towns. Few recall seeing her leave her sanctuary. Rumors say the fumes of her uncanny potions has turned her mad!\\n[expoFinal|Next]";
            InputController.instance.Add(new InputController.Event()
            {
                input=Selected("expoFinal"),
                 sequence=()=>new ExpositionFinal()
            });
            return dialog;
        }

        class ExpositionFinal:Sequence
        {
            public ExpositionFinal()
            {
                Add("HideDialog()");
                Add(new SetPosition(emmilia, library, "Cauldron"));
                Add("FadeOut()", true);
                Add("SetCameraFocus({0})", true, tom);
                Add("SetCameraMode({0})", follow);
                Add("FadeIn()");
                Add(new ExpositionFinishDialog().Generate(bob));
            }
        }
    }
}
