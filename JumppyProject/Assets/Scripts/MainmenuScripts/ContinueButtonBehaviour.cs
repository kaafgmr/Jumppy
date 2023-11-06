using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButtonBehaviour : MonoBehaviour
{
    public Button ContinueButton;

    private void Start()
    {
        CanClickContinue();
    }

    public void CanClickContinue()
    {
        if (DBManager.SavesAmount > 0)
        {
            ContinueButton.interactable = true;
        }
        else
        {
            ContinueButton.interactable = false;
        }
    }
}
