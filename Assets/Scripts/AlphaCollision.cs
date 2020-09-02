using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class AlphaCollision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objCollision = collision.collider.gameObject,
                    objToDestroy = null;
        int statusLetter = -1;
        bool isTrueLetterPosition = true;

        if (objCollision.name.Contains("alphabet"))
        {
            if ( objCollision.transform.position.y > -4f)
            {
                objToDestroy = objCollision;
                isTrueLetterPosition = false;
            }
                 
        }
        else if (objCollision.name.Contains("floor"))
        {
            statusLetter = (int)Logic.CheckPosition();
            if (statusLetter == (int)StatusLetter.falsePosition)
            {
                objToDestroy = gameObject;
            }
        }
        if (objToDestroy)
        {
            GameObject fire = Resources.Load("animation/fire") as GameObject;
            fire = Instantiate(fire, gameObject.transform.position, Quaternion.identity);

            Destroy(fire, 1);
            
            Destroy(objToDestroy, 1);

            Logic.score.DecrementScore();
        }

        if (isTrueLetterPosition && (statusLetter != (int)StatusLetter.lastTrueLetter)) Logic.CreateLetter();
    }
}
