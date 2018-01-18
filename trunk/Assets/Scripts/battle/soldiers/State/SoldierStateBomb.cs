﻿using UnityEngine;
using System.Collections;

public class SoldierStateBomb : IState {

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

	public SoldierStateBomb(Soldier soldier)
	{
		this.soldier = soldier;
	}

	public void Enter()
	{

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