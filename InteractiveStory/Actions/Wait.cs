using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class Wait:Action
    {
        DateTime start;
        Thread runner;
        readonly float duration=3;
        public Wait(float duration=3)
        {
            waitFor = true;
            this.duration = duration;
        }
        public override void Start()
        {
            state = State.started;
            start = DateTime.Now;
            runner = new Thread(Run);
            runner.Start();
        }

        public void Run()
        {
            while (true)
            {
                if (DateTime.Now.Subtract(start).Seconds >= duration)
                {
                    Listener.instance.Fabricate(Succeeded());
                    break;
                }
            }
        }

        public override string ToString()
        {
            return "Wait()";
        }
    }
}
