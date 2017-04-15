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
	public class IDAndRemain {
		[SerializeField]
		private string _id;
		public string id { get { return _id; } }
		[SerializeField]
		private float _remain;
		public float remain { get { return _remain; } }
	}
}
