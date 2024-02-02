using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleOnBoardingAnimationManager : MonoBehaviour
{
    CameraMovementAnimation cameraMovementAnimation1;
    CameraMovementAnimation cameraMovementAnimation2;

    bool dialogueIsActive = false;
    GameObject speechBubble1;
    GameObject speechBubble2;
    GameObject speechBubble3;
    GameObject speechBubble4;
    GameObject speechBubble5;
    GameObject speechBubble6;
    GameObject speechBubble7;
    GameObject speechBubble8;
    GameObject speechBubble9;
    GameObject speechBubble10;

    GameObject messageWindow;
    MessageWindow messageWindowScript;

    GameObject Advisor;
    GameObject LoadDiningSceneMusic;

    private int lenghtOfMessagePresentation = 2;

    void Start() {
        messageWindow = GameObject.Find("MessageWindow");
        messageWindowScript = messageWindow.GetComponent<MessageWindow>();
        messageWindowScript.DeactivateMessageWindow();

        LoadDiningSceneMusic = GameObject.Find("LoadDiningSceneMusic");

        cameraMovementAnimation1 = GameObject.Find("IntermediatePosition").GetComponent<CameraMovementAnimation>();
        cameraMovementAnimation2 = GameObject.Find("FinalPosition").GetComponent<CameraMovementAnimation>();

        Advisor = GameObject.Find("Advisor");
        speechBubble1 = GameObject.Find("SpeechBubble1");
        speechBubble2 = GameObject.Find("SpeechBubble2");
        speechBubble3 = GameObject.Find("SpeechBubble3");
        speechBubble4 = GameObject.Find("SpeechBubble4");
        speechBubble5 = GameObject.Find("SpeechBubble5");
        speechBubble6 = GameObject.Find("SpeechBubble6");
        speechBubble7 = GameObject.Find("SpeechBubble7");
        speechBubble8 = GameObject.Find("SpeechBubble8");
        speechBubble9 = GameObject.Find("SpeechBubble9");
        speechBubble10 = GameObject.Find("SpeechBubble10");

        messageWindow = GameObject.Find("MessageWindow");

        HideAllSpeechBubbles();

        cameraMovementAnimation1.initializeAnimation();

        Advisor.SetActive(false);
    }

    void HideAllSpeechBubbles() 
    {
        speechBubble1.SetActive(false);
        speechBubble2.SetActive(false);
        speechBubble3.SetActive(false);
        speechBubble4.SetActive(false);
        speechBubble5.SetActive(false);
        speechBubble6.SetActive(false);
        speechBubble7.SetActive(false);
        speechBubble8.SetActive(false);
        speechBubble9.SetActive(false);
        speechBubble10.SetActive(false);
    }

    void Update()
    {
        if (cameraMovementAnimation1.AnimationIsDone == false)
        {
            cameraMovementAnimation1.step_to_target(CameraMovementAnimation.StepOptions.time_count);
        } else 
        {
            if (cameraMovementAnimation2.AnimationIsDone == false)
            {
                cameraMovementAnimation2.step_to_target(CameraMovementAnimation.StepOptions.time_count);
            }
            else 
            {   
                if (dialogueIsActive == false) 
                {
                    dialogueIsActive = true;
                    DialogueAnimation();
                }              
            }
        }
    }

    private void DialogueAnimation(){
            speechBubble1.SetActive(true);
            StartCoroutine(Action1());
    }

    IEnumerator Action1()
    {
        yield return new WaitForSeconds(3);
        speechBubble1.SetActive(false);
        CameraMovementAnimation cameraMovementAnimation = GameObject.Find("AdvisorAnimation").GetComponent<CameraMovementAnimation>();
        Advisor.SetActive(true);
        StartCoroutine(moveAdvisorEveryFrame(3, cameraMovementAnimation));
        Animator animator = Advisor.GetComponent<Animator>();
        RuntimeAnimatorController controller = AnimationLibrary.getAnimationController(AnimationLibrary.Animations.Talk);
        animator.runtimeAnimatorController = controller;
        StartCoroutine(Action2());

    }

    IEnumerator Action2()
    {
        yield return new WaitForSeconds(lenghtOfMessagePresentation);
        speechBubble2.SetActive(true);
        StartCoroutine(Action3());
    }

    IEnumerator Action3()
    {
        yield return new WaitForSeconds(lenghtOfMessagePresentation);
        speechBubble3.SetActive(true);
        StartCoroutine(Action4());
    }

    IEnumerator Action4()
    {
        yield return new WaitForSeconds(lenghtOfMessagePresentation);
        LoadDiningSceneMusic.GetComponent<AudioSource>().volume = 0.1f;
        speechBubble4.SetActive(true);
        StartCoroutine(Action5());
    }
    IEnumerator Action5()
    {
        yield return new WaitForSeconds(lenghtOfMessagePresentation);
        speechBubble5.SetActive(true);
        StartCoroutine(Action6());
    }

    IEnumerator Action6()
    {
        yield return new WaitForSeconds(lenghtOfMessagePresentation);
        speechBubble6.SetActive(true);
        StartCoroutine(Action7());
    }

    IEnumerator Action7()
    {
        yield return new WaitForSeconds(lenghtOfMessagePresentation);
        speechBubble7.SetActive(true);
        StartCoroutine(Action8());
    }

    IEnumerator Action8()
    {
        yield return new WaitForSeconds(lenghtOfMessagePresentation);
        speechBubble8.SetActive(true);
        StartCoroutine(Action9());
    }

    IEnumerator Action9()
    {
        yield return new WaitForSeconds(lenghtOfMessagePresentation);
        speechBubble9.SetActive(true);
        StartCoroutine(Action10());
    }

    IEnumerator Action10()
    {
        yield return new WaitForSeconds(lenghtOfMessagePresentation);
        speechBubble10.SetActive(true);
        StartCoroutine(Action11());
    }

    IEnumerator Action11()
    {
        yield return new WaitForSeconds(lenghtOfMessagePresentation);
        HideAllSpeechBubbles();
        Advisor.SetActive(false);
        messageWindowScript.SetupMessageWindowByMessageObject(new MessageObjectBlueprint.messageObject(
            "Ein Auftrag",
            "Nun, der Koenig ist etwas kompliziert ... wir sollten ihm lieber ein paar Freunde suchen",
            null,
            null,
            null,
            null,
            "Ok",
            endScene,
            MessageWindow.Character_options.Character_Female_Peasant_01,
            AnimationLibrary.Animations.Talk,
            null
        ));
    }

    void endScene()
    {
        messageWindowScript.DeactivateMessageWindow();

        SaveGameObjects.CastleOnBoardingSystem castleOnBoardingSystem = (SaveGameObjects.CastleOnBoardingSystem)SaveGameMechanic.getSaveGameObjectByPrimaryKey("CastleOnBoardingSystem", 1);
        if (castleOnBoardingSystem == null)
        {
            castleOnBoardingSystem = (SaveGameObjects.CastleOnBoardingSystem)SaveGameObjects.CreateSaveGameObject("CastleOnBoardingSystem");
        }
        castleOnBoardingSystem.onBoardingVideoWatched = true;
        SaveGameMechanic.saveSaveGameObject(castleOnBoardingSystem, "CastleOnBoardingSystem", 1);
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main_Castle");
    }

    IEnumerator moveAdvisorEveryFrame(float duration, CameraMovementAnimation cameraMovementAnimation)
    {
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            // Perform your actions here, this will execute every frame
            cameraMovementAnimation.transitionTime = duration;
            cameraMovementAnimation.step_to_target(CameraMovementAnimation.StepOptions.time_count);

            // Yield until the next frame
            yield return null;
        }

        Debug.Log("Coroutine completed after " + duration + " seconds");
    }

    IEnumerator WaitAndLog(float duration)
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(duration);
    }
}
