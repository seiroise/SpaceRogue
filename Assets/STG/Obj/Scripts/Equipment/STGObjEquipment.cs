﻿using UnityEngine;
using System;
using STG.Obj.DataObj;
using STG.BaseUtility.ComSystem;
using EditorUtil;

namespace STG.Obj.Equipment {

	/// <summary>
	/// 抽象的なSTGオブジェクト用の装備
	/// </summary>
	public abstract class STGObjEquipment : STGCom {

		[SerializeField]
		private STGEquipmentDataObj _dataObj;
		public STGEquipmentDataObj dataObj { get { return _dataObj; } }

		protected bool _isBusy; //起動状態
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

		/// <summary>
		/// パラメータの設定
		/// </summary>
		public abstract void SetParameter(StringFloatTable paramTable);

		/// <summary>
		/// 耐久値の取得
		/// </summary>
		public abstract int GetDurability();

		/// <summary>
		/// 耐久値の設定
		/// </summary>
		public abstract void SetDurability(int dulability);

		#endregion
	}
}