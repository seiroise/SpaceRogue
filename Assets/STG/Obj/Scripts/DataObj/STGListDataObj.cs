using UnityEngine;
using System.Collections.Generic;

namespace STG.Obj.DataObj {

	/// <summary>
	/// STG用のリストデータオブジェクト
	/// </summary>
	public class STGListDataObj<T> : STGDataObj where T : STGDataObj {
		
		[SerializeField]
		private T[] _datas;
		private Dictionary<string, T> _cash;	//検索結果のキャッシュ

		#region Function

		/// <summary>
		/// ランダムに取得
		/// </summary>
		public T Get() {
			return _datas[Random.Range(0, _datas.Length)];
		}

		/// <summary>
		/// IDを指定して取得
		/// </summary>
		public T Get(string id) {
			if (_cash == null) {
				_cash = new Dictionary<string, T>();
				foreach (var t in _datas) {
					if(!_cash.ContainsKey(t.id)) {
						_cash.Add(t.id, t);
					}
				}
			}
			return _cash.ContainsKey(id) ? _cash[id] : null;
		}

		#endregion
	}
}