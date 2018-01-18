using UnityEngine;
using System.Collections;

public class ShootFactory  {

	public static GameObject CreateSolider()
	{
		GameObject go = ResourceHelper.Load(AppConfig.FOLDER_PROFAB + "solider/solider");
		ShootFactory.AddSoloiderTOLayer(go,ShootConfig.LAYER.SOLIDER);
		return go;

	}

	/// <summary>
	/// 添加gameObject 到指定层
	/// </summary>
	/// <param name="obj">Object.</param>
	/// <param name="layer">Layer.</param>
	public static void AddSoloiderTOLayer(GameObject obj,ShootConfig.LAYER layer)
	{
		GameObject root = GameObject.FindGameObjectWithTag(AppConfig.TAB_SCENE_ROOT);
		if(root != null)
		{
			string layerName = ShootConfig.GetLayerName(layer);
			if(layerName != null)
			{
				Transform layerSolider = root.transform.FindChild(layerName);
				obj.transform.parent = layerSolider.transform;
			}
		}
	}


}
