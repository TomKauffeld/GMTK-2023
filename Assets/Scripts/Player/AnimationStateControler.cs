using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Player
{
    public class AnimationStateControler : MonoBehaviour
    {
        Animator animator;

        PlayerState playerState;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            playerState = GetComponentInParent<PlayerState>();
        }

        // Update is called once per frame
        void Update()
        {  
            /*if(playerState.State == IDLE){
                animator.setBool("isWalking", false);
            }*/
            if(playerState.State.HasFlag(PlayerState.StateEnum.WALKING)){
                animator.SetBool("isWalking", true);
            }else{
                animator.SetBool("isWalking",false);
            }
            if(playerState.State.HasFlag(PlayerState.StateEnum.FALLING)){
                animator.SetBool("isFalling", true);
            }else{
                animator.SetBool("isFalling",false);
            }
        }
    }
}
