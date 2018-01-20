using SGF.Module.Framework;
using SGF.UI.Framework;
using SGame.Service.UserManager.Data;
using SGame.Service.User;
using UnityEngine.UI;
using SGame.Module;
using SGame.Game.Data;

namespace SGame
{
    public class UIHomePage:UIPage
    {
        public Text txtUserInfo;

        protected override void OnOpen(object arg = null)
        {
            base.OnOpen(arg);
            UpdateUserInfo();
        }


        private void UpdateUserInfo()
        {
            UserData ud = UserManager.Instance.MainUserData;
            txtUserInfo.text = ud.name + "(Lv."+ud.level+")";
        }


        public void OnBtnUserInfo()
        {
            UIAPI.ShowMsgBox("重新登录", "是否重新登录？", "确定|取消", o =>
            {
                if ((int) o == 0)
                {
                    HomeModule module = ModuleManager.Instance.GetModule(ModuleDef.HomeModule) as HomeModule;
                    module.TryReLogin();
                }
            });
        }


        private void OpenModule(string name, object arg = null)
        {
            var module = ModuleManager.Instance.GetModule("HomeModule") as HomeModule;
            if (module != null)
            {
                module.OpenModule(name, arg);
            }
        }


        public void OnBtnSetting()
        {
            UIManager.Instance.OpenWindow(UIDef.UILoginWnd,"啊哈哈");
            return;
            OpenModule(ModuleDef.SettingModule);
        }

        public void OnBtnDailyCheckIn()
        {
            OpenModule(ModuleDef.DailyCheckInModule);
        }

        public void OnBtnActivity()
        {
            OpenModule(ModuleDef.ActivityModule);
        }

        public void OnBtnBuyCoin()
        {
            OpenModule(ModuleDef.ShopModule, "BuyCoin");
        }

        public void OnBtnFreeCoin()
        {
            OpenModule(ModuleDef.ShareModule);
        }


        public void OnBtnEndlessPVE()
        {
			OpenModule(ModuleDef.PVEModule, (int)GameMode.EndlessPVE);
        }

        public void OnBtnTimelimitPVE()
        {
			OpenModule(ModuleDef.PVEModule, (int)GameMode.TimelimitPVE);
        }

        public void OnBtnPVP()
        {
            OpenModule(ModuleDef.PVPModule, (int)GameMode.EndlessPVP);
        }


    }
}
