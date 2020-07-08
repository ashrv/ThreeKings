using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteractiveStory.Constants;
namespace InteractiveStory
{
    public class TakeSequence:Sequence
    {
        public static bool taken;
        public TakeSequence(string item, string furniture=null,bool chest=true)
        {
            Add(new DisableIcon("Take", item));
            if (furniture == null)
                Add("Take({0}, {1})", true, tom, item);
            else if(chest)
            {
                Add("DisableInput()");
                Add(Inventory.instance.Hide());
                Add("Take({0}, {1}, {2})", true, tom, item, furniture);
                Add(new ChestSequence());
                Add("EnableInput()");
            }
            else
            {
                Add("DisableInput()");
                Add("Take({0}, {1}, {2})", true, tom, item, furniture);
                Add("EnableInput()");
            }
            Add("Pocket({0}, {1})", true, tom, item);
            if (!taken) {
                taken = true;
                Add(new Narration("Press I to open your inventory"));
            }
        }
    }
}
