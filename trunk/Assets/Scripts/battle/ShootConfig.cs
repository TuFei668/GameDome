using UnityEngine;
using System.Collections;

public class ShootConfig  {

	//layer
	public enum LAYER
	{
		NONE,
		SOLIDER,
		BACKGROUND,
		ENVCOLLIDER,
		BULLET,
		EFFECT,
		OTHER,
	}
	public static string GetLayerName(LAYER layer)
	{
		switch (layer) {
		case LAYER.SOLIDER: return "LayerSolider";
		case LAYER.BACKGROUND: return "LayerBackground";
		case LAYER.ENVCOLLIDER: return "LayerEnvCollider";
		case LAYER.BULLET: return "LayerEffect";
		case LAYER.EFFECT: return "LayerBullet";
		case LAYER.OTHER: return "LayerOther";
		}

		return null;
	}
/// <summary>
/// UI Name
/// </summary>
	public static string UI_MAIN = AppConfig.FOLDER_PROFAB_UI + "UI_Main" ;
  
}
