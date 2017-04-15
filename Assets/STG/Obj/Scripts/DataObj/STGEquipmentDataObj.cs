using UnityEngine;
using System.Collections.Generic;
using STG.Obj.Equipment;
using EditorUtil;

namespace STG.Obj.DataObj {

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
		private STGEquipmentInfo _baseInfo;
		public STGEquipmentInfo baseInfo { get { return _baseInfo; } }

		[SerializeField, Button("SetTemplate", "SetTemplateParameter")]
		public int _btn1;

		/// <summary>
		/// テンプレパラメータの設定
		/// </summary>
		public void SetTemplateParameter() {
			parameter.Reset();
			switch(_baseInfo.type) {
			case Type.Weapon:
				parameter.SetValue("ammo", 100f);
				parameter.SetValue("attackPower", 10f);
				parameter.SetValue("shotInterval", 0.5f);
				parameter.SetValue("shotRange", 100f);
				parameter.SetValue("shotSpeed", 30f);
				break;
			case Type.Thruster:
				parameter.SetValue("fuel", 1000f);
				parameter.SetValue("thrustPower", 10f);
				break;
			case Type.Addon:
				parameter.SetValue("effect", 10f);
				break;
			}
		}
	}
}