using UnityEngine;
using System.Collections;

public class Soldier : MonoBehaviour {

	private int _slotIndex;
	public int slotIndex
	{
		get { return _slotIndex; }
	}

	private StateMachine _stateMachine = new StateMachine();
	public StateMachine stateMachine 
	{
		get { return _stateMachine; }
	}

	public bool isDead
	{
		get {
			return (_stateMachine.currentState is SoldierStateDead);
		}
	}


//	 逻辑层
//		private InstanceUnit _unit;
//		public InstanceUnit unit
//		{
//			get { return _unit; }
//		}
//	数据层
//		private DataConfig.TEAM _team;
//		public DataConfig.TEAM team
//		{
//			get { return _team; }
//		}
//	各种部位添加控制
//	private UnitFire _unitFire;
//	public UnitFire unitFire
//	{
//		get { return _unitFire; }
//	}
//
//	private UnitDriver _unitDriver;
//	public UnitDriver unitDriver
//	{
//		get { return _unitDriver; }
//	}
//	碰撞检测
//	private UnitCollisionDetector _collisionDetector;
//	public UnitCollisionDetector collisionDetector
//	{
//		get { return _collisionDetector; }
//	}

	private SoldierFire _soliderFire;
	public SoldierFire soliderFire
	{
		get { return _soliderFire; } 
	}

	// Use this for initialization
	void Start () {
		
		_stateMachine.Change(new SoldierStateIdle(this));
		_soliderFire = new SoldierFire (this);
	}
	
	// Update is called once per frame
	void Update () {
	
		UpdateStateMachine();
			
	}

	void UpdateStateMachine()
	{
		int result = _stateMachine.Tick();

		IState state = _stateMachine.currentState;
		if(state is SoldierStateIdle)
		{
			Trace.trace("Soldier Idle",Trace.CHANNEL.FIGHTING);
		}
		else if(state is SoldierStateWalk)
		{
			Trace.trace("Soldier Walk",Trace.CHANNEL.FIGHTING);
		}
		else if(state is SoldierStateDead)
		{
			Trace.trace("Soldier Dead",Trace.CHANNEL.FIGHTING);
		}
		else if(state is SoldierStateJump)
		{
			Trace.trace("Soldier Jump",Trace.CHANNEL.FIGHTING);
		}
		else if(state is SoldierStateShoot)
		{
			Trace.trace("Soldier  Shoot",Trace.CHANNEL.FIGHTING);
			if(result == (int)SoldierStateShoot.RESULT.DONM)
			{
				_stateMachine.Change(new SoldierStateIdle (this));
			}
		}
	}

	//public void Init(InstanceUnit unit, DataConfig.TEAM team, Vector3 fightPos, int slotIndex) 初始化基本数据
	public void Init(int slotIndex)
	{
		_slotIndex = slotIndex;
		FrameAnimControl fram = GetComponent<FrameAnimControl>();
		if(fram != null)
		{
			fram.Attach(gameObject,"enemy");
		}
	}

	public void ToWalk()
	{
		Assert.assert(!isDead);
		stateMachine.Change(new SoldierStateWalk(this));
	}

	public void ToJump()
	{
		Assert.assert(!isDead);
		stateMachine.Change(new SoldierStateJump(this));
	}

	public void ToShoot()
	{
		Assert.assert(!isDead);
		stateMachine.Change(new SoldierStateShoot(this));
	}

	public void ToDead()
	{
		Assert.assert (!isDead);
		_stateMachine.Change (new SoldierStateDead(this));


	}
	public void ToIdle()
	{
		Assert.assert (!isDead);
		_stateMachine.Change (new SoldierStateIdle(this));


	}


}
