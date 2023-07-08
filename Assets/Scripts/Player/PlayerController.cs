using Assets.Scripts.Core;
using UnityEngine;


namespace Assets.Scripts.Player
{

    [RequireComponent(typeof(PlayerState))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MyMonoBehaviour
    {
        public bool Freeze;
        public float speed;
        public MySensor ForwardSensor;
        public MySensor FeetSensor;
        private PlayerState PlayerState;
        private Rigidbody Rigidbody;

        protected override void Start()
        {
            base.Start();
            PlayerState = GetComponent<PlayerState>();
            Rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            PlayerState.State = PlayerState.StateEnum.IDLE;
            if (Freeze || Paused)
            {
                Rigidbody.Sleep();
                return;
            }

            if (FeetSensor == null || !FeetSensor.InContact)
                PlayerState.State |= PlayerState.StateEnum.FALLING;
            else if (ForwardSensor != null && !ForwardSensor.InContact)
                PlayerState.State |= PlayerState.StateEnum.WALKING;
        }

        protected override void OnPlay()
        {
            base.OnPlay();
            if (!Freeze)
                Rigidbody.WakeUp();
        }


        private void FixedUpdate()
        {
            if (PlayerState.State.HasFlag(PlayerState.StateEnum.WALKING))
                transform.Translate(speed * Time.fixedDeltaTime * Vector3.right);
        }
    }
}