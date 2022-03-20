using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InstructionWindow : MonoBehaviour
{
    public Text instructionText;
    public CanvasGroup canvasGroup;
    public void Show(string text)
    {
        instructionText.text = text;
        canvasGroup.DOFade(1, 0.25f);
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    public void Hide()
    {
        canvasGroup.DOFade(0, 0.10f);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }
}
