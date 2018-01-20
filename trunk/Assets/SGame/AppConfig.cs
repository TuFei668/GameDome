using UnityEngine;
using System.Collections;
using ProtoBuf;
using SGame.Service.UserManager.Data;
using SGF;
namespace SGame
{
	/// <summary>
	/// App的配置定义
	/// </summary>
	[ProtoContract]
	public class AppConfig {

		//global setting
		public const bool DEBUGGING = true;
		public const bool USE_FIXED_FRAMERATE = DEBUGGING && true;
		public const bool USE_DYNAMIC_CONFIG = !DEBUGGING || false;

		public const bool SHOW_TILE = DEBUGGING && false;
		public const bool SHOW_PATH = SHOW_TILE && false;
		public const bool SHOW_HOTFIELD = SHOW_TILE && false;


		//table
		public const string TAB_MAIN_CAMERA = "MainCamera";
		public const string TAB_UI_CAMERA = "UICamera";
		public const string TAB_HTTP = "HTTP";
		public const string TAB_BATTLE_GAME = "battle_game";
		public const string TAB_SCENE_ROOT = "SceneRoot";


		//scene name
		public const string SCENE_NAME_UI = "SceneMainUI";
		public const string SCENE_NAME_BATTLE = "SceneBattle";
		public const string SCENE_NAME_LOADING = "SceneLoading";
		public const string SCENE_NAME_BATTLE_OFFLINE = "SceneBattleOffline";


		//folder
		public const string FOLDER_PROFAB = "Prefabs/";

		public const string FOLDER_PROFAB_ANIMATION = FOLDER_PROFAB + "animation/";
		public const string FOLDER_PROFAB_TANK = FOLDER_PROFAB + "tank/";

		public const string FOLDER_PROFAB_EFFECT 			  = FOLDER_PROFAB + "effect/";
		public const string FOLDER_PROFAB_EFFECT_EXPLODE 	  = FOLDER_PROFAB_EFFECT + "explode/";

		public const string FOLDER_PROFAB_CAMPAIGN = FOLDER_PROFAB + "campaign/";

		public const string FOLDER_PROFAB_UI = FOLDER_PROFAB + "UI/";
		public const string FOLDER_PROFAB_UI_HUDTEXT = FOLDER_PROFAB_UI + "hudtext/";

		public const string FOLDER_DATACONFIG = "DataConfig/";

		//orientation
		public static Vector3 DEFAULT_DIRECTION = new Vector3(0, 0, 1);
		public static Vector3 DEFAULT_ANGLE = new Vector3 (40, 0, 0);
		public static Vector3 SHADOW_DIRECTION = new Vector3 (0.2f, -1, -0.5f);


		//design resolution
		public const float DESIGN_WIDTH  = 1334.0f;
		public const float DESIGN_HEIGHT = 750.0f;

		// Unity单位1 对应 UI 缩放比例 
		public static float UI_ASPECT_HEIGHT = DESIGN_HEIGHT / Screen.height;
		public static Vector3 UNITY_SCALE_UI = new Vector3((Screen.height / UI_ASPECT_HEIGHT / 2.0f), (Screen.height / UI_ASPECT_HEIGHT / 2.0f), 0.0f);

		//camera direction
		public const float CAMERA_DEGREE = 50;
		public const float CAMERA_RADIAN = Mathf.PI * CAMERA_DEGREE / 180;

		// sortingOrder 
		public const int SORTINGORDER_UI_POPUP = 10;



		// mission
		public const int FIRST_MISSION_MAGICID = 10101;


		/// <summary>
		/// 主用户数据
		/// </summary>
		[ProtoMember(1)] public UserData mainUserData = new UserData();
		[ProtoMember(2)] public bool enableBgMusic = true;
		[ProtoMember(3)] public bool enableSoundEffect = true;


			//============================================================================
			private static AppConfig m_Value = new AppConfig();
			public static AppConfig Value { get { return m_Value; } }

	#if UNITY_EDITOR
			public readonly static string Path = Application.persistentDataPath + "/AppConfig_Editor.data";
	#else
			public readonly static string Path = Application.persistentDataPath + "/AppConfig.data";
	#endif

			public static void Init()
			{
				Debuger.Log("AppConfig", "Init() Path = " + Path);

				byte[] data = FileUtils.ReadFile(Path);
				if (data != null && data.Length > 0)
				{
					AppConfig cfg = (AppConfig)PBSerializer.NDeserialize(data, typeof(AppConfig));
					if (cfg != null)
					{
						m_Value = cfg;
					}
				}
			}

			public static void Save()
			{
				Debuger.Log("AppConfig", "Save() Value = " + m_Value);

				if (m_Value != null)
				{
					byte[] data = PBSerializer.NSerialize(m_Value);
					FileUtils.SaveFile(Path, data);
				}
			}

    }
}
