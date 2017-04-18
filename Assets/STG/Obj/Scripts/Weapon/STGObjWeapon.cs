using UnityEngine;
using System;
using STG.Obj.Equipment;
using STG.BaseUtility.ObjectDetector;
using STG.BaseUtility.ComSystem;
using STG.Bullet;
using EditorUtil;

namespace STG.Obj.Weapon {

	/// <summary>
	/// STG用の武器
	/// </summary>
	public class STGObjWeapon : STGObjEquipment {

		//パラメータ
		public const string PARAM_DAMAGE = "damage";
		public const string PARAM_INTERVAL = "interval";
		public const string PARAM_SHOT_RANGE = "shotRange";
		public const string PARAM_SHOT_SPEED = "shotSpeed";
		public const string PARAM_AMMO = "ammo";

		[SerializeField, Disable]
		private STGObjWeaponParameter _baseParameter;	//基本パラメータ
		public STGObjWeaponParameter baseParameter { get { return _baseParameter; } }

		[Header("弾")]
		[SerializeField]
		private STGBullet _bullet;						//使用する弾
		public STGBullet bullet { get { return _bullet; } }
		private STGBulletPool.Pool _bulletPool;			//使用する弾のプール
		[SerializeField]
		private Transform[] _shotPositions;				//発射箇所リスト
		[SerializeField]
		private string _bulletExclusionTag = "None";	//除外タグ
		public string bulletExclusionTag { get { return _bulletExclusionTag; } set { _bulletExclusionTag = value; } }

		[Header("オプション")]
		[SerializeField]
		private ObjectAttribute _targetAttribute;       //ターゲット属性
		public ObjectAttribute targetAttribute { get { return _targetAttribute; } set { _targetAttribute = value; } }

		[Header("コンポーネント")]
		[SerializeField]
		private STGObjWeaponCom[] _coms;                 //その他コンポーネント

		private float _bLifeTime;                       //弾の生存時間
		private float _tInterval;						//発射間隔
		public float readyRatio { get { return _tInterval / _baseParameter.interval; } }	//発射準備割合

		#region UnityEvent

		private void Update() {
			if (_isBusy) {
				Reload();
			}
		}

		#endregion

		#region VirtualFunction

		/// <summary>
		/// 初期化
		/// </summary>
		public override void STGInit(STGComManager manager) {
			base.STGInit(manager);
			_tInterval = 0f;
			if(_baseParameter != null) {
				_bLifeTime = _baseParameter.lifeTime;
			}
			InitComs();
		}

		/// <summary>
		/// 武器起動
		/// </summary>
		public override void StandUpEquipment() {
			base.StandUpEquipment();
			AwakeComs();
		}

		/// <summary>
		/// 武器待機
		/// </summary>
		public override void StandDownEquipment() {
			base.StandDownEquipment();
			StandbyComs();
		}

		/// <summary>
		/// パラメータの設定
		/// </summary>
		public override void SetParameter(StringFloatTable paramTable) {
			_baseParameter.damage = (int)paramTable.GetValue(PARAM_DAMAGE);
			_baseParameter.interval = (int)paramTable.GetValue(PARAM_INTERVAL);
			_baseParameter.shotRange = (int)paramTable.GetValue(PARAM_SHOT_RANGE);
			_baseParameter.shotSpeed = (int)paramTable.GetValue(PARAM_SHOT_SPEED);
			_baseParameter.ammo = (int)paramTable.GetValue(PARAM_AMMO);
		}

		/// <summary>
		/// 耐久値の取得
		/// </summary>
		public override int GetDurability() {
			throw new NotImplementedException();
		}

		/// <summary>
		/// 耐久値の設定
		/// </summary>
		public override void SetDurability(int dulability) {
			throw new NotImplementedException();
		}

		#endregion

		#region Function

		/// <summary>
		/// 再装填
		/// </summary>
		private void Reload() {
			_tInterval += Time.deltaTime;
			if (_tInterval > _baseParameter.interval) {
				Shot();
				_tInterval = 0f;
			}
		}

		/// <summary>
		/// 発射
		/// </summary>
		private void Shot() {
			if (_bulletPool != null) {
				foreach (var shotPos in _shotPositions) {
					STGBullet b = _bulletPool.GetObject(shotPos.position);
					b.transform.eulerAngles = shotPos.eulerAngles;
					b.InitBullet(this);
					b.Attacker.ExclusionTag = _bulletExclusionTag;
					b.Attacker.Damage = _baseParameter.damage;
					b.speed = _baseParameter.shotSpeed;
					b.LifeTime = _bLifeTime;
					ShotComs(b);
				}
			}
		}
		
		/// <summary>
		/// 弾の設定
		/// </summary>
		public void SetBullet(STGBulletPool pool) {
			if (_bulletPool == null) {
				_bulletPool = pool.RegistObject(_bullet);
			}
		}

		#endregion

		#region ComFunction

		/// <summary>
		/// 初期化
		/// </summary>
		private void InitComs() {
			foreach (var c in _coms) {
				c.InitCom(this);
			}
		}

		/// <summary>
		/// 起動
		/// </summary>
		private void AwakeComs() {
			foreach (var c in _coms) {
				c.AwakeCom();
			}
		}

		/// <summary>
		/// 待機
		/// </summary>
		private void StandbyComs() {
			foreach (var c in _coms) {
				c.StandbyCom();
			}
		}

		/// <summary>
		/// 発射
		/// </summary>
		private void ShotComs(STGBullet bullet) {
			foreach (var c in _coms) {
				c.ShotCom(bullet);
			}
		}

		#endregion
	}
}