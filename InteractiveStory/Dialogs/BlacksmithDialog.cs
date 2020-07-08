using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory.Dialogs
{
    public class BlacksmithDialog : Dialog
    {
        internal static bool forgedSword;
        internal static bool forgedHelm;

        protected override string SetAction()
        {
            var dialog = "What is it that you want? Hurry up! I don't have all day\\n[leave|Never mind]\\n[busy|He doesn't seem busy to me!]";
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("busy"),
                sequence = () => new SimpleDialog("I'm blind, not deaf!")
            });
            if (GameState.lionheartQuestState == 1&&!forgedSword)
            {
                    dialog += "\\n[needsword|The king sent me]";
                    InputController.instance.Add(new InputController.Event()
                    {
                        input = Selected("needsword"),
                        sequence = () => new SimpleDialog("I see. I mean I don't, but... Grab me that hammer child. Hurry! We don't have much time. Put it on the anvil so I can start forging.")
                    });
            }
            else if(GameState.lionheartQuestState==3&&!forgedHelm)
            {
                dialog = "Ah! I see you have gone up in the world child... I don't! but you know what I mean!\\nPut that helm on the anvil so I can forge you a blessed armour!\\n[leave|Fine]";
            }

            return dialog;
        }
    }
}
