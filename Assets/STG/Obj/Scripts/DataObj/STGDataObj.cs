using UnityEngine;
using System;
using EditorUtil;

namespace STG.Obj.DataObj {

	/// <summary>
	/// STG用のデータオブジェクト
	/// </summary>
	public class STGDataObj : ScriptableObject {

		[SerializeField]
		protected string _id;
		public string id { get { return _id; } }

		[SerializeField]
		protected StringFloatTable _parameter;
		public StringFloatTable parameter { get { return _parameter; } }
	}
}