using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SGF.UI.Framework;
using SGF;
namespace SGame
{
	public class UILoginWindow : UIWindow {

		 protected override void OnOpen(object arg = null)
        {
            base.OnOpen(arg);
			this.Log("  " + arg.ToString());
		}
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}
