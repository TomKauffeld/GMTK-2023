using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Inputs
{
    public class MyUnityInputHandler : AMyInputHandler
    {

        private List<Actions> LastActions = new();
        private List<Actions> CurrentActions = new();


        private readonly Dictionary<KeyCode, Actions> Inputs = new()
        {
            { KeyCode.RightArrow, Actions.ROTATE_RIGHT },
            { KeyCode.LeftArrow, Actions.ROTATE_LEFT },
            { KeyCode.UpArrow, Actions.ROTATE_RIGHT },
            { KeyCode.DownArrow, Actions.ROTATE_LEFT },
            { KeyCode.P, Actions.PAUSE },
            { KeyCode.Escape, Actions.PAUSE },
        };


        private void Update()
        {
            LastActions = CurrentActions;
            CurrentActions = new();
            foreach (KeyValuePair<KeyCode, Actions> input in Inputs)
            {
                if (Input.GetKey(input.Key) && !CurrentActions.Contains(input.Value))
                    CurrentActions.Add(input.Value);
            }
        }


        public override bool IsAction(Actions action)
        {
            return CurrentActions.Contains(action);
        }

        public override bool IsActionDown(Actions action)
        {
            return IsAction(action) && !LastActions.Contains(action);
        }
    }
}
