using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerState : MonoBehaviour
    {
        public enum StateEnum : byte
        {
            IDLE = 0x00,
            WALKING = 0x01,
            FALLING = 0x02,
            JUMPING = 0x04,
        }

        public StateEnum State;
    }
}
