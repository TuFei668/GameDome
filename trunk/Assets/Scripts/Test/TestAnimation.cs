using UnityEngine;
using System.Collections;

public class TestAnimation : MonoBehaviour {

	Animator animator ;
	private Soldier soldier;
	
	void Start () 
	{
		animator = GetComponent<FrameAnimControl>().framAnim;
		soldier = GetComponent<Soldier>();
		soldier.Init(1);
	}


	void OnGUI()
	{
		if(GUILayout.Button("die"))
		{
//			animator.Play("die");
			soldier.ToDead();

		}
		if(GUILayout.Button("firstMove"))
		{
//			animator.Play("firstMove");
			
		}
		if(GUILayout.Button("grenadeDie"))
		{
//			animator.Play("grenadeDie");
			soldier.ToJump();
			
		}
		if(GUILayout.Button("idle"))
		{
//			animator.Play("idle");
			soldier.ToIdle();
			
		}
		if(GUILayout.Button("kill"))
		{
//			animator.Play("kill");
			soldier.ToShoot();
			
		}

		if(GUILayout.Button("walking"))
		{
//			animator.Play("walking");
			soldier.ToWalk();
			
		}
	}
}
