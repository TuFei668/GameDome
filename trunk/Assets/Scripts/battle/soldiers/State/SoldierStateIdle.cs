using UnityEngine;
using System.Collections;

public class SoldierStateIdle : IState {

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

	public SoldierStateIdle(Soldier soldier)
	{
		this.soldier = soldier;
	}

	public void Enter()
	{
		Trace.trace("Enter SoldierIdle",Trace.CHANNEL.FIGHTING);
		soldier.gameObject.GetComponent<FrameAnimControl>().ChangeAnimtion(FrameAnimControl.ANIMATION.IDLE,false);
	}

	public void Exit()
	{
		Trace.trace("Exit SoldierIdle",Trace.CHANNEL.FIGHTING);
	}

	public int Tick()
	{
		Trace.trace("Tick SoldierIdle",Trace.CHANNEL.FIGHTING);
		if(_result != RESULT.WORKING)
		{
			return (int)_result;
		}

		return (int)_result;
	}

}
