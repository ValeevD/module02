using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIExtensions
{
    private static CanvasGroup ChangeVision(this CanvasGroup canvasGroup, bool _value)
    {
        canvasGroup.interactable = _value;
        canvasGroup.alpha = _value ? 1 : 0;
        canvasGroup.blocksRaycasts = _value;

        return canvasGroup;
    }

    public static CanvasGroup SetVisionTrue(this CanvasGroup canvasGroup)
    {
        return canvasGroup.ChangeVision(true);
    }

    public static CanvasGroup SetVisionFalse(this CanvasGroup canvasGroup)
    {
        return canvasGroup.ChangeVision(false);
    }
}
