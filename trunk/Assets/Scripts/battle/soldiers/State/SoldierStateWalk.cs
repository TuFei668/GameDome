using UnityEngine;
using System.Collections;

public class SoldierStateWalk : IState {

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

	public SoldierStateWalk(Soldier soldier)
	{
		this.soldier = soldier;
	}


	public void Enter()
	{
		Trace.trace("Enter SoldierWalk",Trace.CHANNEL.FIGHTING);
		soldier.gameObject.GetComponent<FrameAnimControl>().ChangeAnimtion(FrameAnimControl.ANIMATION.WALK,false);
	}

	public void Exit()
	{
		Trace.trace("Exit SoldierWalk",Trace.CHANNEL.FIGHTING);
	}

	public int Tick()
	{
		if(_result != RESULT.WORKING)
		{
			return (int)_result;
		}
		Trace.trace("Tick SoldierWalk",Trace.CHANNEL.FIGHTING);
		return (int)_result;
	}

}