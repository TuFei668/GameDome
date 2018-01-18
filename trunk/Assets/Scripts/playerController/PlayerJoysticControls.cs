using UnityEngine;
using System.Collections;

public class PlayerJoysticControls : MonoBehaviour {


	private playerMove playerMove;
	// Use this for initialization
	void Start () {
		
		playerMove = GameShoot.instance.solider.transform.GetComponent<playerMove>();


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
