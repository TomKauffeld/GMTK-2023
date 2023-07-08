using Assets.Scripts.Core;
using Assets.Scripts.Core.Inputs;
using UnityEngine;

public class LevelController : MyMonoBehaviour
{
    public Transform Target;
    public float rotateAmount = 90;


    void Update()
    {
        Vector3 rotation = Vector3.zero;

        if (MyInputHandler)
        {
            if (MyInputHandler.IsActionDown(Actions.ROTATE_RIGHT))
                rotation.z -= rotateAmount;
            if (MyInputHandler.IsActionDown(Actions.ROTATE_LEFT))
                rotation.z += rotateAmount;
        }


        if (rotation.sqrMagnitude > 0)
        {
            Transform prev = Target.parent;
            Target.parent = transform;
            transform.Rotate(rotation);
            Target.Rotate(-rotation);
            Target.parent = prev;
        }
    }
}
