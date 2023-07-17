using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExampleClass : MonoBehaviour
{
    public void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Arch") 
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        if (sceneName == "SampleScene") 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}