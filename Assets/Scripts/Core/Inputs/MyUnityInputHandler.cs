using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Core.Inputs
{
    public class MyUnityInputHandler : AMyInputHandler
    {

        private List<Actions> LastActions = new();
        private List<Actions> CurrentActions = new();

        private readonly Dictionary<KeyCode, Actions> InputInverseRotationInactive = new()
        {
            { KeyCode.RightArrow, Actions.ROTATE_RIGHT },
            { KeyCode.LeftArrow, Actions.ROTATE_LEFT },
            { KeyCode.UpArrow, Actions.ROTATE_RIGHT },
            { KeyCode.DownArrow, Actions.ROTATE_LEFT },
        };

        private readonly Dictionary<KeyCode, Actions> InputInverseRotationActive = new()
        {
            { KeyCode.RightArrow, Actions.ROTATE_LEFT },
            { KeyCode.LeftArrow, Actions.ROTATE_RIGHT },
            { KeyCode.UpArrow, Actions.ROTATE_LEFT },
            { KeyCode.DownArrow, Actions.ROTATE_RIGHT },
        };

        private readonly Dictionary<KeyCode, Actions> Inputs = new()
        {
            { KeyCode.P, Actions.PAUSE },
            { KeyCode.Escape, Actions.PAUSE },
        };

        public Dictionary<KeyCode, Actions> GetInputs()
        {
            Dictionary<KeyCode, Actions> inputs = new(Inputs);
            if (MySettings.InverseRotation)
                inputs.AddRange(InputInverseRotationActive);
            else
                inputs.AddRange(InputInverseRotationInactive);


            return inputs;
        }


        private void Update()
        {
            LastActions = CurrentActions;
            CurrentActions = new();
            foreach (KeyValuePair<KeyCode, Actions> input in GetInputs())
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
