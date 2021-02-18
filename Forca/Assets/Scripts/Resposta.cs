using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resposta : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = PlayerPrefs.GetString("resposta");      // Define a resposta correta para m componente de texto.
    }
}
