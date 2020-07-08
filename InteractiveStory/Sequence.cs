using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class Sequence : List<Action>, IResponder
    {
        public Sequence() { }
        public Sequence(List<Action> actions)
        {
            this.AddRange(actions);
        }

        protected void Add(string action, params string[] parameters)
        {
            Add(new Action(string.Format(action, parameters)));
        }

        protected void Add(string action, bool waitFor, params string[] parameters)
        {
            Add(new Action(string.Format(action, parameters), waitFor));
        }

        internal Sequence Add(Sequence other)
        {
            foreach (var item in other)
            {
                Add(item);
            }
            return this;
        }

        int index;
        public bool running;
        public void Start()
        {
            Listener.instance.responses += Respond;
            index = 0;
            running = true;
            this.ForEach(z => z.Reset());
            var runner = new Thread(Run);
            runner.Start();
        }

        private void Run()
        {
            while (running)
            {
                if (index >= this.Count)
                {
                    this.running = false;
                    Listener.instance.responses -= Respond;
                    break;
                }
                else if (this[index].state == Action.State.ready)
                {
                    this[index].Start();
                }
                if (this[index].waitFor)
                {
                    if (responses.Contains(this[index].Succeeded()))
                    {
                        responses.Remove(this[index].Succeeded());
                        index++;
                        continue;
                    }
                    else
                    {
                        var _responses = new List<String>();
                        lock (responses)
                        {
                            _responses = responses.ToList();
                        }
                        if (_responses.Any(z => z != null && z.StartsWith(this[index].Failed())))
                        {
                            _responses.RemoveAll(z => z.StartsWith(this[index].Failed()));
                            index++;
                            continue;
                        }
                    }
                }
                else
                {
                    index++;
                    continue;
                }

            }
        }

        List<string> responses = new List<string>();
        public void Respond(string input)
        {
            if (running && index < this.Count && this[index].waitFor)
            {
                if (this[index].ToString().StartsWith("WalkTo") && input.StartsWith(this[index].Failed()) && input.Contains("interrupted by keyboard"))
                {
                    this.running = false;
                    Listener.instance.responses -= Respond;
                }
                else if (input == this[index].Succeeded() || input.StartsWith(this[index].Failed()))
                {
                    responses.Add(input);
                }
            }

        }
    }
}
