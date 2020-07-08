using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class Place
    {
        public string name { get; set; }
        public List<Portal> portals { get; set; }

        public Portal get(string name)
        {
            var portal= portals.First(z => z.name == name);
            if (portal == null)
                throw new NullReferenceException("There is a problem with portal setups: " + name);
            return portal;
        }
    }
}
