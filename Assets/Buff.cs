using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour {

	public SkillData buffData;
	void Start () {
		FindObjectOfType<GameManager>().AddBuff(Instantiate(buffData));
	}
}
