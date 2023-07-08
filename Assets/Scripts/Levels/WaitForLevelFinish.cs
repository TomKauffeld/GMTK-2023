using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Levels
{
    public class WaitForLevelFinish : CustomYieldInstruction
    {
        public MyLevel Level { get; private set; }
        public override bool keepWaiting => !Level.Finished;

        public WaitForLevelFinish(MyLevel level)
        {
            Level = level;
        }
    }
}
