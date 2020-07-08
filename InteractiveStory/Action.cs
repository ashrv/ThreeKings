using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class Action
    {
        protected string action;
        public bool waitFor;
        public State state { get; protected set; }
        public enum State
        {
            ready, started
        }

        public Action()
        {
            state = State.ready;
        }
        public Action(string action, bool waitFor=false, params string[] parameters)
        {
            this.action = string.Format(action, parameters);
            this.waitFor = waitFor;
        }

        public Action(string format, params string[] parameters)
        {
            this.action = string.Format(format, parameters);
        }

        public virtual void Start()
        {
            state=State.started;
            Console.WriteLine(string.Format("start {0}", action));
        }

        public string Succeeded()
        {
            return string.Format("succeeded " + action);
        }
        public string Failed()
        {
            return string.Format("failed " + action);
        }

        public void Reset()
        {
            state = State.ready;
        }

        public override string ToString()
        {
            return action??base.ToString();
        }
    }
}
