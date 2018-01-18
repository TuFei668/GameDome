using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataTestGroup
{
	private Dictionary<int,Dictionary<int,DataTest>> dataTests;

	private bool isLoad = false;

	public DataTest GetTest(int id)
	{
		Dictionary<int, DataTest> tests;
		dataTests.TryGetValue (id, out tests);
		if (tests != null) 
		{
			DataTest test = null;
			tests.TryGetValue (id, out test);
			if(test != null)
			{
				return test;
			}
		}	
		return null;
	}
	public void Load(string name)
	{
		if(isLoad)
		{
			return;
		}
		isLoad = true;

		byte[] bin = DynamicFileControl.QueryFileContent(name);
		string content = StringHelper.ReadFromBytes(bin);

		LitJson.JSONNode json = LitJson.JSON.Parse(content);
		dataTests = new Dictionary<int, Dictionary<int, DataTest>>();

		foreach(LitJson.JSONNode subNode in json.Childs)
		{
			DataTest data = new DataTest();
			data.Load(subNode);
			Dictionary<int,DataTest> tests ;
			dataTests.TryGetValue(data.id,out tests);
			if(tests == null)
			{
				tests = new Dictionary<int, DataTest>();
				dataTests.Add(data.id,tests);
			}
			tests.Add(data.id,data);
		}
	}

 
}
