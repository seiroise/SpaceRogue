using UnityEngine;
using System;
using STG.Obj.Equipment;
using EditorUtil;

namespace STG.Obj.Addon {

	/// <summary>
	/// STG用のシステム
	/// </summary>
	public class STGObjAddon : STGObjEquipment {

		public override int GetDulability() {
			throw new NotImplementedException();
		}

		public override void SetDulability(int dulability) {
			throw new NotImplementedException();
		}

		public override void SetParameter(StringFloatTable paramTable) {
			throw new NotImplementedException();
		}
	}
}