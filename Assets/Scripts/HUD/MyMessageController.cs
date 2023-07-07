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

        private void ShowNextMessage(bool force = false)
        {
            if (CurrentMessage != null && !force)
                return;


            if (MessageQueue.TryDequeue(out Message message))
            {
                if (CurrentMessage)
                    Destroy(CurrentMessage.gameObject);

                CurrentMessage = Instantiate(MessagePrefab, transform);
                CurrentMessage.Message = message;
                CurrentMessage.OnMessageDone += OnMessageDone;
            }
        }

        private void OnMessageDone(Message message)
        {
            ShowNextMessage();
        }

        public void ShowMessage(Message message)
        {
            MessageQueue.Enqueue(message);
            ShowNextMessage();
        }

        public void ShowMessage(string message, float timeout = 5)
        {
            ShowMessage(new Message(message, timeout));
        }

    }
}
