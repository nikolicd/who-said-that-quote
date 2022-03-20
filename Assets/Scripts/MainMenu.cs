using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class MainMenu : Menu
{
    public GameTypeElement prefab;
    public Transform content;
    public Color defaultColor;
    public Color selectedColor;
    public VerticalScrollSnap verticalScrollSnap;
    public UI_InfiniteScroll infiniteScroll;
    public List<GameTypeElement> gameTypeElements = new List<GameTypeElement>();
    void Awake()
    {
        var games = GameManager.instance.games;
        var elements = new List<Transform>();
        for (int i = 0; i < games.Count; i++)
        {
            int index = i;
            var game = games[i];
            var element = Instantiate(prefab).Initialize(game.name, (element) =>
            {
                GameManager.instance.selectedGame = game;
                element.color = selectedColor;
            },
            (element) =>
            {
                element.color = defaultColor;
            },
            (element) =>
            {
                verticalScrollSnap.CurrentPage = index;
                verticalScrollSnap.GoToScreen(index, true);
            });

            element.color = defaultColor;
            Transform transform = element.transform;
            elements.Add(transform);
            gameTypeElements.Add(element);
        }
        verticalScrollSnap.OnSelectionPageChangedEvent.AddListener(OnPage);
        gameTypeElements[verticalScrollSnap.CurrentPage].Select();
        infiniteScroll.SetNewItems(ref elements);
    }

    private void Start()
    {
        //infiniteScroll.Init();
    }

    private void OnPage(int page)
    {
        gameTypeElements[verticalScrollSnap._previousPage].Deselect();
        gameTypeElements[page].Select();
    }

    protected override void OnShow()
    {
    }

    protected override void OnHide()
    {
    }
}
