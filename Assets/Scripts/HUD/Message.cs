using System;

namespace Assets.Scripts.HUD
{
    public class Message
    {
        public event Action<Message> OnDone;
        public readonly string Text;
        public readonly float TimeOut;
        public bool IsDone { get; private set; }

        public Message(string text, float timeOut)
        {
            Text = text;
            TimeOut = timeOut;
            IsDone = false;
        }

        public void CallDone()
        {
            if (!IsDone)
            {
                IsDone = true;
                OnDone?.Invoke(this);
            }
        }
    }
}
