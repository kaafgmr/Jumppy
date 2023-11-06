using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AddSave : MonoBehaviour
{
    public GameObject ButtonPrefab;
    public Transform ScrollView;

    public static int levelCount;

    private void Awake()
    {
        levelCount = 0;
        for(int i = 1; i <= DBManager.SavesAmount; i++)
        {
            AddGame();
        }
    }

    public void AddGame()
    {
        levelCount++;
        GameObject button = (GameObject)Instantiate(ButtonPrefab);
        button.GetComponentInChildren<TMP_Text>().text = "" + (levelCount);
        int id = levelCount;
        button.GetComponent<Button>().onClick.AddListener( () => { LoadGame(id); });
        button.transform.SetParent(ScrollView);
        button.transform.localScale = Vector2.one;

        if(DBManager.SavesAmount < levelCount)
        {
            DBManager.NewGame();
        }
    }

    public void CreateNewGame()
    {
        DBManager.NewGame();//creates new game
        DBManager.SavesCount();//counts how many games there are
        DBManager.ID = DBManager.SavesAmount;//changes the id to the game created
    }

    public void LoadGame(int id)
    {
        DBManager.ID = id;
        MenuControl.instance.PlayGame();
    }

    public void LoadLastGame()
    {
        DBManager.SavesCount();
        DBManager.ID = DBManager.SavesAmount;
    }
}
