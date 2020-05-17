using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RemoveFocus : MonoBehaviour
{
    public void removeFocus(){
        EventSystem.current.SetSelectedGameObject(null);
    }
}
