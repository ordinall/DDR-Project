using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMethods : MonoBehaviour
{

    enum SceneIndex
    {
        Menu = 0,
        NonObjectPoolScene = 1,
        ObjectPoolScene = 2
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene((int)SceneIndex.Menu);
    }

    public void loadObjectPoolScene()
    {
        SceneManager.LoadScene((int)SceneIndex.ObjectPoolScene);
    }

    public void loadNonObjectPoolScene()
    {
        SceneManager.LoadScene((int)SceneIndex.NonObjectPoolScene);
    }

}