using UnityEngine;
using System.Collections;

public class SoldierFire  {

	public class ShootParm
	{
		public float damage = 0;
		public bool isMiss = false;
		public bool isDoubleDamage = false;
	}
	private Soldier _solider;

	private long _lastAttackTime = 0;
	private int _shootTimes;
	private long _lastShootTime;

	private bool _isAttacking = false;
	public bool isAttacking
	{
		get { return _isAttacking; }
	}
		
	private const bool ALWAYS_MISS = false;


	public SoldierFire(Soldier solider)
	{
		_solider = solider;
	}
		
	public void Update()
	{
		CheckCD ();
		UpdateFire ();
	}

	private void CheckCD()
	{
		if (!_isAttacking) {

			long ct = TimeHelper.GetCurrentTimestampScaled();
			long dt = ct - _lastAttackTime;
			if (dt >= 0.5 * 1000) {//_unit.unit.dataUnit.shootCD
				_isAttacking = true;
 
				_shootTimes = 0;
				_lastShootTime = ct;
				/*
				if(_unit.unit.dataUnit.stopToFire)
				{
					_unit.unitDriver.Stop(false);
					float delay = 
						_unit.unitDriver.GetEstimateBreakingTime() +
						_unit.unit.dataUnit.firePrepareTime;
					_lastShootTime += (long)delay * 1000;
				}
				*/
			}
		}
	}
	private void UpdateFire()
	{
		if (_isAttacking) {

			long ct = TimeHelper.GetCurrentTimestampScaled();
			long dt = ct - _lastShootTime;
			float interval = 1 * 1000;//_unit.unit.dataUnit.fireInterval
			if (dt >= interval) {

				Shoot();

				_lastAttackTime = ct;
				_lastShootTime = ct;

				++_shootTimes;
				if(_shootTimes >= 2 )//_unit.unit.dataUnit.fireCount
				{
					AttackEnd();
				}

			}

		}
	}

	private void AttackEnd()
	{
		_isAttacking = false;

	/*	if(_unit.unit.dataUnit.stopToFire)
		{
			_unit.unitDriver.Resume(false);
		}*/
	}
	private void Shoot()
	{
		ShootParm shoot = new ShootParm();
		shoot.isMiss = IsMiss();
		shoot.isDoubleDamage = IsDoubleDamage();
		shoot.damage = 60;
		//创建子弹
		CreateBullet(shoot);

	}

	//公共方法
	private void CreateBullet(ShootParm shoot)
	{
		string resName = AppConfig.FOLDER_PROFAB + "bullet/bullet0";

		GameObject obj = ResourceHelper.Load(resName);

		ShootFactory.AddSoloiderTOLayer (obj,ShootConfig.LAYER.BULLET);
		_solider.ToShoot ();

		obj.GetComponent<Bullet> ().Create (shoot,_solider);
	}

	private bool IsMiss()
	{
		if (ALWAYS_MISS) {
			return true;
		}

		float random = RandomHelper.Range01();

//		float a = _unit.unit.complexBattleParam.hitRate;
//		float d = currentTarget.target.unit.complexBattleParam.dodgeRate;
		float DODGE_EFFECT_RATE = 0.25f;
//		float rate = a * (1 - d * DODGE_EFFECT_RATE);

		bool isMiss = random > DODGE_EFFECT_RATE;//rate
		return isMiss;
	}

	private bool IsDoubleDamage()
	{
		bool isDoubleDamage = false;

//		InstanceUnit instanceUnit = _unit.unit;
		float randRate = RandomHelper.Range01 ();

		if (randRate < 3) {//instanceUnit.complexBattleParam.doubleDamageRate
			isDoubleDamage = true;		
		}

		return isDoubleDamage;
	}

//	private float CalcDamage(bool doubleDamage)
//	{
//		float power = _unit.unit.complexBattleParam.damage;
//		float ammo = currentTarget.target.unit.complexBattleParam.ammo;
//
//		float damage = power * power / (power + ammo);
//		if (damage < 1) {
//			damage = 1;
//		}
//		damage *= _unit.unit.GetLiveCount ();
//
//		if (doubleDamage) {
//			float DOUBLE_DAMAGE_RATE = 2;
//			damage *= DOUBLE_DAMAGE_RATE;
//		}
//
//		Assert.assert(damage >= 0);
//		damage = Mathf.Min (currentTarget.target.unit.currentHp, damage);
//
//		return damage;
//	}
}

