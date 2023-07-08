using Assets.Scripts.Core;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.HUD
{
    public class MyMessage : MyMonoBehaviour
    {
        private TextMeshProUGUI TextMesh;

        private Message message;

        public float TimeOut = 0;
        public Message Message
        {
            get => message;
            set
            {
                if (TextMesh != null && !TextMesh.IsDestroyed())
                {
                    TextMesh.text = value.Text;
                    Resize();
                }
                if (message != null)
                    message.OnDone -= MessageDone;


                message = value;
                TimeOut = value.TimeOut;

                if (message != null)
                    message.OnDone += MessageDone;
            }
        }

        private void MessageDone(Message message)
        {
            Destroy(gameObject);
        }

        protected override void Start()
        {
            base.Start();
            TextMesh = GetComponentInChildren<TextMeshProUGUI>();
            TextMesh.text = message.Text;
            Resize();
        }

        private void Resize()
        {
            TMP_Text text = TextMesh.GetTextInfo(message.Text).textComponent;
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, text.preferredWidth + 40);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, text.preferredHeight + 40);
        }


        private void Update()
        {
            if (!Paused)
            {
                TimeOut -= Time.deltaTime;
                if (TimeOut < 0)
                    message.CallDone();
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            gameObject.SetActive(false);
        }

        protected override void OnPlay()
        {
            base.OnPlay();
            gameObject.SetActive(true);
        }

    }
}
