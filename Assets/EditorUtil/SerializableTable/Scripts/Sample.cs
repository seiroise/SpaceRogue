using System;

namespace EditorUtil {

	/// <summary>
	/// stringとfloatのペア
	/// </summary>
	[System.Serializable]
	public class StringFloat : KeyAndValue<string, float> { }

	/// <summary>
	/// stringとfloatのテーブル
	/// </summary>
	[System.Serializable]
	public class StringFloatTable : SerializableTable<string, float, StringFloat> { }

	/// <summary>
	/// stringとstringのペア
	/// </summary>
	[System.Serializable]
	public class StringString : KeyAndValue<string, string> { }

	/// <summary>
	/// stringとstringのテーブル
	/// </summary>
	[System.Serializable]
	public class StringStringTable : SerializableTable<string, string, StringString> { }
}