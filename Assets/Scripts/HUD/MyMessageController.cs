using Assets.Scripts.Core;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Assets.Scripts.HUD
{
    public class MyMessageController : MyMonoBehavior
    {
        private readonly Queue<Message> MessageQueue = new Queue<Message>();
        private MyMessage CurrentMessage = null;
        public MyMessage MessagePrefab;


        private void OnEnable()
        {
            MyEventHandler.OnMessage += ShowMessage;
        }


        private void OnDisable()
        {
            if (MyEventHandler != null && !MyEventHandler.IsDestroyed())
                MyEventHandler.OnMessage -= ShowMessage;
        }

        private void Update()
        {
            ShowNextMessage();
        }

        private void ShowNextMessage(bool force = false)
        {
            if (CurrentMessage != null && !CurrentMessage.IsDestroyed() && !force)
                return;


            if (MessageQueue.TryDequeue(out Message message))
            {
                if (CurrentMessage != null && !CurrentMessage.IsDestroyed())
                    Destroy(CurrentMessage.gameObject);

                CurrentMessage = Instantiate(MessagePrefab, transform);
                CurrentMessage.Message = message;
            }
        }

        public void ShowMessage(Message message)
        {
            MessageQueue.Enqueue(message);
        }

        public void ShowMessage(string message, float timeout = 5)
        {
            ShowMessage(new Message(message, timeout));
        }

    }
}
