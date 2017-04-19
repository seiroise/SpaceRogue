using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STG.Obj.DataObj;

/// <summary>
/// 装備のリスト表示
/// </summary>
public class EquipmentListPanel : MonoBehaviour {

	public RectTransform itemParent;    //アイテムの親オブジェクト
	public GameObject listItemPrefab;   //リストに表示するアイテム
	[Range(1, 10)]
	public int maxShowItems = 6;		//表示する最大値

	#region Function

	/// <summary>
	/// リストを表示
	/// </summary>
	public void Show(STGEquipmentDataObj[] equipments) {
		Debug.Log(equipments.Length);
		foreach(var e in equipments) {
			var g = Instantiate<GameObject>(listItemPrefab);
			g.transform.SetParent(itemParent, false);
		}
	}

	#endregion
}