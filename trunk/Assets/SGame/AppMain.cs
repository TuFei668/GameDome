using SGF;
using UnityEngine;
using SGF.UI.Framework;
using SGF.Module.Framework;
using SGF.Network;
using SGame;
using SGame.Service.User;

public class AppMain : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
		Debuger.Log (Debuger.LogFileDir);
        Debuger.EnableLog = true;
        AppConfig.Init();

	    InitServices();
	    InitBusiness();

        ModuleManager.Instance.ShowModule(ModuleDef.LoginModule);
    }

    private void InitServices()
    {
        ModuleManager.Instance.Init("SGame.Module");

		NetworkManager.Instance.Init ();

        UIManager.Instance.Init("UI/");
        UIManager.MainPage = UIDef.UIHomePage;
        UIManager.MainScene = "Main";

        UserManager.Instance.Init();

      //  GameManager.Instance.Init();
    }


    private void InitBusiness()
    {
        ModuleManager.Instance.CreateModule(ModuleDef.LoginModule);
        ModuleManager.Instance.CreateModule(ModuleDef.HomeModule);
        ModuleManager.Instance.CreateModule(ModuleDef.PVEModule);
        ModuleManager.Instance.CreateModule(ModuleDef.PVPModule);
        ModuleManager.Instance.CreateModule(ModuleDef.HostModule);
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(UIManager.Instance != null)
                UIManager.Instance.GoBackPage();
        }
	}

}
