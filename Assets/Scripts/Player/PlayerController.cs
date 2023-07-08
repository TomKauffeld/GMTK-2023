using UnityEngine;


namespace Assets.Scripts.Player
{

    [RequireComponent(typeof(PlayerState))]
    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public MySensor ForwardSensor;
        public MySensor FeetSensor;
        private PlayerState PlayerState;

        private void Start()
        {
            PlayerState = GetComponent<PlayerState>();
        }

        private void Update()
        {
            PlayerState.State = PlayerState.StateEnum.IDLE;
            if (FeetSensor == null || !FeetSensor.InContact)
                PlayerState.State |= PlayerState.StateEnum.FALLING;
            else if (ForwardSensor != null && !ForwardSensor.InContact)
                PlayerState.State |= PlayerState.StateEnum.WALKING;
        }


        private void FixedUpdate()
        {
            if (PlayerState.State.HasFlag(PlayerState.StateEnum.WALKING))
                transform.Translate(speed * Time.fixedDeltaTime * Vector3.right);
        }
    }
}