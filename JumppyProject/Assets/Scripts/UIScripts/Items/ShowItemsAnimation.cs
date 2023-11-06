using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItemsAnimation : MonoBehaviour
{
    public List<GameObject> ObjectsToAppear;

    private void Awake()
    {
        for (int i = 0; i < ObjectsToAppear.Count; i++)
        {
            ObjectsToAppear[i].SetActive(false);
        }

        SetItems();
    }

    public void SetItems()
    {
        if (ItemManager.CherryIsPicked == 1)
        {
            StartAnimation();
        }
    }

    public void StartAnimation()
    {
        if (!ObjectsToAppear[ObjectsToAppear.Count - 1].activeInHierarchy) // if all fruits aren't showing, show them with an animation
        {
            StartCoroutine("Animation");
        }
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(5);
        for (int i  = 0; i < ObjectsToAppear.Count; i++)
        {
            ObjectsToAppear[i].SetActive(true);
            AudioManager.instance.PlaySound("FruitAppear");
            yield return new WaitForSeconds(1);

        }

        for (int i = 0; i < ObjectsToAppear.Count; i++)
        {
            if(ItemsList.ObjectsList[i].IsPicked() == 0)
            {
                ObjectsToAppear[i].GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f);
            }
            else
            {
                ObjectsToAppear[i].GetComponent<SpriteRenderer>().color = Color.white;
            }
        }

    }
}
