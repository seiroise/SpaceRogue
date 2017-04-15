using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STG.User {

	/// <summary>
	/// ユーザデータオブジェクト
	/// </summary>
	public class UserDataObj : ScriptableObject {

		[SerializeField]
		private DataOfStructure _structure;
		public DataOfStructure structure { get { return _structure; } }

		[SerializeField]
		private DataOfUsersEquipment _equipments;
		public DataOfUsersEquipment equipments { get { return _equipments; } }
	}
}