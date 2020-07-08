using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveStory
{
    public class EnableControlsSequence:Sequence
    {
        public EnableControlsSequence()
        {
            Add("SetCameraFocus({0})", Constants.tom);
            Add("SetCameraMode({0})", Constants.follow);
            Add("EnableInput()");
        }
    }
}
