using UnityEngine;

public class BoolPrefs
{

	public static void SetBool(string key, bool state)
	{
		PlayerPrefs.SetInt(key, state ? 1 : 0);
	}

	public static bool GetBool(string key, bool _default = false)
	{
		int value = PlayerPrefs.GetInt(key, GetDefault(_default));
		return value == 1;
	}

	private static int GetDefault(bool value)
	{
		return value ? 1 : 0;
	}
}
