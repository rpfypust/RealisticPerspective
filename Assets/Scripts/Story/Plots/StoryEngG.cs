using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngG : Plot {
    
    public Transform[] wayPoints;
    private List<Dialog> dialogs;
    private DialogManager dman;
    private CinematicCamera cam;
    private BGMManager bgm;
    private Actor alpha;
    private Actor delta;
    private Actor renroh;
    private Actor sci_A;
    private Actor sci_B;
    private Actor sci_C;
    
    private void Awake () {
        // initialize reference to dman
        dman = GetComponent<DialogManager>();
        bgm = GetComponentInChildren<BGMManager>();
        cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
        alpha = GameObject.Find("Alpha").GetComponent<Actor>();
        delta = GameObject.Find("Delta").GetComponent<Actor>();
        renroh = GameObject.Find("Renroh").GetComponent<Actor>();
        sci_A = GameObject.Find("ScientistA").GetComponent<Actor>();
        sci_B = GameObject.Find("ScientistB").GetComponent<Actor>();
        sci_C = GameObject.Find("ScientistC").GetComponent<Actor>();
        
        dialogs = new List<Dialog>();		
        
        dialogs.Add(new Dialog("Alpha", "!?",3));
        dialogs.Add(new Dialog("Alpha", "What’s now? What do those black dolls doing?",3));
        //Delta walkiin
        dialogs.Add(new Dialog("Delta", "They are performing someone’s “denied” memory."));
        dialogs.Add(new Dialog("Alpha", "Delta!",3));
        dialogs.Add(new Dialog("Alpha", "Why are you here?",2));
        dialogs.Add(new Dialog("Delta", "I’m just investigating nearby and I saw something strange here so I come to take a look."));
        dialogs.Add(new Dialog("Delta", "Silence now, just watch."));
        dialogs.Add(new Dialog("Delta", "This memory maybe has something to do with “the Reality”."));
        dialogs.Add(new Dialog("Alpha", "OK."));
        //Panning,Zoom
        dialogs.Add(new Dialog("Renroh", "... ... ... base on the above hypothesis... "));
        dialogs.Add(new Dialog("Renroh", "... ... ... the world maybe is not just one..."));
        dialogs.Add(new Dialog("Scientist A", "Stop joking, Dr. Renroh."));
        dialogs.Add(new Dialog("Scientist A", "The world is not just only one, are you serious?"));
        dialogs.Add(new Dialog("Renroh", "This’s not joking, I do meant it."));
        dialogs.Add(new Dialog("Renroh", "Let me explain one more time..."));
        dialogs.Add(new Dialog("Scientist B", "Dr. Renroh, it’s almost time to stop day dreaming."));
        dialogs.Add(new Dialog("Scientist C", "The once genius has become such a..."));
        dialogs.Add(new Dialog("Scientist A", "No, he is still a genius now..."));
        dialogs.Add(new Dialog("Scientist A", "A genius of science fiction."));
        dialogs.Add(new Dialog("Scientist B", "Haaaaaa!"));
        dialogs.Add(new Dialog("Scientist A", "We've no time for science fiction. See you."));
        //3S walkaway
        
        dialogs.Add(new Dialog("Renroh", "Wait... Give me one more chance please..."));
        dialogs.Add(new Dialog("Renroh", "Fail again... Once again I can’t fulfill my promise..."));
        //Memory Sence FadOut Effect
        dialogs.Add(new Dialog("Alpha", "Is it finished?",2));
        dialogs.Add(new Dialog("Delta", "Yes. And we’re lucky that its memory of insider and we got a name."));
        dialogs.Add(new Dialog("Delta", "Dr. Renroh, the proposer of “the Worlds”. I must investigate on him."));
        dialogs.Add(new Dialog("Alpha", "Okay."));
        dialogs.Add(new Dialog("Alpha", "By the way, why are you black like those dolls?",2));
        dialogs.Add(new Dialog("Delta", "Actually, everything in “the Inner World” has color in the beginning, but the longer the object stays at here, its color will fade away gradually."));
        dialogs.Add(new Dialog("Delta", "At the end, those things will become totally black..."));
        dialogs.Add(new Dialog("Delta", "Then they just disappear like those black dolls..."));
        dialogs.Add(new Dialog("Delta", "totally vanished from “the Worlds”"));
        dialogs.Add(new Dialog("Alpha", "Er... you are so black..."));
        dialogs.Add(new Dialog("Delta", "No, It's not what you think."));
        dialogs.Add(new Dialog("Delta", "It’s just my disguise so that I can do my investigation easily in “the Inner World”."));
        dialogs.Add(new Dialog("Alpha", "I see, that’s great then."));
        dialogs.Add(new Dialog("Alpha", "I just worrying you will disappear any time soon as you are that black."));
        dialogs.Add(new Dialog("Delta", "If you got time to worry others, I suggest you better work on the next enemy’s base."));
        dialogs.Add(new Dialog("Delta", "Anyway, I’ll contact you again after my investigation. See you."));//Delta Walkaway
        dialogs.Add(new Dialog("Alpha", "She really likes to give order..."));
    }
    
    public void Start()
    {
        base.startStoryScene();
    }
    
    protected override IEnumerator sequencer()
    {	
        yield return StartCoroutine(cam.SolidBlack(1f));
        StartCoroutine(cam.FadeOut());
        
        yield return StartCoroutine(alpha.walkWithTime(wayPoints[0],2));
        StartCoroutine(alpha.rotate(-90, 0.5f));
		bgm.changeVolume(0.3f);
        bgm.LoopBGM(0);
        dman.openDialog();
        yield return StartCoroutine(dman.display(dialogs[0],alpha.EmotionPt));
        yield return StartCoroutine(dman.interactToProceed());
        dman.closeDialog();
        StartCoroutine(cam.pan(new Vector3(0,0.5f,0),1));
        
        StartCoroutine(renroh.tunnelOut());
        StartCoroutine(sci_A.tunnelOut());
        StartCoroutine(sci_B.tunnelOut());
        yield return StartCoroutine(sci_C.tunnelOut());
        
        yield return StartCoroutine(cam.pan(new Vector3(0,-0.5f,0),1));
        dman.openDialog();
        yield return StartCoroutine(dman.display(dialogs[1],alpha.EmotionPt));
        yield return StartCoroutine(dman.interactToProceed());
        dman.closeDialog();
        yield return StartCoroutine(delta.tunnelOut());
        yield return StartCoroutine(delta.walkWithTime(wayPoints[1],2));
        StartCoroutine(delta.faceTo(alpha.transform,0.5f));
        yield return StartCoroutine(alpha.faceTo(delta.transform,0.5f));
        
        dman.openDialog();
        for (int index = 2; index < 10; index++) {
            switch(dialogs[index].Speaker)
            {
                case "Alpha":
                    yield return StartCoroutine(dman.display(dialogs[index],alpha.EmotionPt));
                    yield return StartCoroutine(dman.interactToProceed());
                    break;
                    
                case "Delta":
                    yield return StartCoroutine(dman.display(dialogs[index],delta.EmotionPt));
                    yield return StartCoroutine(dman.interactToProceed());
                    break;
            }
        }
        dman.closeDialog();
        
        StartCoroutine(delta.faceTo(renroh.transform,0.5f));
        StartCoroutine(alpha.faceTo(renroh.transform,0.5f));
        yield return StartCoroutine(cam.pan(new Vector3(0,1,2),2));
        
        dman.openDialog();
        for (int index = 9; index < 23; index++) {
            if(index == 21)
            {
                
                StartCoroutine(sci_A.vanish());
                StartCoroutine(sci_B.vanish());
                StartCoroutine(sci_C.vanish());
                yield return new WaitForSeconds(0.5f);
            }
            switch(dialogs[index].Speaker)
            {
                case "Renroh":
                    yield return StartCoroutine(dman.display(dialogs[index],renroh.EmotionPt));
                    yield return StartCoroutine(dman.interactToProceed());
                    break;
                    
                case "Scientist A":
                    yield return StartCoroutine(dman.display(dialogs[index],sci_A.EmotionPt));
                    yield return StartCoroutine(dman.interactToProceed());
                    break;
                    
                case "Scientist B":
                    yield return StartCoroutine(dman.display(dialogs[index],sci_B.EmotionPt));
                    yield return StartCoroutine(dman.interactToProceed());
                    break;
                    
                case "Scientist C":
                    yield return StartCoroutine(dman.display(dialogs[index],sci_C.EmotionPt));
                    yield return StartCoroutine(dman.interactToProceed());
                    break;
            }
        }
        dman.closeDialog();
        
        StartCoroutine(renroh.vanish());
        yield return StartCoroutine(cam.pan(new Vector3(0,-1,-2),2));
        StartCoroutine(delta.faceTo(alpha.transform,0.5f));
        yield return StartCoroutine(alpha.faceTo(delta.transform,0.5f));
        
        StartCoroutine(cam.pan(new Vector3(0,0.1f,0.5f),10));
        dman.openDialog();
        for (int index = 23; index < 39; index++) {
            switch(dialogs[index].Speaker)
            {
                case "Alpha":
                    yield return StartCoroutine(dman.display(dialogs[index],alpha.EmotionPt));
                    yield return StartCoroutine(dman.interactToProceed());
                    break;
                    
                case "Delta":
                    yield return StartCoroutine(dman.display(dialogs[index],delta.EmotionPt));
                    yield return StartCoroutine(dman.interactToProceed());
                    break;
            }
        }
        
        yield return StartCoroutine(delta.tunnelIn());
        yield return StartCoroutine(dman.display(dialogs[39],alpha.EmotionPt));
        yield return StartCoroutine(dman.interactToProceed());
        dman.closeDialog();
        
        StartCoroutine(cam.FadeIn());
    }
}
