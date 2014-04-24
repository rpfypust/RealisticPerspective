using UnityEngine;

public class Flag {

	private static Flag instance;

	public enum StoryProgress {
		NONE,
		A,
		B,
		C,
		D,
		E,
		G,
		F,
		I,
		J,
		K,
		L,
		M
	}

	public StoryProgress CurrentProgress;
	public StoryProgress NewProgress;
	public bool CompCleared;
	public bool MechCleared;
	public bool ElecCleared;
	public bool PhoenixCleared;

	public static Flag GetInstance()
	{
		if (instance == null) {
			instance = new Flag();
		}
		return instance;
	}

	public static void SetInstance(Flag f)
	{
		instance = f;
	}

	public int ClearedStageCount()
	{
		int count = 0;
		count += (CompCleared)? 1 : 0;
		count += (ElecCleared)? 1 : 0;
		count += (MechCleared)? 1 : 0;
		return count;
	}

	public void LogFlags()
	{
		Debug.Log("Current progress: " + CurrentProgress);
		Debug.Log("NewProgress: " + NewProgress);
		Debug.Log("CompCleared: " + CompCleared);
		Debug.Log("MechCleared: " + MechCleared);
		Debug.Log("ElecCleared: " + ElecCleared);
		Debug.Log("PhoenixCleared: " + PhoenixCleared);
	}

	public Flag(StoryProgress c,
	            StoryProgress n,
	            bool p,
	            bool q,
	            bool r,
	            bool s)
	{
		CurrentProgress = c;
		NewProgress = n;
		CompCleared = p;
		MechCleared = q;
		ElecCleared = r;
		PhoenixCleared = s;
	}

//	public Flag(StoryProgress c = StoryProgress.NONE,
//	            StoryProgress n = StoryProgress.NONE,
//	            bool p = false,
//	            bool q = false,
//	            bool r = false,
//	            bool s = false)
//	{
//		CurrentProgress = c;
//		NewProgress = n;
//		CompCleared = p;
//		MechCleared = q;
//		ElecCleared = r;
//		PhoenixCleared = s;
//	}

	public Flag()
	{
		CurrentProgress = StoryProgress.NONE;
		NewProgress = StoryProgress.NONE;
		CompCleared = false;
		MechCleared = false;
		ElecCleared = false;
		PhoenixCleared = false;
	}
}
