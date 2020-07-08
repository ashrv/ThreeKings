using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    class EmmiliaAttackDialog : Dialog
    {
        protected override string SetAction()
        {
            InputController.instance.Add(new InputController.Event()
            {
                input=Selected("emAttached"),
                sequence = () =>
                {
                    if (GameState.necroDead && GameState.emmiliaDead && GameState.lionheartDead) {
                        return new SecretEndingSequence();
                    }
                    else
                    {
                        return new Sequence()
                        {
                            new EndDialogSequence(),
                            new EscapeSequence(crossroads)
                        };
                    }
                }
            });
            return "Why me? \\\"Why us?\\\" What did I ever do to you?\\n[emAttached|Leave]";
        }
    }
}
