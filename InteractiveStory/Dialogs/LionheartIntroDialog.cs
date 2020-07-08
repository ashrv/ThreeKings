using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class LionheartIntroDialog : Dialog
    {
        protected override string SetAction()
        {
            var dialog = "King Lionheart The Just rules the north of the kingdom. His tales of heroism and equity are prevalent throughout the kingdom! Some say his swordsmanship is unmatched by any man... or woman!\\n[necrointro|Next]";
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("necrointro"),
                sequence = ()=>new Sequence() {
                    new NecroIntro()
                }
            });
            return dialog;
        }

        class NecroIntro:Sequence
        {
            public NecroIntro()
            {
                Add("HideDialog()");
                Add("FadeOut()", true);
                Add(new SetPosition(guard1, crossroads, "WestEnd"));
                Add(new SetPosition(guard2, crossroads, "EastEnd"));
                Add("SetCameraFocus({0})", necromancer);
                Add("SetExpression({0}, Angry)", necromancer);
                Add("CreateItem({0}, {1})", true, "Skull", "Skull");
                Add("Unpocket({0}, {1})", true, necromancer, "Skull");
                Add("FadeIn()",true);
                Add("CreateEffect({0}, {1})", "Skull", "Skulls");
                Add(new Wait());
                Add(new NecroIntroDialog().Generate(necromancer,otherOnly: true));
            }
        }
    }
}
