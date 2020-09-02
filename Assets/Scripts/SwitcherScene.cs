using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitcherScene : MonoBehaviour
{
    public static int scene = 0;

    public void SwitchScene()
    {
        SceneManager.LoadScene(++scene);
    }
}
