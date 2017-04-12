using UnityEngine;
using System;
using STG.Obj.DataObj;
using STG.BaseUtility.ComSystem;

namespace STG.Obj.Equipment {

	/// <summary>
	/// 抽象的なSTGオブジェクト用の装備
	/// </summary>
	public abstract class STGObjEquipment : STGCom {

		protected bool _isBusy;	//起動状態
		public bool isBusy { get { return _isBusy; } }

		#region VirtualFunction

		public override void STGInit(STGComManager manager) {
			base.STGInit(manager);
			StandDownEquipment();
		}

		/// <summary>
		/// 起動状態へ
		/// </summary>
		public virtual void StandUpEquipment() {
			_isBusy = true;
		}

		/// <summary>
		/// 待機状態へ
		/// </summary>
		public virtual void StandDownEquipment() {
			_isBusy = false;
		}

		#endregion
	}
}