using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class Menu : MonoBehaviour
{
    [SerializeField]
    AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [SerializeField]
    CanvasGroup canvasGroup;

    void OnValidate()
    {
        if (!canvasGroup)
        {
            if (!TryGetComponent(out canvasGroup))
            {
                canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }
        }
    }


    protected abstract void OnShow(); 
    protected abstract void OnHide();
    public void Show() 
    {
        gameObject.SetActive(true);
        canvasGroup.interactable = canvasGroup.blocksRaycasts = true;
        canvasGroup.DOKill(true);
        canvasGroup.DOFade(1, 0.15f).SetEase(curve);
        OnShow();
    }

    public void Hide() 
    {
        gameObject.SetActive(false);
        canvasGroup.interactable = canvasGroup.blocksRaycasts = false;
        canvasGroup.DOKill(true);
        canvasGroup.DOFade(0, 0.2f).SetEase(curve);
        OnHide();
    }
}
