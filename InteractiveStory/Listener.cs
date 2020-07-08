using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class Listener
    {
        public static Listener instance;
        public Action<string> responses;
        public Listener()
        {
            instance = this;
            Thread main = new Thread(Listen);
            main.Start();
        }

        private void Listen()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input != null)
                {
                    responses?.Invoke(input);
                }
            }
        }

        public void Fabricate(string msg)
        {
            responses?.Invoke(msg);
        }
    }
}
