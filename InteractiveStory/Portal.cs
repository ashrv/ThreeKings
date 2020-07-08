using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
using static InteractiveStory.InputController;
using static InteractiveStory.GameState;
namespace InteractiveStory
{
    public class Portal
    {
        public string icon { get; set; }
        public bool pathway { get; set; }
        public string place { get; set; }
        public string name { get; set; }
        public Portal other { get; set; }

        public Action EnableIcon()
        {
            if (pathway)
                return null;

            return new EnableIcon("Leave",
                exitIcon,
                ToString(),
                true,
                "Go to the " + other.place
            );
        }
        public static bool setup;
        public Event Event()
        {
            var input = pathway ? string.Format("input arrived {0} position {1}", tom, ToString()) :
                string.Format("input {0} {1}", "Leave", ToString());

            Func<Sequence> sequence = () =>
            {
                var eventSequence = new Sequence();
                if (!pathway)
                    eventSequence.Add(new Action("WalkTo({0}, {1})", true, tom, this.ToString()));
                eventSequence.Add(new Sequence()
            {
                new Action("Exit({0}, {1}, true)",true, tom, this.ToString()),
                new Action("Enter({0}, {1}, true)",true, tom, other.ToString())
            });
                if (other.icon != null)
                    eventSequence.Add(new EnableIcon("Travel"+other.place, other.icon, courtyard + ".Horse", false, "Travel to the " + other.place));

                if (!setup)
                {
                    if (other.ToString() == courtyard + ".Exit")
                    {
                        setup = true;
                        eventSequence.Add(new Sequence() {
                            new SetPosition(bob, ""),
                            new Action("DisableEffect({0})", crossroads+".Gate"),
                            new SetPosition(guard1, castle, "LeftGuard"),
                            new SetPosition(guard2, castle, "RightGuard"),
                            new DisableIcon("Talk", guard1),
                            new DisableIcon("Talk", guard2),
                            new SetPosition(emmilia, library),
                            new Action("PlaySound(Spooky, {0}, true)", ruins),
                            new Action("PlaySound(River, {0}, true)", courtyard + ".Fountain"),
                            new Action("PlaySound(Forest_Day, {0}, true)", path),
                            new Action("PlaySound(Kingdom, {0}, true)", castle),
                            new Action("PlaySound(Explorer, {0}, true)", dungeon),
                            new Action("PlaySound(LivelyMusic, {0}, true)", crossroads),
                            new Action("PlaySound(LivelyMusic, {0}, true)", courtyard),
                            new Action("PlaySound(Serenity, {0}, true)", library)
                        });
                    }
                }
                return eventSequence;
            };
            System.Action changeState = () => GameState.playerPosition = other.place;

            InputController.instance.Add(new InputController.Event()
            {
                input = "input Travel" + other.place + " " + courtyard + ".Horse",
                sequence = () => new Sequence
                {
                    new Action("DisableInput()"),
                    new Action("FadeOut()", true),
                    new SetPosition(tom, other.place, waitFor:true),
                    new Action("FadeIn()", true),
                    new Action("EnableInput()")
                }
            });
            return new Event()
            {
                changeState = changeState,
                sequence = sequence,
                input = input
            };
        }

        public override string ToString()
        {
            return place + "." + name;
        }
    }
}
