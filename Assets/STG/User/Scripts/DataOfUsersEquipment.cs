using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STG.User {

	/// <summary>
	/// ユーザの所持装備データ
	/// </summary>
	[Serializable]
	public class DataOfUsersEquipment {

		[SerializeField]
		private int _maxWeaponNum;
		private int maxWeaponNum { get { return _maxWeaponNum; } }
		
		[SerializeField]
		private List<IDAndRemain> _weapons;		//所持武器
		public List<IDAndRemain> weapons { get { return _weapons; } }

		[SerializeField]
		private int _maxThrusterNum;
		private int maxThrusterNum { get { return _maxThrusterNum; } }

		[SerializeField]
		private List<IDAndRemain> _thrusters;	//所持推進器
		public List<IDAndRemain> thrusters { get { return _thrusters; } }

		[SerializeField]
		private int _maxAddonNum;
		private int maxAddonNum { get { return _maxAddonNum; } }

		[SerializeField]
		private List<IDAndRemain> _addons;		//所持アドオン
		public List<IDAndRemain> addons { get { return _addons; } }
	}
}