using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour, IInteractable
{
    private Animator animator;
    private Collider interactCollider;

    private bool isOpen;
    private bool playerInteracted;

    private void Awake()
    {
        isOpen = false;
        playerInteracted = false;
        animator = GetComponent<Animator>();
        interactCollider = GetComponent<Collider>();
    }


    public void OnInteract(INTERACTION_TYPE type)
    {
        if(type == INTERACTION_TYPE.INTERACTION_PLAYER)
        {
            playerInteracted = true;
        }
        else
        {
            playerInteracted = false;
        }


        if(isOpen)
        {
            isOpen = false;
        }
        else
        {
            isOpen = true;
            
        }

        animator.SetBool("IsOpen", isOpen);
        animator.SetBool("PlayerInteracted", playerInteracted);

    }

    public void OnRaycastOver()
    {
        //what should be done when the player raycasts over the object. For example, display text showing the input to open a window
    }
}
