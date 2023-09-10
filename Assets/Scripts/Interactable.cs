using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum INTERACTION_TYPE
{ 
    INTERACTION_PLAYER,
    INTERACTION_MONSTER
};


public interface IInteractable
{
    void OnRaycastOver(string interactKey);
    void OnInteract(INTERACTION_TYPE type);
}
