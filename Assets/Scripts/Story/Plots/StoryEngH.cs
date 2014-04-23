using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryEngH : Plot
{
    
    public Transform[] wayPoints;
    private List<Dialog> dialogs;
    private DialogManager dman;
    private CinematicCamera cam;
    private BGMManager bgm;
    private SEManager sem;
    private Actor alpha;
    private Actor alice;
    
    private void Awake()
    {
        // initialize reference to dman
        dman = GetComponent<DialogManager>();
        cam = GameObject.FindGameObjectWithTag(Tags.mainCamera).GetComponent<CinematicCamera>();
        bgm = GetComponentInChildren<BGMManager>();
        sem = GetComponentInChildren<SEManager>();
        alpha = GameObject.Find("Alpha").GetComponent<Actor>();
        alice = GameObject.Find("Alice").GetComponent<Actor>();
        
        dialogs = new List<Dialog>();
        
        dialogs.Add(new Dialog("Alpha", "Once again, not here...", 1));
        dialogs.Add(new Dialog("Alpha", "And Delta has not contacted me...", 1));
        dialogs.Add(new Dialog("Alpha", "I better go for the next base as soon as possible to rescue Beta.", 1));
        //Alice WalkIn
        dialogs.Add(new Dialog("Alice", "Alpha, you skip class again!", 3));
        dialogs.Add(new Dialog("Alice", "You will be suffering in “the Reeducation camp” soon or later."));
        dialogs.Add(new Dialog("Alpha", "No, I'm just free only..."));
        dialogs.Add(new Dialog("Alice", "Then what are you sneaking around here for?", 2));
        dialogs.Add(new Dialog("Alpha", "I'm investigating..."));
        dialogs.Add(new Dialog("Alice", "Okay, what are you investigating?", 2));
        dialogs.Add(new Dialog("Alpha", "Beta, of course. What else can it be?"));
        dialogs.Add(new Dialog("Alice", "Oh, sorry..."));
        dialogs.Add(new Dialog("Alice", "I'm too busy latterly that I almost forget this."));
        dialogs.Add(new Dialog("Alice", "Have you found her then?", 2));
        dialogs.Add(new Dialog("Alpha", "Not yet, but almost."));
        dialogs.Add(new Dialog("Alice", "Alpha, you're really working hard for Beta."));
        dialogs.Add(new Dialog("Alpha", "Of course. She's my best friends after all."));
        dialogs.Add(new Dialog("Alice", "Ah...")); 
        dialogs.Add(new Dialog("Alice", "Is there anything I can help?", 2));
        dialogs.Add(new Dialog("Alpha", "Sure."));
        dialogs.Add(new Dialog("Alpha", "Then do you know Dr. Renroh?", 2));
        dialogs.Add(new Dialog("Alice", "Dr. Renroh..."));
        dialogs.Add(new Dialog("Alpha", "No? Let it be then."));
        dialogs.Add(new Dialog("Alice", "Ya... Sorry..."));
        //alarm sounds
        dialogs.Add(new Dialog("Alpha", "Hey, your alarm is ringing. Do you need to go to lecture now?", 2));
        dialogs.Add(new Dialog("Alice", "Oh no!", 3));
        dialogs.Add(new Dialog("Alice", "I've to go now! See you."));
        //Alice Walk away
        dialogs.Add(new Dialog("Alpha", "OK, I need to work on the next base too."));
        
    }
    
    public void Start()
    {
        base.startStoryScene();
    }
    
    protected override IEnumerator sequencer()
    {   
        yield return StartCoroutine(cam.SolidBlack(1f));
        StartCoroutine(cam.FadeOut());
        bgm.PlayBGM(0);
        yield return StartCoroutine(alpha.tunnelOut());
        StartCoroutine(cam.rotateY(130, 2));
        yield return StartCoroutine(alpha.walkWithTime(wayPoints [0], 2));
        
        dman.openDialog();
        yield return StartCoroutine(dman.display(dialogs [0], alpha.EmotionPt));
        yield return StartCoroutine(dman.interactToProceed());
        yield return StartCoroutine(dman.display(dialogs [1], alpha.EmotionPt));
        yield return StartCoroutine(dman.interactToProceed());
        yield return StartCoroutine(dman.display(dialogs [2], alpha.EmotionPt));
        yield return StartCoroutine(dman.interactToProceed());
        dman.closeDialog();
        yield return StartCoroutine(alice.runWithTime(wayPoints [1], 2));
        StartCoroutine(cam.pan(new Vector3(0, -0.25f, 0), 2));
        yield return StartCoroutine(cam.orbitMotion(wayPoints [2], -60, 2));
        
        dman.openDialog();
        for (int index = 3; index < 26; index++)
        {
            if (index == 23)
                sem.PlaySoundEffect(0);

            switch (dialogs [index].Speaker)
            {
                case "Alpha":
                    yield return StartCoroutine(dman.display(dialogs [index], alpha.EmotionPt));
                    yield return StartCoroutine(dman.interactToProceed());
                    break;
                
                case "Alice":
                    yield return StartCoroutine(dman.display(dialogs [index], alice.EmotionPt));
                    yield return StartCoroutine(dman.interactToProceed());
                    break;
            }
        }
        
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(alice.runWithTime(wayPoints [3], 4));
        StartCoroutine(cam.pan(new Vector3(0, 0.25f, 0), 0.5f));
        yield return StartCoroutine(cam.orbitMotion(wayPoints [2], 60, 0.5f));
        yield return new WaitForSeconds(3.5f);
        Destroy(GameObject.Find("Alice"));
        yield return StartCoroutine(dman.display(dialogs [26], alpha.EmotionPt));
        yield return StartCoroutine(dman.interactToProceed());
        dman.closeDialog();
        
        StartCoroutine(cam.FadeIn());
    }
}

