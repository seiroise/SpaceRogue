using UnityEngine;
using System;

namespace STG.Obj.Equipment {

	/// <summary>
	/// 種類
	/// </summary>
	public enum Type {
		Weapon,
		Thruster,
		Addon
	}

	/// <summary>
	/// STGの装備情報
	/// </summary>
	[Serializable]
	public class STGEquipmentInfo {

		[SerializeField]
		private string _name;
		public string name { get { return _name; } }

		[SerializeField]
		private Type _type;
		public Type type { get { return _type; } }

		[SerializeField]
		private Sprite _appearance;
		public Sprite appearance { get { return _appearance; } }

		[SerializeField, TextArea]
		private string _description;
		public string description { get { return _description; } }
	}
}