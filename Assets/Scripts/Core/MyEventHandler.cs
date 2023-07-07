using Assets.Scripts.HUD;
using System;
using UnityEngine;


namespace Assets.Scripts.Core
{
    public class MyEventHandler : MonoBehaviour
    {
        public event Action<Message> OnMessage;
        public event Action<Message> OnMessageDone;

        public event Action<MyLevel> OnLevelLoaded;
        public event Action<MyLevel> OnLevelCompleted;
        public event Action OnGameFinished;

        public event Action<MyTarget, PlayerController> OnPlayerHitsTarget;

        public void ShowMessage(Message message)
        {
            message.OnDone += (Message m) => OnMessageDone?.Invoke(m);
            OnMessage?.Invoke(message);
        }

        public Message ShowMessage(string message, float timeout = 5)
        {
            Message m = new(message, timeout);
            ShowMessage(m);
            return m;
        }

        public void CallOnLevelLoaded(MyLevel level)
        {
            OnLevelLoaded?.Invoke(level);
        }

        public void CallOnLevelCompleted(MyLevel level)
        {
            OnLevelCompleted?.Invoke(level);
        }

        public void CallOnPlayerHitsTarget(MyTarget target, PlayerController player)
        {
            OnPlayerHitsTarget?.Invoke(target, player);
        }

        public void CallOnGameFinished()
        {
            OnGameFinished?.Invoke();
        }
    }
}