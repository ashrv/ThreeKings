using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class End:Action
    {
        public override void Start()
        {
            Environment.Exit(Environment.ExitCode);
        }
        public override string ToString()
        {
            return "End()";
        }
    }
}
