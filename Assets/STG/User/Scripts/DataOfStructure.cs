using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STG.User {

	/// <summary>
	/// 構造のデータ
	/// </summary>
	[Serializable]
	public class DataOfStructure {

		[SerializeField]
		private string _structureID;
		public string structureID { get { return _structureID; } }

		[SerializeField]
		private List<IDAndRemain> _weapons;     //装備武器
		public List<IDAndRemain> weapons { get { return _weapons; } }

		[SerializeField]
		private List<IDAndRemain> _thrusters;	//装備推進器
		public List<IDAndRemain> thrusters { get { return _thrusters; } }

		[SerializeField]
		private List<IDAndRemain> _addons;   //装備推進器
		public List<IDAndRemain> addons { get { return _addons; } }
	}
}