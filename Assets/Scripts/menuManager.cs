using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class menuManager : MonoBehaviour
{
    public string sceneToLoad;



    // Start is called before the first frame update
    public void MoveToGame()
    {
        SceneManager.LoadScene("Test Level"); //move edit this later on to go to the loadgame scene.
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MoveToCredits()
    {
        //this will bring up a panel that has all the credits
    }

    
}
