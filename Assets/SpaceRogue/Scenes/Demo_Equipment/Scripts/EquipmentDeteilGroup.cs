using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using STG.Obj.DataObj;

/// <summary>
/// 装備詳細グループ
/// </summary>
public class EquipmentDeteilGroup : MonoBehaviour {

	public Image appearance;
	public Text description;

	public void ShowDeteil(STGEquipmentDataObj equipmentDataObj) {
		if(appearance) {
			appearance.sprite = equipmentDataObj.baseInfo.appearance;
			description.text = equipmentDataObj.baseInfo.description;
		}
	}
}