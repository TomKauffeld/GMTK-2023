using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MyMonoBehavior : MonoBehaviour
    {
        private MyEventHandler myEventHandler;


        protected MyEventHandler MyEventHandler
        {
            get
            {
                if (myEventHandler == null)
                    myEventHandler = FindObjectOfType<MyEventHandler>();

                return myEventHandler;
            }
        }
    }
}
