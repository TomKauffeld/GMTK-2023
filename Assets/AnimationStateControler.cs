using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
public class AnimationStateControler : MonoBehaviour
{
    Animator animator;
    
    PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        PlayerState = GameObject.Find("Player").GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
