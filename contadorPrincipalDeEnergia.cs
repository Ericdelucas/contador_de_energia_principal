using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EnergyUIManager : MonoBehaviour
{
    [Header("Referências de UI")]
    [SerializeField] GameObject menuPanel;       // Arraste aqui o MenuPanel
    [SerializeField] GameObject energyPanel;     // Arraste aqui o EnergyPanel
    [SerializeField] GameObject energyText;            // Arraste aqui o TxtEnergyValue
    [SerializeField] Button EnergyButton;
    int qualObj;
    public List<GameObject> construcoes = new List<GameObject>();// Arraste aqui o EnergyButton

    int energia = 0;

    private void Awake()
    {
        EnergyButton.onClick.AddListener(AddEnergy);
    }
    void Start()
    {
        qualObj = -1;
        // Garante que o painel de energia comece oculto
        menuPanel.SetActive(true);
        energyPanel.SetActive(false);
      
    }

    // Chamado pelo BtnOpenEnergy.OnClick()
    public void ShowEnergyScreen()
    {
        menuPanel.SetActive(false);
        energyPanel.SetActive(true);
    }

    // Chamado pelo BtnCloseEnergy.OnClick()
    public void HideEnergyScreen()
    {
        energyPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    // Chamado pelo BtnAddEnergy.OnClick()
    public void AddEnergy()
    {
        if (energia < 1000)
        {
            energyText.GetComponent<ContadorEnergua>().AddEnergia(3);
            
        }
    }

   public void Construir()
    {
        if (energyText.GetComponent<ContadorEnergua>().energia >= 300)
        {
            qualObj++;
            energyText.GetComponent<ContadorEnergua>().AddEnergia(-300);
            construcoes[qualObj].gameObject.SetActive(true);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("EnergyGiver")) // Or use tag, or compare the actual GameObject
                {
                    AddEnergy();
                }
            }
        }
        if (energia < 0)
        {
            SceneManager.LoadSceneAsync(2);
        }
    }

}
