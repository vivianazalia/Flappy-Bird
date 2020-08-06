using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void LoadScene(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            SceneManager.LoadScene(name);
        }
    }

    public static int CurrentScene()
    {
        return SceneManager.sceneCount;
    }
}
