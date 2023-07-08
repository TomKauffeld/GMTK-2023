using Assets.Scripts.Core.Inputs;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MyMonoBehavior : MonoBehaviour
    {
        private MyEventHandler myEventHandler;
        private AMyInputHandler myInputHandler;

        protected MyEventHandler MyEventHandler
        {
            get
            {
                if (myEventHandler == null)
                    myEventHandler = FindObjectOfType<MyEventHandler>();

                return myEventHandler;
            }
        }

        protected AMyInputHandler MyInputHandler
        {
            get
            {
                if (myInputHandler == null)
                    myInputHandler = FindObjectOfType<AMyInputHandler>();

                return myInputHandler;
            }
        }
    }
}
