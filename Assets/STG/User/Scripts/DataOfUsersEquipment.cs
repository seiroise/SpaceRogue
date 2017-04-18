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
		private int maxWeaponNum { get { return _maxWeaponNum; } set { _maxWeaponNum = value; } }

		[SerializeField]
		private List<IDAndDurability> _weapons;     //所持武器

		[SerializeField]
		private int _maxThrusterNum;
		private int maxThrusterNum { get { return _maxThrusterNum; } set { _maxThrusterNum = value; } }

		[SerializeField]
		private List<IDAndDurability> _thrusters;   //所持推進器

		[SerializeField]
		private int _maxAddonNum;
		private int maxAddonNum { get { return _maxAddonNum; } set { _maxAddonNum = value; } }

		[SerializeField]
		private List<IDAndDurability> _addons;      //所持アドオン

		/// <summary>
		/// 武器の追加
		/// </summary>
		public void AddWeapon(string id, int durability) {
			if(_weapons.Count >= _maxWeaponNum) return;
			_weapons.Add(new IDAndDurability(id, durability));
		}

		/// <summary>
		/// スラスタの追加
		/// </summary>
		public void AddThruster(string id, int durability) {
			if(_thrusters.Count >= _maxThrusterNum) return;
			_thrusters.Add(new IDAndDurability(id, durability));
		}

		/// <summary>
		/// アドオンの追加
		/// </summary>
		public void AddAddon(string id, int durability) {
			if(_addons.Count >= _maxAddonNum) return;
			_addons.Add(new IDAndDurability(id, durability));
		}

	}
}