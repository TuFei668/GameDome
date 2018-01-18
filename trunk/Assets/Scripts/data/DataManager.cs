using UnityEngine;
using System.Collections;

public class DataManager {

	private static DataManager _instance = null;
	public static DataManager instance
	{
		get
		{
			if (_instance == null) {
				_instance = new DataManager();
			}
			return _instance;
		}
	}

	private bool _isLoaded = false;

	public void InitData()
	{
		if (!_isLoaded) 
		{

			dataBuildingGroup.Load(AppConfig.FOLDER_DATACONFIG + "Building.json");
			datatestGround.Load(AppConfig.FOLDER_DATACONFIG + "testDatax.json");

			_isLoaded = true;
		}
	}



	private DataBuildingGroup _dataBuildingGroup = new DataBuildingGroup ();
	public DataBuildingGroup dataBuildingGroup
	{
		get { return _dataBuildingGroup; }
	}

	private DataTestGroup _dataTestsGroup = new DataTestGroup();
	public DataTestGroup datatestGround
	{
		get{return _dataTestsGroup; }
	}

}
