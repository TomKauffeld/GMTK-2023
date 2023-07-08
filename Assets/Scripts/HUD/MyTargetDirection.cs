using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.HUD
{
    [RequireComponent(typeof(RectTransform))]
    public class MyTargetDirection : MyMonoBehaviour
    {
        private RectTransform RectTransform;
        public float angle;
        public Transform Player;
        public MyTarget target;
        public MyTarget Target
        {
            get => target;
            set
            {
                target = value;
                UpdateTargetDirection();
            }
        }

        protected override void Start()
        {
            base.Start();
            RectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            UpdateTargetDirection();
        }

        public void UpdateTargetDirection()
        {
            if (!Target || !enabled || !Player || !RectTransform)
                return;

            Vector3 currentPos = Player.position;
            Vector3 targetPos = Target.transform.position;

            Vector3 diff = targetPos - currentPos;

            float angle = Vector3.SignedAngle(Vector3.right, diff, Vector3.forward);

            RectTransform.rotation = Quaternion.Euler(0, 0, angle);

        }

    }
}
