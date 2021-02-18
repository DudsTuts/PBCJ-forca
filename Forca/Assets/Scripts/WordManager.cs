using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordManager : MonoBehaviour
{
    public string chosenWord;               // Variavel para escolha aleatoria de uma palavra.
    private Boolean[] boolTest;             // Variacel para armazenar estado de completude da palavra.
    public GameObject letterPrefab;         // Variavel se referindo a prefab de letra/word.
    private List<Text> aux;                 // Variavel auxiliar para uso de Lista
    public static WordManager instance;     // Singleton de WordManager.
    public Transform letterParent;          // Variavel para uso de referencia ao instaciar GameObject.
    
    public int Verify(char c)              // Funcao para verificar se a letra digitada esta presente na palavra oculta e se estiver retornar uma pontuacao.
    {
        int ret = 0;
        for(int i=0; i<chosenWord.Length; i++)
        {
            if (c == chosenWord[i] && boolTest[i] == false)
            {
                boolTest[i] = true;
                aux[i].text = c.ToString();
                ret++;
            }
        }
        return ret;
    }
    public Boolean AllTrue()
    {

        Boolean condicao = true;
        for(int i = 0; i < boolTest.Length; i++)
        {
            condicao = condicao && boolTest[i];
        } 
        return condicao;
    }

    private void Awake()                    // Funcao para evitar problemas com o singleton do WordManager.
    {
        instance = this;   
    }   
    // Start is called before the first frame update
    void Start()
    {
        int i;
        aux = new List<Text>();             
        chosenWord = RandomWord.getWords();             // RandomWord.getWords() usado para escolher uma palavra aleatoria na lista de palavras.
        PlayerPrefs.SetString("resposta", chosenWord);  // Adicionando a resposta no PlayerPrefs.
        for(i = 0; i < chosenWord.Length; i++)
        {
            GameObject letter = Instantiate(letterPrefab,letterParent) as GameObject;       // Instanciando GameObject com parent definido.
            aux.Add(letter.GetComponent<Text>());                                           // Inicializando texto da palavra.
        }

        boolTest = new Boolean[chosenWord.Length];  // Inicializando 
        for(i = 0; i< boolTest.Length; i++)         // vetor de booleanos
        {                                           // para verificao
            boolTest[i] = false;                    // das proximas etapas   
        }
    }
}
