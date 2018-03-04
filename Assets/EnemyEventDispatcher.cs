using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventDispatcher : MonoBehaviour {

    public Enemy controller;
	
	void Destroy () {
        controller.Destroy();
	}
	
	void AttackPlayer() {
        controller.AttackPlayer();
	}
}
