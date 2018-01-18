using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Lui;

public class UIMain : MonoBehaviour {

	private GameObject player;
	 
 
	private Button btn_1;
	private Button btn_2;
	private LControlView ctrlViewLeft;
	private LControlView ctrlViewright;

	private Transform panel_root;
	private LWindowManager _wm;

	private float offsetX = 0.0f;
	private float offsetY = 0.0f;
	private bool isDown = false;
	 
	void Awake()
	{
		player = GameShoot.instance.solider;
		 
		panel_root = transform.FindChild("UIWindow/panel_root").GetComponent<Transform>();
		btn_1 = panel_root.FindChild("btn_1").GetComponent<Button>();
//		btn_1.onClick.AddListener(OnBtnClick);

		btn_2 = panel_root.FindChild("btn_3").GetComponent<Button>();
//		btn_2.onClick.AddListener(OnBtnTwoClick);

	
		_wm = LWindowManager.GetInstance();
	}

	void Start()
	{
		


	}

	void Update()
	{
		
			

	}

	 
	 

}
