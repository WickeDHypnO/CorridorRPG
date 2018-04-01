using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject damageCanvas;
    public GameObject skillBar;
    public List<UISkillButton> skillButtons;
    public Slider expBar;

    void OnEnable()
    {
        SetSkills();
    }

    public void ShowDamage()
    {
        var group = damageCanvas.GetComponent<CanvasGroup>();
        group.alpha = 1;
        group.DOFade(0, 0.5f);
    }

    public void SetSkillBarVisible(bool isVisible)
    {
        skillBar.SetActive(isVisible);
    }

    public void SetSkills()
    {
        int iterator = 0;
        PlayerStats data = FindObjectOfType<GameManager>().playerData;
        foreach (UISkillButton button in skillButtons)
        {
            if (data.skills[iterator])
            {
                button.GetComponent<Image>().sprite = data.skills[iterator].skilImage;
                button.skillData = data.skills[iterator];
            }
            else
            {
                button.gameObject.SetActive(false);
            }
            iterator++;
        }
    }

    public void SetExp(float amount, float max)
    {
        expBar.value = amount / max;
    }
}
