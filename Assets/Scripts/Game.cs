using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class Game : MonoBehaviour
{
    public GameTypeElement prefab;
    public Transform content;
    public Color defaultColor;
    public Color selectedColor;
    public Color correctColor;
    public HorizontalScrollSnap horizontalScrollSnap;
    public UI_InfiniteScroll infiniteScroll;
    public TextMeshProUGUI partOne;
    public List<GameTypeElement> gameTypeElements = new List<GameTypeElement>();

    public Game Initialize(MatchData data)
    {
        var newItems = new List<Transform>();
        partOne.text = data.part1;
        List<string> parts = GameManager.instance.GetRandomWrongPart2s(data.part2).ToList();
        parts.Insert(Random.Range(1, parts.Count), data.part2);
        for (int i = 0; i < parts.Count; i++)
        {
            int index = i;
            var game = data;
            var element = Instantiate(prefab).Initialize(parts[i], (element) =>
            {
                if (element.name == game.part2)
                {
                    element.color = correctColor;
                }
                else
                {
                    element.color = selectedColor;
                }
            },
            (element) =>
            {
                element.color = defaultColor;
            },
            (element) =>
            {
                horizontalScrollSnap.CurrentPage = index;
                horizontalScrollSnap.GoToScreen(index, true);
            });
            Transform transform = element.transform;
            newItems.Add(transform);
            element.color = defaultColor;
            gameTypeElements.Add(element);
        }
        horizontalScrollSnap.OnSelectionPageChangedEvent.AddListener(OnPage);
        gameTypeElements[horizontalScrollSnap.CurrentPage].Select();
        infiniteScroll.SetNewItems(ref newItems);
        return this;
    }

    private void Start()
    {
        //infiniteScroll.Init();
    }

    private void OnEnable()
    {
        print(".!.");
    }

    private void OnPage(int page)
    {
        gameTypeElements[horizontalScrollSnap._previousPage].Deselect();
        gameTypeElements[page].Select();
    }
}
