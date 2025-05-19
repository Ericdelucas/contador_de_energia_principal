using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ContadorEnergua : MonoBehaviour

{

    
    public int energia;
    public GameObject contador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        contador = GameObject.FindGameObjectWithTag("ContadorEnergia");
       
    }

    // Update is called once per frame
    public void AddEnergia(int adicao)
    {
        if (energia < 10000000)
        {
            energia += adicao;
        }
    }
    private void Update()
    {
        contador.GetComponent<TMP_Text>().text = "Energia:" + energia;
        if (energia < 0)
        {
            SceneManager.LoadSceneAsync(2);
        }
    }
    public void RemoveEnergia(int valor)
    {
        energia = energia - valor;
    }

}