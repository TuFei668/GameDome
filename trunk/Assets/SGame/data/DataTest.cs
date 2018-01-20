using UnityEngine;
using System.Collections;

public class DataTest  
{
	public int id;
	public string name;
	public int hp;
	public int dp;
	public string des;

	public void Load(LitJson.JSONNode json)
	{
		id = JsonReader.Int(json,"id");
		name = json["name"];
		hp = JsonReader.Int(json,"hp");
		dp = JsonReader.Int(json,"dp");
		des = json["des"];
	}

}
