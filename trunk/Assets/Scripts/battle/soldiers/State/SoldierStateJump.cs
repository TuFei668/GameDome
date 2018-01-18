using UnityEngine;
using System.Collections;

public class SoldierStateJump : IState {

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

	public SoldierStateJump(Soldier soldier)
	{
		this.soldier = soldier;
	}

	public void Enter()
	{
		Trace.trace("Enter SoldierJump",Trace.CHANNEL.FIGHTING);
		soldier.gameObject.GetComponent<FrameAnimControl>().ChangeAnimtion(FrameAnimControl.ANIMATION.JUMP,false);
	}

	public void Exit()
	{
		Trace.trace("Exit SoldierJump",Trace.CHANNEL.FIGHTING);
		soldier.gameObject.GetComponent<FrameAnimControl>().ChangeAnimtion(FrameAnimControl.ANIMATION.IDLE,false);
	}

	public int Tick()
	{
		Trace.trace("Tick SoldierJump",Trace.CHANNEL.FIGHTING);
		if(_result != RESULT.WORKING)
		{
			return (int)_result;
		}

		return (int)_result;
	}

}