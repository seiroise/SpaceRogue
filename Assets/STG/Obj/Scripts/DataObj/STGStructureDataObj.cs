using UnityEngine;
using System.Collections;

namespace STG.Obj.DataObj {

	/// <summary>
	/// STG構造体のデータオブジェクト
	/// </summary>
	public class STGStructureDataObj : STGDataObj {

		[Header("プレハブ")]
		[SerializeField]
		private STGObj _structure;
		public STGObj structure { get { return _structure; } }

		[Header("基本情報")]
		[SerializeField]
		private STGBaseInfo _baseInfo;
		public STGBaseInfo baseInfo { get { return _baseInfo; } }
	}
}