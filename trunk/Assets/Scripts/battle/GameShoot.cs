using UnityEngine;
using System.Collections;
using Lui;
public class GameShoot : MonoBehaviour {

	private  static GameShoot _instance;
	public static GameShoot instance
	{
		get { return _instance;}
	}
	 
	private GameObject _solider;
	public GameObject solider 
	{
		get {return _solider;}
	}

	public LWindowManager wm ;
	void Awake()
	{
		_instance = this;


	}

	void Start ()
	{
		wm = LWindowManager.GetInstance();
		wm.runWindow(ShootConfig.UI_MAIN,WindowHierarchy.Normal);
	}
	
	// Update is called once per frame
	void Update () {
		TimeHelper.SynchronizeTimestampScaled ();
		TimeHelper.SetTimeScale (1);
	
	}

	void OnDestroy() {
		_instance = null;

		TimeHelper.SetTimeScale(1);

	}


}
