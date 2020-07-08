using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    class EmmiliaDeathDialog : Dialog
    {
        protected override string SetAction()
        {
            var dialog = "What have you done? \\\"I told you we can't trust him. It's all your fault!\\\" Go ahead! Blame me! As you always do." +
                "This is the last time you get to. \\\"Run! You fool! Save us!\\\" We are no more my dear... This... is our end...\\n" +
                "[emmiliaDead|Leave]";
            InputController.instance.Add(new InputController.Event()
            {
                input = Selected("emmiliaDead"),
                sequence = () =>
                {
                    if (GameState.necroDead && GameState.emmiliaDead && GameState.lionheartDead)
                    {
                        return new SecretEndingSequence();
                    }
                    else
                        return new Sequence()
                        {
                            new Action("DisableInput()"),
                            new EndDialogSequence(),
                            new EmmiliaDeath(),
                            new EscapeSequence(crossroads),
                            new Action("StopSound()")
                        };
                },
                changeState = () => {
                    GameState.emmiliaDead = true; 
                    if (GameState.lionheartDead) 
                        GameState.necroState = 4;
                    if (GameState.necroDead)
                        GameState.lionheartQuestState = 5;
                }
            });
            return dialog;
        }
    }
}
