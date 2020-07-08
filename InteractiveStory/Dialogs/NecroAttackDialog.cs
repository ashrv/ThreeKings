using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class NecroAttackDialog:Dialog
    {
        protected override string SetAction()
        {
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("necroAttacked"),
                sequence = () =>
                {
                    if (GameState.necroDead && GameState.emmiliaDead && GameState.lionheartDead)
                    {
                        return new SecretEndingSequence();
                    }
                    else
                    {
                        return new Sequence()
                        {
                            new EndDialogSequence(),
                            new EscapeSequence(path)
                        };
                    }
                }
            });
            return "I just hope you didn't make this choice lightly, young one...and that it won't leave you with regret.\\n[necroAttacked|Leave]";
        }
    }
}
