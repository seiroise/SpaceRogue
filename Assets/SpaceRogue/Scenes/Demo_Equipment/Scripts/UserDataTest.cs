using UnityEngine;
using System.Collections;
using STG.User;
using STG.Obj.DataObj;

namespace SpaceRogue.Scenes.Demo_Equipment.Scripts {

	public class UserDataTest : MonoBehaviour {

		public EquipmentSystemUI equipmentSystemUI;
		public STGStructureDataObj structure;

		public void Start() {
			if(!equipmentSystemUI) return;
			equipmentSystemUI.previewUI.Show(structure);
		}
	}
}