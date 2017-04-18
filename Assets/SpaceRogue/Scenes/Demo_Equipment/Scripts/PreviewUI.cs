using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using STG.Obj.DataObj;
using STG.Obj.Weapon;
using STG.Obj.Thruster;

namespace SpaceRogue.Scenes.Demo_Equipment.Scripts {

	/// <summary>
	/// 装備のプレビューUI
	/// </summary>
	public class PreviewUI : MonoBehaviour {

		[Header("STGObj Preview")]
		public EquipmentPreviewer stgObjPreviewer;
		public Transform equipmentParent;
		private List<Image> weaponPreviews;
		private List<Image> thrusterPreviews;

		[Header("WeaponPreview")]
		public EquipmentPreviewer weaponPreviewerPrefab;
		public Sprite emptyWeapon;
		public STGEquipmentDataObj weaponEmptyDataObj;

		[Header("ThrusterPreview")]
		public EquipmentPreviewer thrusterPreviewerPrefab;
		public Sprite emptyThruster;
		public STGEquipmentDataObj thrusterEmptyDataObj;

		[Header("EquipmentDeteil")]
		public EquipmentDeteilGroup equipmentDeteil;

		[Header("PreviewAdjust")]
		[Range(1f, 200f)]
		public float adjustScale = 50f;

		private STGStructureDataObj _previewSTGObj;

		#region Function

		/// <summary>
		/// 指定したSTG構造体の表示
		/// </summary>
		public void Show(STGStructureDataObj structure) {
			if(!structure) return;
			_previewSTGObj = structure;
			//構造のイメージを表示
			stgObjPreviewer.SetEquipmentPreview(
				structure.baseInfo.appearance,
				stgObjPreviewer.transform.localPosition,
				0,
				OnClickSTGObjPreview
			);

			//武器の位置にプレビューを表示
			if(weaponPreviews == null) {
				weaponPreviews = new List<Image>();
			} else {
				weaponPreviews.Clear();
			}
			var wCom = structure.structure.GetCom<STGObjWeaponController>();
			if(wCom) {
				Vector3 pos = Vector3.zero;
				wCom.IterateComs((i, com) => {
					var previewer = Instantiate<EquipmentPreviewer>(weaponPreviewerPrefab);
					previewer.transform.SetParent(equipmentParent, false);
					//座標
					pos.x = com.com.transform.localPosition.x;
					pos.y = com.com.transform.localPosition.y;
					previewer.SetEquipmentPreview(
						emptyWeapon,
						pos * adjustScale,
						i,
						OnClickWeaponPreview
					);
				});
			}

			//スラスタの位置にプレビューを表示
			if(thrusterPreviews == null) {
				thrusterPreviews = new List<Image>();
			} else {
				thrusterPreviews.Clear();
			}
			var tCom = structure.structure.GetCom<STGObjThrusterController>();
			if(tCom) {
				Vector3 pos = Vector3.zero;
				tCom.IterateComs((i, com) => {
					var previewer = Instantiate<EquipmentPreviewer>(thrusterPreviewerPrefab);
					previewer.transform.SetParent(equipmentParent, false);
					//座標
					pos.x = com.com.transform.localPosition.x;
					pos.y = com.com.transform.localPosition.y;
					previewer.SetEquipmentPreview(
						emptyThruster,
						pos * adjustScale,
						i,
						OnClickThrusterPreview
					);
				});
			}
		}

		#endregion

		#region Callback

		/// <summary>
		/// STGObjの見た目をクリック
		/// </summary>
		private void OnClickSTGObjPreview(int i) {
			Debug.Log("STGObj: " + i);
		}

		/// <summary>
		/// 武器の見た目をクリック
		/// </summary>
		private void OnClickWeaponPreview(int i) {
			Debug.Log("Weapon: " + i);
			var slot = _previewSTGObj.structure.GetCom<STGObjWeaponController>()[i];
			if(slot.isSeted) {
				equipmentDeteil.ShowDeteil(slot.equipment.dataObj);
			} else {
				equipmentDeteil.ShowDeteil(weaponEmptyDataObj);
			}
		}

		/// <summary>
		/// スラスタの見た目をクリック
		/// </summary>
		private void OnClickThrusterPreview(int i) {
			Debug.Log("Thruster: " + i);
			var slot = _previewSTGObj.structure.GetCom<STGObjThrusterController>()[i];
			if(slot.isSeted) {
				equipmentDeteil.ShowDeteil(slot.equipment.dataObj);
			} else {
				equipmentDeteil.ShowDeteil(thrusterEmptyDataObj);
			}
		}

		#endregion
	}
}