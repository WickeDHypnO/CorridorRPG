using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkillButton : MonoBehaviour {

    public SkillData skillData;

    public void DoSkill()
    {
        FindObjectOfType<FightController>().EndPlayerTurn(skillData);
    }
}
