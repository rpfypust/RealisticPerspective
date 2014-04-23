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

	public static Flag GetInstance()
	{
		if (instance == null) {
			instance = new Flag();
		}
		return instance;
	}

	private Flag()
	{
		CurrentProgress = StoryProgress.NONE;
		NewProgress = StoryProgress.NONE;
		CompCleared = false;
		MechCleared = false;
		ElecCleared = false;
	}
}
