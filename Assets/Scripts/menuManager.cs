using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class menuManager : MonoBehaviour
{
    



    // Start is called before the first frame update
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index); //move edit this later on to go to the loadgame scene.
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    

    
}
