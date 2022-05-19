using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenButton : ExitWIndowButton
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        exitWindow.Open();
    }
}
