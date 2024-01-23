using UnityEngine;

public static class Math
{
	const float PI = 3.141593f;

	public static float ToDegrees(float radian)
	{
		return (radian * 180) / PI;
	}

	public static float ToRadians(float degree)
	{
		return degree * PI / 180;
	}

	public static bool NearlyEqual(float f1, float f2, float closeValue = 0.001f)
	{
		float check = f1 - f2;
		return (Mathf.Abs(check) < closeValue);
	}

	public static int Round (float value)
	{
		return (int)value;
	}

	public static float Min(float a, float b)
	{
		if (a < b) return a;
		
		return b;
	}

	public static float Max(float a, float b)
	{
		if (a > b) return a;
		
		return b;
	}
}
