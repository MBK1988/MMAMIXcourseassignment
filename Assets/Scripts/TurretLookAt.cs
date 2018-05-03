using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLookAt : MonoBehaviour {

    public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        Vector3 player_pos = Player.transform.position - new Vector3(0, 1f, 0);
        transform.LookAt(player_pos);
		
	}
}
