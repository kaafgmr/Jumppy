using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChanger : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject LoadGameMenu;

    private void Awake()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        MainMenu.SetActive(true);
        LoadGameMenu.SetActive(false);
    }

    public void ShowSaves()
    {
        MainMenu.SetActive(false);
        LoadGameMenu.SetActive(true);
    }
}
