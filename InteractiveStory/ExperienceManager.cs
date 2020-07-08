using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class ExperienceManager
    {
        Listener listener;
        List<Sequence> sequences;
        Sequence activeSequence;
        public ExperienceManager()
        {
            listener = new Listener();
            new Inventory();
            new Places();
            new Characters();
            var inputs = new InputController();
            sequences = new List<Sequence>()
            {
                new StarterSequence(),
            };
        }

        public void Run()
        {
            int index = 0;
            while (activeSequence==null||!activeSequence.running)
            {
                if (index < sequences.Count)
                {
                    activeSequence = sequences[index++];
                    activeSequence.Start();
                }
            }
        }

        public void Respond(string input)
        {

        }
    }
}
