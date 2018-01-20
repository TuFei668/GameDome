using UnityEngine;
using System.Collections;

public class testData : MonoBehaviour {


	void Awake()
	{
		DataManager.instance.InitData();
	}
	void Start () {
		
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
