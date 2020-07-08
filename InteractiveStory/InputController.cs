using InteractiveStory.Dialogs;
using InteractiveStory.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class InputController
    {
        public static InputController instance;
        List<Event> inputs;
        public InputController()
        {
            if (instance != null)
                throw new InvalidOperationException("InputController has already been instantiated");
            instance = this;

            Listener.instance.responses += Respond;
            inputs = new List<Event>();
            inputs.AddRange(new List<Event>() {
                new Event()
                {
                    input="input Selected Credits",
                    sequence=()=>new Sequence()
                    {
                        new Action("ShowCredits()")
                    }
                },
                new Event()
                {
                    input="input Close Credits",
                    sequence=()=>new Sequence()
                    {
                        new Action("HideCredits()")
                    }
                },
                new Event()
                {
                    input="input Selected Quit",
                    sequence=()=>new Sequence()
                    {
                        new Action("Quit()")
                    }
                },
                new Event()
                {
                     input="input Selected Start",
                     expires=true,
                     sequence=()=>new Sequence()
                     {
                         new Action("HideMenu()"),
                     }
                     .Add(new IntroSequence()).Add(new EnableControlsSequence())
                },
                new Event()
                {
                     input="input Selected Resume",
                     sequence=()=>new Sequence()
                     {
                         new Action("HideMenu()"),
                         new Action("EnableInput()")
                     }
                },
                new Event()
                {
                    input="input Close List",
                    sequence=()=>ChestSequence.chestIsOpen==null?
                        Inventory.instance.Hide():new ChestSequence(),
                },
                new Event()
                {
                    input="input Close Narration",
                    sequence=()=>new Sequence(){new Action("HideNarration()")},
                    condition=()=>!GameState.end
                },
                new Event()
                {
                    input="input Close Narration",
                    sequence=()=>new Sequence(){ new Action("Quit()"),new End() },
                    condition=()=>GameState.end,
                    changeState = () =>
                    {
                    }
                },
                new Event()
                {
                    input="input Key Inventory",
                    sequence=()=>!Inventory.instance.open?Inventory.instance.Show(tom):Inventory.instance.Hide(),
                },
                new Event()
                {
                    input="input Key Interact",
                    sequence=()=>Inventory.instance.Show(skills)
                },
                new Event()
                {
                    input = "input Selected leave",
                    sequence = ()=>new EndDialogSequence()
                },
                new Event()
                {
                    input="input Touch "+compass,
                    sequence=()=>new Sequence()
                    {
                        new Action("DisableInput()",true),
                        Inventory.instance.Hide(),
                        new Action("FadeOut()", true),
                        new Action("SetPosition({0}, {1})",true, tom, courtyard+".Fountain"),
                        new Action("Face({0}, {1})",true, tom, courtyard+".Fountain"),
                        new Action("FadeIn()",true),
                        new Action("EnableInput()")
                    }
                },
                new Event()
                {
                    input="input SecretEnding",
                    sequence=()=>new Sequence()
                    {
                        new SecretEndingSequence()
                    },
                    changeState=()=>GameState.end=true
                },
            });

            inputs.AddRange(new LionHeartEvents());
            inputs.AddRange(new EmmiliaEvents());
            inputs.AddRange(new NecromancerEvents());
            inputs.AddRange(new Inspections());
            inputs.AddRange(new TakeEvents());
            inputs.AddRange(new TalkEvents());
            inputs.AddRange(new DebugEvents());
            inputs.AddRange(new SkillEvents());
            inputs.AddRange(new PotionEvents());

            foreach (var place in Places.instance)
            {
                foreach (var portal in place.portals)
                {
                    var @event=portal.Event();
                    if (portal.name == eastend || portal.name == westend)
                    {
                        @event.condition = () => GameState.lionheartQuestState>0;
                    }
                    inputs.Add(@event);
                }
            }

        }

        public void EnablePathways()
        {
            foreach (var place in Places.instance)
            {
                foreach (var portal in place.portals)
                {
                    if (portal.name == eastend || portal.name == westend)
                    {
                        var @event = portal.Event();
                        inputs.Add(@event);
                    }
                }
            }
        }

        public void Add(Event @event)
        {
            if (!inputs.Any(z => (@event.inputs != null && @event.inputs.Aggregate((a, b) => a + b) == z.inputs.Aggregate((a, b) => a + b) || z.input == @event.input)))
                this.inputs.Add(@event);
        }

        private void Respond(string input)
        {
            if (inputs.All(z => z.activeSequence==null||!z.activeSequence.running))
            {
                for (int i = 0; i < inputs.Count; i++)
                {
                    if (inputs[i].Trigger(input))
                        break;
                }
            }
        }

        public class Event
        {
            bool expired;
            public Sequence activeSequence { get; private set; }
            public bool expires { get; set; }
            public string input { get; set; }
            public List<string> inputs { get; set; }
            public Func<Sequence> sequence { get; set; }
            public System.Action changeState { get; set; }
            public Func<bool> condition { get; set; }
            public bool Trigger(string input)
            {
                if ((activeSequence==null||!activeSequence.running)&&
                    (!expires||!expired)&&
                    (condition==null||condition())&&
                    ((inputs != null && inputs.Contains(input)) || 
                    (this.input == input)))
                {
                    changeState?.Invoke();
                    expired = true;
                    activeSequence = sequence?.Invoke();
                    activeSequence?.Start();
                    return true;
                }
                return false;
            }
        }
    }
}
