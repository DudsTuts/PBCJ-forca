using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public void Finish()
    {
        SceneManager.LoadScene("EndScene");             // Ao selecionar o botao especifico, leva o usuario ate a cena dos creditos
    }

    public void Reset()
    {
        SceneManager.LoadScene("StartingScene");        // Ao selecionar o botao especifico, leva o usuario a tela inicial do jogo
    }
}
