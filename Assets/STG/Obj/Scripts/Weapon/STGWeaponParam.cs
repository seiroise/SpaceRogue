using UnityEngine;
using System;

namespace STG.Obj.Weapon {

	/// <summary>
	/// STG用の武器パラメータ
	/// </summary>
	public class STGWeaponParam {

		[SerializeField]
		private int _ammo;  //残弾
		public int ammo { get { return _ammo; } }

		[SerializeField]
		private float _attackPower;	
		public float attackPower { get { return _attackPower; } }

		[SerializeField]
		private float _shotInterval;	//発射間隔
		public float shotInterval { get { return _shotInterval; } }

		[SerializeField]
		private float _shotRange;	//射程
		public float shotRange { get { return _shotRange; } }

		[SerializeField]
		private float _shotSpeed;	//弾速
		public float shotSpeed { get { return _shotSpeed; } }
	}
}