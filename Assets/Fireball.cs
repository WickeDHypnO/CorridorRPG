using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fireball : MonoBehaviour {

	Transform target;
	public GameObject hitParticles;
	public SkillData skillData;
	void Start () {
		transform.position = Camera.main.transform.position;
		target = FindObjectOfType<FightController>().selected.transform;
		transform.DOMove(target.position + Vector3.up, 0.5f).SetEase(Ease.Linear).OnComplete(DestroyFireball);
	}
	
	void DestroyFireball()
	{
		FindObjectOfType<FightController>().AttackSelected(skillData);
		Instantiate(hitParticles, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
