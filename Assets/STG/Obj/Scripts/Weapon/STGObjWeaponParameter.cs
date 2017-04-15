using UnityEngine;
using System;
using System.Collections.Generic;

namespace STG.Obj.Weapon {

	/// <summary>
	/// STGオブジェクト用の武器のパラメータ
	/// </summary>
	[Serializable]
	public class STGObjWeaponParameter {
		
		[SerializeField, Range(1, 1000)]
		private int _damage;		//攻撃力
		public int damage { get { return _damage; } set { _damage = value; } }

		[SerializeField, Range(0.01f, 10f)]
		private float _interval;	//間隔
		public float interval { get { return _interval; } set { _interval = value; } }
		
		[SerializeField, Range(1, 200)]
		private float _shotRange;	//射程
		public float shotRange { get { return _shotRange; } set { _shotRange = value; } }
		
		[SerializeField, Range(1, 200)]
		private float _shotSpeed;	//射速
		public float shotSpeed { get { return _shotSpeed; } set { _shotSpeed = value; } }

		[SerializeField, Range(1, 1000)]
		private int _ammo;			//残弾
		public int ammo { get { return _ammo; } set { _ammo = value; } }

		//弾の生存時間(射程と射速の関係から)
		public float lifeTime { get { return _shotRange / _shotSpeed; } }
	}
}