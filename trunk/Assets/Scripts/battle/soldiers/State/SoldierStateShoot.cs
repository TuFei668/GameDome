using UnityEngine;
using System.Collections;

public class SoldierStateShoot : IState {

	public enum RESULT 
	{
		WORKING,
		DONM,
	}
	private RESULT _result = RESULT.WORKING;
	public RESULT result 
	{
		get { return _result;}
	}

	private Soldier soldier;

	public SoldierStateShoot(Soldier soldier)
	{
		this.soldier = soldier;
	}


	public void Enter()
	{
		Trace.trace("Enter SoldierShoot",Trace.CHANNEL.FIGHTING);
		soldier.gameObject.GetComponent<FrameAnimControl>().ChangeAnimtion(FrameAnimControl.ANIMATION.SHOOT,true);

	}

	public void Exit()
	{
		Trace.trace("Exit SoldierShoot",Trace.CHANNEL.FIGHTING);
		soldier.gameObject.GetComponent<FrameAnimControl>().ChangeAnimtion(FrameAnimControl.ANIMATION.IDLE,false);
	}

	public int Tick()
	{
		if(_result != RESULT.WORKING)
		{
			return (int)_result;
		}
		if(soldier.gameObject.GetComponent<FrameAnimControl>().IsPlayerFinish())
		{
			_result = RESULT.DONM;
			return (int)_result;
		}

		Trace.trace("Tick SoldierShoot",Trace.CHANNEL.FIGHTING);
		soldier.soliderFire.Update ();

		return (int)_result;
	}

}
