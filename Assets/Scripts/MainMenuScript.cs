using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
    //Handle for the scene manager
    private SceneManager SceneManager;
   
    //Reloads the game
    public void playGame() {
        SceneManager.LoadScene("Runner");
    }

    //Quits the game
    public void quitGame() {
        Application.Quit();
    }
}
