using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour {
    //Handle for the SceneManager
    private SceneManager SceneManager;

    //Restarts the level
    public void restart() {
        SceneManager.LoadScene("Runner");
    }

    //Exits to main menu
    public void exitToMenu() {
        SceneManager.LoadScene("StartScreen");
    }
}
