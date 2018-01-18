using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	protected bool _isOver = false;
	protected SoldierFire.ShootParm _shoot;

	protected Vector3 startPosition;
	protected Vector3 targetOffset;
	private Soldier _solider;
	// Use this for initialization
	void Start () {
	
	}
	 

	public void Create (SoldierFire.ShootParm shoot,Soldier solider)
	{
		_shoot = shoot;
		_solider = solider;
		this.transform.parent = _solider.gameObject.transform;
		ShootBegan ();

	}

	protected virtual void ShootBegan()
	{
		_isOver = true;
	}

	void Update()
	{
		if(_isOver)
		{
			transform.Translate(Vector3.left * 2f * TimeHelper.deltaTime);
		}
	}
 	

}
