using UnityEngine;
using System.Collections;

public class testData : MonoBehaviour {


	void Awake()
	{
		DataManager.instance.InitData();
	}
	void Start () {
		DataBuildingGroup building = DataManager.instance.dataBuildingGroup;
		DataBuilding[] buildingArr = building.GetAllBuildings(1);

		DataTestGroup testGround = DataManager.instance.datatestGround;
		for(int i = 1; i <= 20;i++ )
		{
			DataTest data = testGround.GetTest(i);
//			Trace.trace("data " + data.id + " " + data.name + " " + data.hp + " " + data.dp + " " + data.des ,Trace.CHANNEL.UI);
		}
		Trace.trace(" end " ,Trace.CHANNEL.UI);
		// ******************************************

		PlayerPrefs.DeleteAll();

		User user = new User();
		user.Name = "哈哈哈";
		user.Age = 122;
		user.Describe = "test ";
		user.dse = "text";
		user.text = "text";
		PlayerPrefsExtend.Save("user", user);

		user = null;

		user = PlayerPrefsExtend.GetValue<User>("user");

		Debug.Log("user name: " + user.Name);
		Debug.Log("user Age: " + user.Age);
		Debug.Log("user Describe: " + user.Describe);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
