using UnityEngine;
using System;

namespace STG.Obj.DataObj {

	/// <summary>
	/// STG用のデータオブジェクト
	/// </summary>
	public class STGDataObj : ScriptableObject {

		[SerializeField]
		private string _id;
		public string id { get { return _id; } }
	}
}