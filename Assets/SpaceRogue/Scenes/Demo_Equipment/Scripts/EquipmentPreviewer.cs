using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

/// <summary>
/// 装備プレビュー
/// </summary>
[RequireComponent(typeof(RectTransform), typeof(Image))]
public class EquipmentPreviewer : MonoBehaviour, IPointerClickHandler {

	[SerializeField]
	private Image _image;

	private RectTransform _trans;
	private int _index;
	private Action<int> _callback;

	private void Awake() {
		_trans = GetComponent<RectTransform>();
	}

	public void SetEquipmentPreview(Sprite sprite, Vector3 position, int index, Action<int> onClick) {
		SetSprite(sprite);
		SetLocalPosition(position);
		_index = index;
		_callback = onClick;
	}

	/// <summary>
	/// imageにspriteを設定する
	/// </summary>
	public void SetSprite(Sprite sprite) {
		if(!_image) return;
		_image.sprite = sprite;
		_image.preserveAspect = true;
		_image.SetNativeSize();
		_image.rectTransform.pivot = new Vector2(
			sprite.pivot.x / sprite.rect.width,
			sprite.pivot.y / sprite.rect.height
		);
	}

	/// <summary>
	/// 座標の設定
	/// </summary>
	public void SetLocalPosition(Vector3 position) {
		_trans.localPosition = position;
	}

	/// <summary>
	/// クリック
	/// </summary>
	public void OnPointerClick(PointerEventData eventData) {
		if(_callback != null) {
			_callback(_index);
		}
	}
}