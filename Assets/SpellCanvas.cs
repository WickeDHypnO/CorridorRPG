using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpellCanvas : MonoBehaviour
{

    public CanvasGroup group;
    public float lifetime;
    void OnEnable()
    {
        group.DOFade(0, lifetime);
        Destroy(gameObject, lifetime);
    }
}
