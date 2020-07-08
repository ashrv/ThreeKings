using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class BobExpoDialog : Dialog
    {
        protected override string SetAction()
        {
            var dialog = "The kingdom is divided into three territories ruled by three lords.\\nAfter years of senseless wars, they came to the consensus to stay out of each others' way and divide the land amongst themselves.\\n[lionheartintro|Next]";
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("lionheartintro"),
                sequence = ()=>new LionheartIntro()
            });
            return dialog;
        }

        class LionheartIntro : Sequence {
            public LionheartIntro()
            {
                Add("SetRight(null)");
                Add("HideDialog()");
                Add("FadeOut()", true);
                Add("SetPosition({0}, {1})", guard1, castle + ".LeftGuard");
                Add("SetPosition({0}, {1})", guard2, castle + ".RightGuard");
                Add("SetPosition({0}, {1})", blacksmith, castle + ".Supplicant");
                Add("SetCameraFocus({0}", true,lionheart);
                Add("SetCameraMode({0})", track);
                Add("FadeIn()", true);
                Add("Kneel({0})", true, blacksmith);
                Add(new LionheartIntroDialog().Generate(lionheart,otherOnly: true));
            }
        }

    }
}
