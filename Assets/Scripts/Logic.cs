using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusLetter
{
    falsePosition,
    truePosition,
    lastTrueLetter
}

public class Logic : MonoBehaviour
{

    int direction = 0;
    float currentPosition = 0;

    static float leftLimit = -7,
          rightLimit = 0,
          spaceBlock = 2,
          startPositionY = 4.5f;

    public GameObject moveControl,
                     scoreText,
                     switcherSceneButton;

    static GameObject currentLetter = null;
    static string[] words = { "Радуга", "Машина", "Семья" };

    static Word word;
    static int[] truePositionLetters = new int[8];

    public static Score score;
    
    void Start()
    {
        word = new Word();
        word.SetWord(words[SwitcherScene.scene]);
        score = new Score(scoreText,switcherSceneButton, words[SwitcherScene.scene].Length);
        word.TrueLettersIndex.CopyTo(truePositionLetters);

        rightLimit = leftLimit + (words[SwitcherScene.scene].Length - 1) * spaceBlock;

        currentPosition = moveControl.transform.position.x;

        CreateLetter();
    }
    
    public static void CreateLetter()
    {
        Vector3 position = new Vector3(
                           leftLimit + UnityEngine.Random.Range(0, words[SwitcherScene.scene].Length) * spaceBlock,
                           startPositionY);

        currentLetter = word.CreateLetterOnScene(position);
    }

    public static StatusLetter CheckPosition()
    {
        int index = (int)((currentLetter.transform.position.x - leftLimit) / spaceBlock);

        if ( currentLetter.name.Contains(truePositionLetters[index].ToString()) )
        {
            if (word.TrueLettersIndex.Count > 1)
            {
                word.TrueLettersIndex.RemoveAt(word.TrueLettersIndex.IndexOf(truePositionLetters[index]));
                return StatusLetter.truePosition;
            }
            else
            {
                currentLetter = null;
                score.WinnerText();
                
                return StatusLetter.lastTrueLetter;
            }
        }
        return StatusLetter.falsePosition;
    }


    void Update()
    {
        if ( currentPosition - moveControl.transform.position.x > 1)
        {
            direction = -1;
            currentPosition = moveControl.transform.position.x;
        }
        else if (currentPosition - moveControl.transform.position.x < -1)
        {
            direction = 1;
            currentPosition = moveControl.transform.position.x;
        }

        if (direction !=0)
        {
            Vector3 positionLetter = currentLetter.transform.position;

            float newPositionX = positionLetter.x + (spaceBlock * direction);
            newPositionX = newPositionX > rightLimit
                            ? rightLimit
                            : newPositionX < leftLimit
                              ? leftLimit
                              : newPositionX;

            currentLetter.transform.position = new Vector3(newPositionX, positionLetter.y);

            direction = 0;
        }
        
    }
}
