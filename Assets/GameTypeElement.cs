using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class GameTypeElement : MonoBehaviour
{
    [SerializeField]
     Button button;
    [SerializeField]
    TextMeshProUGUI _text;

    public UnityEvent<GameTypeElement> onClick = new UnityEvent<GameTypeElement>();
    public UnityEvent<GameTypeElement> onSelect = new UnityEvent<GameTypeElement>();
    public UnityEvent<GameTypeElement> onDeselect = new UnityEvent<GameTypeElement>();

    public string gameName 
    {
        get 
        {
            return _text.text;
        }
        set 
        {
            gameObject.name = value;
            _text.text = value;
        }
    }

    public Color color 
    {
        get 
        {
            return _text.color;
        }
        set 
        {
            _text.DOColor(value, 0.2f);
        }
    }

    public void OnClick() 
    {
        onClick.Invoke(this);
    }

    public void Select()
    {
        onSelect.Invoke(this);
    }

    public void Deselect() 
    {
        onDeselect.Invoke(this);
    }

    public GameTypeElement Initialize(string gameName, UnityAction<GameTypeElement> onSelect, UnityAction<GameTypeElement> onDeselect, UnityAction<GameTypeElement> onClick) 
    {
        this.gameName = gameName;

        this.onSelect.AddListener(onSelect);
        this.onDeselect.AddListener(onDeselect);
        this.onClick.AddListener(onClick);

        button.onClick.AddListener(OnClick);

        return this;
    }
}
