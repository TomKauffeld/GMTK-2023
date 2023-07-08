using System.Collections.Generic;

namespace Assets.Scripts.Core.Inputs
{
    public class MyIdleInputHandler : AMyInputHandler
    {

        public bool Rotate = false;

        private List<Actions> LastActions = new();
        private List<Actions> CurrentActions = new();

        private void Update()
        {
            LastActions = CurrentActions;
            CurrentActions = new();
            if (Rotate)
                CurrentActions.Add(Actions.ROTATE_RIGHT);
            Rotate = false;
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
