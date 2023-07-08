using Assets.Scripts.HUD;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class WaitForMessage : CustomYieldInstruction
    {
        private CustomYieldInstruction BaseCustomYieldInstruction = null;

        public Message Message { get; private set; }
        public override bool keepWaiting =>
            (!(Message?.IsDone ?? true)) &&
            (BaseCustomYieldInstruction?.keepWaiting ?? true);

        public WaitForMessage(Message message)
        {
            Message = message;
        }

        public WaitForMessage(Message message, CustomYieldInstruction baseYield) : this(message)
        {
            BaseCustomYieldInstruction = baseYield;
        }
    }
}
