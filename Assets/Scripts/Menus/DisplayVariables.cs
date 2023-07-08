using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Menus
{
    [RequireComponent(typeof(TMP_Text))]
    public class DisplayVariables : MonoBehaviour
    {
        private readonly Dictionary<string, string> Variables = new();
        private readonly List<string> UsedVariables = new();
        private TMP_Text BaseTextField;
        private string source = null;

        public string Text
        {
            get => source;
            set
            {
                source = value;
                if (BaseTextField)
                    UpdateText();
            }
        }

        private void Start()
        {
            BaseTextField = GetComponent<TMP_Text>();
            if (source != null)
                source = BaseTextField.text;

            Variables.Add("UnityVersion", Application.unityVersion);
            Variables.Add("ApplicationVersion", Application.version);
            Variables.Add("BuildGUID", Application.buildGUID);
            Variables.Add("ApplicationName", Application.productName);

            UpdateText();
        }

        public void UpdateText()
        {
            string text = source;
            foreach (KeyValuePair<string, string> variable in Variables)
            {
                string key = "{{" + variable.Key + "}}";
                if (text.Contains(key))
                {
                    UsedVariables.Add(variable.Key);
                    text = text.Replace(key, variable.Value);
                }
            }
            BaseTextField.text = text;
        }

        public void SetVariable(string key, string value)
        {
            if (Variables.ContainsKey(key) && Variables[key] == value)
                return;

            Variables[key] = value;

            if (UsedVariables.Contains(key) && BaseTextField)
                UpdateText();
        }
    }
}
