using Assets.Scripts.Core.Inputs;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class MyMonoBehaviour : MonoBehaviour
    {
        private MyEventHandler myEventHandler;
        private AMyInputHandler myInputHandler;
        private MySettings mySettings;
        public bool Paused { get; private set; } = false;

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

        protected MySettings MySettings
        {
            get
            {
                if (mySettings == null)
                    mySettings = FindObjectOfType<MySettings>();

                return mySettings;
            }
        }



        protected virtual void Start()
        {
            if (MyEventHandler)
            {
                MyEventHandler.OnPause += OnPause;
                MyEventHandler.OnPlay += OnPlay;
            }
        }

        protected virtual void OnDestroy()
        {
            if (MyEventHandler)
            {
                MyEventHandler.OnPause -= OnPause;
                MyEventHandler.OnPlay -= OnPlay;
            }
        }

        protected virtual void OnPlay()
        {
            Paused = false;
        }

        protected virtual void OnPause()
        {
            Paused = true;
        }
    }
}
