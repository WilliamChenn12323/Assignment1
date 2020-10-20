using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;

    public GameObject winLevelUI;
    
    public void Gamewin()
    {
        winLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
    
   
}
