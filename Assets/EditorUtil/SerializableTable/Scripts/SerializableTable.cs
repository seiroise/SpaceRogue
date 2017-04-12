using UnityEngine;
using System.Collections.Generic;

namespace EditorUtil {

	/// <summary>
	/// シリアライズ可能な連想配列
	/// </summary>
	[System.Serializable]
	public class SerializableTable<TKey, TValue, TPair> where TPair : KeyAndValue<TKey, TValue>, new() {

		[SerializeField]
		protected List<TPair> _list;
		protected Dictionary<TKey, TValue> _table;
		[System.Obsolete]
		public Dictionary<TKey, TValue> table { get { return _table; } }

		public SerializableTable() {
			Reset();
		}

		/// <summary>
		/// 指定したkeyに対するvalueの取得
		/// </summary>
		public TValue GetValue(TKey key) {
			if(_table.ContainsKey(key)) {
				return _table[key];
			}
			return default(TValue);
		}

		/// <summary>
		/// 指定したkeyに指定したvalueを設定する
		/// </summary>
		public void SetValue(TKey key, TValue value) {
			if(_table.ContainsKey(key)) {
				_table[key] = value;
			} else {
				_table.Add(key, value);
			}
			Apply();
		}

		/// <summary>
		/// 指定したkeyを削除
		/// </summary>
		public void RemoveKey(TKey key) {
			if(_table.ContainsKey(key)) {
				_table.Remove(key);
			}
		}

		/// <summary>
		/// 初期化
		/// </summary>
		public void Reset() {
			_table = new Dictionary<TKey, TValue>();
			_list = new List<TPair>();
		}

		/// <summary>
		/// 変更の更新
		/// </summary>
		public void Apply() {
			_list = ConvertDictionaryToList(_table);
		}

		/// <summary>
		/// ペアのリストを辞書に変換する
		/// </summary>
		static Dictionary<TKey, TValue> ConvertListToDictionary(List<TPair> list) {
			Dictionary<TKey, TValue> table = new Dictionary<TKey, TValue>();
			foreach(var pair in list) {
				table.Add(pair.key, pair.value);
			}
			return table;
		}

		/// <summary>
		/// 辞書をペアのリストに変換する
		/// </summary>
		static List<TPair> ConvertDictionaryToList(Dictionary<TKey, TValue> table) {
			List<TPair> list = new List<TPair>();
			if(table != null) {
				foreach(var pair in table) {
					TPair t = new TPair();
					t.key = pair.Key;
					t.value = pair.Value;
					list.Add(t);
				}
			}
			return list;
		}
	}
}