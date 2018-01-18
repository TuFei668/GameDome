using UnityEngine;
using System.Collections;

/// <summary>
/// Frame ani control.
/// 帧动画控制器
/// </summary>
public class FrameAnimControl : MonoBehaviour {

	public enum ANIMATION 
	{
		NONE,
		IDLE,
		WALK,
		SHOOT,
		JUMP,
		ATTACK,
		BOMB,
		DEAD,
	}
	private GameObject _target; 

	private bool _attached = false;
	private Soldier _soldier;
	 
	private string _animName;
	private GameObject _frame;

	private Animator _framAnim;
	public Animator framAnim
	{
		get { return _framAnim; }
	}

	 
	private bool _needSwitchAnim = false;
	private ANIMATION _anim = ANIMATION.NONE;
	private bool _animLoop;
	private long _animStartTimestamp;


	void Start () {
 
	}
	
	 
	void Update () {
		UpdateAnim();
	}

	private void UpdateAnim()
	{
		if(!_attached)
		{
			return;
		}
		if (_needSwitchAnim) {
			_needSwitchAnim = false;
			RefreshAnim();
		}
	}

	private void RefreshAnim()
	{
		string name = "";
		switch(_anim)
		{
		case ANIMATION.IDLE:
			name = "idle";
			break;
		case ANIMATION.JUMP:
			name = "grenadeDie";
			break;
		case ANIMATION.SHOOT:
			name = "kill";
			break;
		case ANIMATION.WALK:
			name = "walking";
			break;
		case ANIMATION.DEAD:
			name = "die";
			break;
		}
		name = name;
	
		_framAnim.Play(name);
		_animStartTimestamp = TimeHelper.GetCurrentTimestampScaled ();


	}

	public bool IsPlayerFinish()
	{
		/*if (_animLoop) {
			return false;
		}
*/
		long ts = TimeHelper.GetCurrentTimestampScaled ();

		float ts1 = _framAnim.runtimeAnimatorController.animationClips [0].length * 1000;
		//_framAnim.runtimeAnimatorController.animationClips [0].wrapMode = WrapMode.Loop;


		long ts2 = ts - _animStartTimestamp;
		Trace.trace("IsPlayerFinish _framAnim   " + ts1,Trace.CHANNEL.FIGHTING);
		Trace.trace("IsPlayerFinish ts_animStartTimestamp   " + ts2 ,Trace.CHANNEL.FIGHTING);
		if (ts - _animStartTimestamp >=  _framAnim.runtimeAnimatorController.animationClips [0].length * 1000 )
		{
			return true;
		} else {
			return false;
		}
	}
	public void ChangeAnimtion(ANIMATION anim ,bool loop)
	{
		if(_anim != anim || _animLoop != loop)
		{
			_needSwitchAnim = true;
			_anim = anim;
			_animLoop = loop;
		}
	}

	/// <summary>
	/// 添加动画资源
	/// </summary>
	/// <param name="target">Target.</param>
	/// <param name="animName">Animation name.</param>
	public void Attach(GameObject target,string animName)
	{
		Assert.assert(!_attached);
		_attached = true;
	
		_target = target;

		_frame = ResourceHelper.Load(AppConfig.FOLDER_PROFAB_ANIMATION + animName);
		_frame.transform.parent = _target.transform;
		RenderHelper.ResetLocalTransform(_frame);

		_framAnim = _frame.GetComponent<Animator>();

		ChangeAnimtion(ANIMATION.IDLE,false);

	}

	public void DestryAttach()
	{
		_attached = false;

		DestroyImmediate(_frame);
		_frame = null;
	}
}
