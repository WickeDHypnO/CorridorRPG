using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBars : MonoBehaviour
{

    public List<Slider> hpBars;
    List<bool> barTaken = new List<bool>() { false, false, false, false };

    public Slider GetHealthBar()
    {
        for (int i = 0; i < hpBars.Count; i++)
        {
            if (barTaken[i] == false)
            {
                barTaken[i] = true;
				hpBars[i].value = 1;
				hpBars[i].gameObject.SetActive(true);
                return hpBars[i];
            }
        }
        return hpBars[hpBars.Count - 1];
    }

    public void RevokeHealthBar(Slider healthBar)
    {
        for (int i = 0; i < hpBars.Count; i++)
        {
            if (hpBars[i] == healthBar)
            {
                barTaken[i] = false;
				hpBars[i].gameObject.SetActive(false);
            }
        }
    }
}
