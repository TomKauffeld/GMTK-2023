using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Transform Target;
    public float rotateAmount = 90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rotation.z += rotateAmount;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rotation.z -= rotateAmount;
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

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;
    }
}
