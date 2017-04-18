using UnityEngine;
using System.Collections.Generic;
using STG.Obj.Equipment;
using EditorUtil;

namespace STG.Obj.DataObj {

	/// <summary>
	/// 種類
	/// </summary>
	public enum EquipmentType {
		Weapon,
		Thruster,
		Addon
	}

	/// <summary>
	/// STGの装備データオブジェクト
	/// </summary>
	public class STGEquipmentDataObj : STGDataObj {
		
		[Header("プレハブ")]
		[SerializeField]
		private STGObjEquipment _equipment;
		public STGObjEquipment equipment { get { return _equipment; } }

		[Header("基本情報")]
		[SerializeField]
		private EquipmentType _type;
		[SerializeField]
		private STGBaseInfo _baseInfo;
		public STGBaseInfo baseInfo { get { return _baseInfo; } }

		[SerializeField, Button("SetTemplate", "SetTemplateParameter")]
		public int _btn1;

		/// <summary>
		/// テンプレパラメータの設定
		/// </summary>
		public void SetTemplateParameter() {
			parameter.Reset();
			switch(_type) {
				case EquipmentType.Weapon:
				parameter.SetValue("ammo", 100f);
				parameter.SetValue("attackPower", 10f);
				parameter.SetValue("shotInterval", 0.5f);
				parameter.SetValue("shotRange", 100f);
				parameter.SetValue("shotSpeed", 30f);
				break;
				case EquipmentType.Thruster:
				parameter.SetValue("fuel", 1000f);
				parameter.SetValue("thrustPower", 10f);
				break;
				case EquipmentType.Addon:
				parameter.SetValue("effect", 10f);
				break;
			}
		}
	}

	/// <summary>
	/// STGの装備データオブジェクト
	/// </summary>
	public class STGEquipmentDataObj<Equipment> : STGDataObj where Equipment : STGObjEquipment{

		[Header("プレハブ")]
		[SerializeField]
		private Equipment _equipment;
		public Equipment equipment { get { return _equipment; } }

		[Header("基本情報")]
		[SerializeField]
		private EquipmentType _type;
		[SerializeField]
		private STGBaseInfo _baseInfo;
		public STGBaseInfo baseInfo { get { return _baseInfo; } }

		[SerializeField, Button("SetTemplate", "SetTemplateParameter")]
		public int _btn1;

		/// <summary>
		/// テンプレパラメータの設定
		/// </summary>
		public void SetTemplateParameter() {
			parameter.Reset();
			switch(_type) {
			case EquipmentType.Weapon:
				parameter.SetValue("ammo", 100f);
				parameter.SetValue("attackPower", 10f);
				parameter.SetValue("shotInterval", 0.5f);
				parameter.SetValue("shotRange", 100f);
				parameter.SetValue("shotSpeed", 30f);
				break;
			case EquipmentType.Thruster:
				parameter.SetValue("fuel", 1000f);
				parameter.SetValue("thrustPower", 10f);
				break;
			case EquipmentType.Addon:
				parameter.SetValue("effect", 10f);
				break;
			}
		}
	}
}