using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lightswitch : MonoBehaviour, IInteractable
{
    private Animator animator;
    private Collider interactCollider;

    public bool isOn;

    public TMP_Text interactText;
    public List<GameObject> lightList;

    private void Awake()
    {
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


        isOn = false;

        //sets the state of the light to the state of the first light in the list, to ensure sync between light states
        if (lightList.Count != 0)
        {
            isOn = lightList[0].activeSelf;
        }

        foreach(GameObject light in lightList)
        {
            light.SetActive(isOn);
        }

        animator.SetBool("IsOn", isOn);
    }

    private void Update()
    {
        interactText.gameObject.SetActive(false);
    }


    public void OnInteract(INTERACTION_TYPE type)
    {
        if (isOn)
        {
            isOn = false;
        }
        else
        {
            isOn = true;

        }

        foreach (GameObject light in lightList)
        {
            light.SetActive(isOn);
        }

        animator.SetBool("IsOn", isOn);

    }

    public void OnRaycastOver(string interactKey)
    {
        if (interactText.gameObject.activeSelf == false)
        {
            interactText.gameObject.SetActive(true);
            if (isOn)
            {
                interactText.text = "Press " + interactKey + " to turn off";
            }
            else
            {
                interactText.text = "Press " + interactKey + " to turn on";
            }
        }

    }
}
