using UnityEngine;
using System.Collections.Generic;
using STG.Obj.Equipment;
using EditorUtil;

namespace STG.Obj.DataObj {

	/// <summary>
	/// STGの装備データオブジェクト
	/// </summary>
	public class STGEquipmentDataObj<TEquipment> : STGDataObj where TEquipment : STGObjEquipment {

		[Header("プレハブ")]
		[SerializeField]
		private TEquipment _equipment;
		public TEquipment equipment { get { return _equipment; } }

		[Header("基本情報")]
		[SerializeField]
		private STGEquipmentInfo _baseInfo;
		public STGEquipmentInfo baseInfo { get { return _baseInfo; } }

		[Header("パラメータ")]
		[SerializeField, Button("SetTemplate", "SetTemplateParameter")]
		public int _btn1;
		[SerializeField]
		private StringFloatTable _parameter;
		public StringFloatTable parameter { get { return _parameter; } }

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