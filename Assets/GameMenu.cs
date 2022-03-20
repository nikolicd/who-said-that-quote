using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class GameMenu : Menu
{
    [SerializeField]
    Game gamePrefab;
    [SerializeField]
    HorizontalScrollSnap horizontalScrollSnap;
    [SerializeField]
    Transform content;
    [SerializeField]
    UI_InfiniteScroll infiniteScroll;

    protected override void OnHide()
    {
        //throw new System.NotImplementedException();
    }

    protected override void OnShow()
    {
        foreach (var item in content.GetComponentsInChildren<Transform>(true))
        {
            if (item != content)
            {
                Destroy(item.gameObject);
            }
        }
        var items = new List<Transform>();
        foreach (var item in GameManager.instance.selectedGame.data)
        {
            var element = Instantiate(gamePrefab).Initialize(item).transform;
            items.Add(element);
        }
        horizontalScrollSnap.enabled = false;
        infiniteScroll.SetNewItems(ref items);
        horizontalScrollSnap.enabled = true;
    }
}
