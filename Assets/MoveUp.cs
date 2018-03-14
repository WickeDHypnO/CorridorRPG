using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MoveUp : MonoBehaviour
{

    public RectTransform rect;
    public Image image;
    public float moveAmount;
    public float moveDuration;

    void OnEnable()
    {
        rect.DOLocalMoveY(moveAmount, moveDuration);
        image.DOColor(new Color(image.color.r, image.color.g, image.color.b, 0), moveDuration);
    }
}
