using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door: MonoBehaviour, IInteractable
{
    private Animator animator;
    private Collider interactCollider;

    private bool isOpen;
    private bool playerInteracted;

    public TMP_Text interactText;

    private void Awake()
    {
        isOpen = false;
        playerInteracted = false;
        animator = GetComponent<Animator>();
        interactCollider = GetComponent<Collider>();

        if (interactText != null)
        {
            interactText.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("InteractText in Window class not set");
        }
    }

    private void Update()
    {
        interactText.gameObject.SetActive(false);
    }


    public void OnInteract(INTERACTION_TYPE type)
    {
        if (type == INTERACTION_TYPE.INTERACTION_PLAYER)
        {
            playerInteracted = true;
        }
        else
        {
            playerInteracted = false;
        }


        if (isOpen)
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

    public void OnRaycastOver(string interactKey)
    {
        if (interactText.gameObject.activeSelf == false)
        {
            interactText.gameObject.SetActive(true);
            if (isOpen)
            {
                interactText.text = "Press " + interactKey + " to close";
            }
            else
            {
                interactText.text = "Press " + interactKey + " to open";
            }
        }

    }
}
