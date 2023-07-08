using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Inputs
{
    public abstract class AMyInputHandler : MonoBehaviour
    {
        public abstract bool IsActionDown(Actions action);
        public abstract bool IsAction(Actions actions);
    }
}
