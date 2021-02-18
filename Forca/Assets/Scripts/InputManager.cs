using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    private int numTry;                     // Numero atual de tentativas.
    private int maxNumTry;                  // Numero maximo de tentativas.
    private int score, playerScore;

    private void Start()
    {
        //GameObject score = Instantiate(scoreText) as GameObject;
        numTry = 0;
        maxNumTry = 10;
        UpdateNumtry();
        UpdateScore();
    }

    void Update()                           // Verifica a cada frame a tecla digitada pelo usuario (limitado apenas as letras maiusculas)
    {
        foreach(char c in Input.inputString)
        {

            if (numTry < (maxNumTry-1)){                                    // Jogando
               if (c >= 65 && c <= 90) {                                    // Letra maiusculas
                        
                    numTry++;                                               // Aumenta o numero de jogadas realizadas
                    UpdateNumtry();                                         // Atualiza a interface de tentativas

                    playerScore = PlayerPrefs.GetInt("score");              // Obtem a pontuacao atual do jogador
                    score = WordManager.instance.Verify(c);                 // Verifica se ha a letra na palavra e atribui pontuacao em score
                    PlayerPrefs.SetInt("score", (score + playerScore));     // Atualiza a pontuacao do jogador
                    UpdateScore();                                          // Atualiza interface de pontuacao

                }
                else if (c >= 97 && c <= 122) {                             // Letras minusculas
                    numTry++;                                               // Aumenta o numero de jogadas realizadas
                    UpdateNumtry();                                         // Atualiza a interface de tentativas

                    playerScore = PlayerPrefs.GetInt("score");              // Obtem a pontuacao atual do jogador
                    score = WordManager.instance.Verify(char.ToUpper(c));   // Verifica se ha a letra na palavra e atribui pontuacao em score
                    PlayerPrefs.SetInt("score", (score + playerScore));     // Atualiza a pontuacao do jogador
                    UpdateScore();                                          // Atualiza interface de pontuacao
                }
                if (WordManager.instance.AllTrue())
                    SceneManager.LoadScene("WinScene");         // Ganha
            }else{                                           
                SceneManager.LoadScene("LoseScene");            // Perde
            }
        }
    }
    public void UpdateNumtry()          // Atualiza interface de tentativas
    {
        GameObject.Find("NumTry").GetComponent<Text>().text = "Tentativas: " + (numTry+1) + " | " + maxNumTry;
    }

    public void UpdateScore()           // Atualiza interface de pontuacao
    {
        GameObject.Find("ScoreText").GetComponent<Text>().text = "Score: " + PlayerPrefs.GetInt("score");
    }
}
