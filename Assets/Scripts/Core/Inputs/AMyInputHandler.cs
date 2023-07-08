namespace Assets.Scripts.Core.Inputs
{
    public abstract class AMyInputHandler : MyMonoBehaviour
    {
        public abstract bool IsActionDown(Actions action);
        public abstract bool IsAction(Actions actions);
    }
}
