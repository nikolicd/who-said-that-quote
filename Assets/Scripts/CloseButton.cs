using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseButton : ExitWIndowButton
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        exitWindow.Close();
    }
}
