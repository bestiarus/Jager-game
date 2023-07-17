using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void Start()
        {
            //unlock cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

public void GotoMainScene()
{
SceneManager.LoadScene("SampleScene");
}

public void GotoExit()
{
    Application.Quit();
}
}