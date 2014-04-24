using UnityEngine;
using System.Collections;
using StoryProgress = Flag.StoryProgress;

public class SceneTransition : MonoBehaviour {

	private GameController gamecon;

	void Awake()
	{
		gamecon = GameObject.FindGameObjectWithTag(Tags.gameController)
			.GetComponent<GameController>();
	}

	void Start () {
		Flag flag = Flag.GetInstance();

		Debug.Log(Application.persistentDataPath);
		XMLUtil.SaveXML(Application.persistentDataPath+"/save.data", flag);

		switch (flag.CurrentProgress) {
		case StoryProgress.A:
			flag.NewProgress = StoryProgress.B;
			break;
		case StoryProgress.B:
			flag.NewProgress = StoryProgress.C;
			break;
		case StoryProgress.C:
			flag.NewProgress = StoryProgress.D;
			break;
		case StoryProgress.D:
			flag.NewProgress = StoryProgress.E;
			break;
		case StoryProgress.E:
			if (flag.ClearedStageCount() >= 1)
				flag.NewProgress = StoryProgress.G;
			break;
		case StoryProgress.F:
			if (flag.ClearedStageCount() >= 2)
				flag.NewProgress = StoryProgress.I;
			break;
		case StoryProgress.G:
			flag.NewProgress = StoryProgress.F;
			break;
		case StoryProgress.I:
			flag.NewProgress = StoryProgress.J;
			break;
		case StoryProgress.J:
			if (flag.ClearedStageCount() >= 3)
				flag.NewProgress = StoryProgress.K;
			break;
		case StoryProgress.K:
			flag.NewProgress = StoryProgress.L;
			break;
		case StoryProgress.L:
			if (flag.PhoenixCleared) {
				flag.NewProgress = StoryProgress.M;
			}
			break;
		case StoryProgress.M:
			gamecon.LoadLevel(SceneIndice.TITLE);
			break;
		}

		if (flag.NewProgress != Flag.StoryProgress.NONE) {
			flag.CurrentProgress = flag.NewProgress;
			flag.NewProgress = Flag.StoryProgress.NONE;
			switch (flag.CurrentProgress) {
			case StoryProgress.A:
				gamecon.LoadLevel(SceneIndice.A);
				break;
			case StoryProgress.B:
				gamecon.LoadLevel(SceneIndice.B);
				break;
			case StoryProgress.C:
				gamecon.LoadLevel(SceneIndice.C);
				break;
			case StoryProgress.D:
				gamecon.LoadLevel(SceneIndice.D);
				break;
			case StoryProgress.E:
				gamecon.LoadLevel(SceneIndice.E);
				break;
			case StoryProgress.F:
				gamecon.LoadLevel(SceneIndice.F);
				break;
			case StoryProgress.G:
				gamecon.LoadLevel(SceneIndice.G);
				break;
			case StoryProgress.I:
				gamecon.LoadLevel(SceneIndice.I);
				break;
			case StoryProgress.J:
				gamecon.LoadLevel(SceneIndice.J);
				break;
			case StoryProgress.K:
				gamecon.LoadLevel(SceneIndice.K);
				break;
			case StoryProgress.L:
				gamecon.LoadLevel(SceneIndice.L);
				break;
			case StoryProgress.M:
				gamecon.LoadLevel(SceneIndice.M);
				break;
			}
		} else {
			gamecon.LoadLevel(SceneIndice.DEFAULT);
		}
	}

}
