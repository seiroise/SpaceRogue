using UnityEngine;
using System;

namespace STG.Obj.DataObj {

	/// <summary>
	/// STGデータオブジェクトの基本情報
	/// </summary>
	[Serializable]
	public class STGBaseInfo {

		[SerializeField]
		private string _name;
		public string name { get { return _name; } }

		[SerializeField]
		private Sprite _appearance;
		public Sprite appearance { get { return _appearance; } }

		[SerializeField, TextArea]
		private string _description;
		public string description { get { return _description; } }
	}
}