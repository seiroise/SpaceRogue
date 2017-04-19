using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STG.User {

	/// <summary>
	/// idと消耗度のデータ
	/// </summary>
	[Serializable]
	public class IDAndDurability {

		[SerializeField]
		private string _id;
		public string id { get { return _id; } }
		[SerializeField]
		private int _durability;
		public int durability { get { return _durability; } }

		public IDAndDurability(string id, int durability) {
			_id = id;
			_durability = durability;
		}
	}
}
