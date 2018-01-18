using UnityEngine;
using System.Collections;

public class SoldierStateDead : IState {

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

	public SoldierStateDead(Soldier soldier)
	{
		this.soldier = soldier;
	}

	public void Enter()
	{
		Trace.trace("Enter SoldierDead",Trace.CHANNEL.FIGHTING);
		soldier.gameObject.GetComponent<FrameAnimControl>().ChangeAnimtion(FrameAnimControl.ANIMATION.DEAD,false);
	}

	public void Exit()
	{

	}

	public int Tick()
	{
		if(_result != RESULT.WORKING)
		{
			return (int)_result;
		}

		return (int)_result;
	}

}