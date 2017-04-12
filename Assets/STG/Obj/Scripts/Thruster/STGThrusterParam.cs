using UnityEngine;
using System;

namespace STG.Obj.Thruster {

	/// <summary>
	/// STGのスラスタパラメータ
	/// </summary>
	public class STGThrusterParam {

		[SerializeField]
		private float _thrustPower; //推進力
		public float thrustPower { get { return thrustPower; } }

		[SerializeField]
		private float _fuel;    //燃料
		public float fuel { get { return _fuel; } }
	}
}