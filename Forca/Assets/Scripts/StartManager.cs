using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{ 
   void Start()
    {
        PlayerPrefs.SetInt("score",0);              // Define a pontuacao do usuario como 0.
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");      // Ao apertar o botao, leva o usuario para a cena de jogo.
    }
}
