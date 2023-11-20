using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class controlador : MonoBehaviour
{
    [SerializeField] GameObject[] paneles = new GameObject[3];
    [SerializeField] TMP_InputField valorQuerido;
    [SerializeField] TMP_Text textoFinal;
    [SerializeField] GameObject textoDeError;
    [SerializeField] calculo a;
    int valorDeseado;

    int[] Billetes = new int[3];
    // Start is called before the first frame update
    void Start()
    {
        paneles[0].SetActive(true);
        paneles[1].SetActive(false);
        paneles[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (paneles[0].active == true && Input.GetKeyDown(KeyCode.M))
        {
            paneles[0].SetActive(false);
            paneles[1].SetActive(true);
        }
    }


    public void CuantoPides()
    {
        valorDeseado = int.Parse(valorQuerido.text);

        int x = 0;
        Billetes = a.GetComponent<calculo>().calcular(valorDeseado);

        x += Billetes[0] * 20;
        x += Billetes[1] * 50;
        x += Billetes[2] * 100;

        if (x != valorDeseado)
        {
            textoDeError.SetActive(true);
        }
        else
        {
            textoDeError.SetActive(false);
            paneles[1].SetActive(false);
            paneles[2].SetActive(true);



            textoFinal.text = "Gracias por elegirnos \n\nRetiro ";

            if (Billetes[0] > 0)
            {
                textoFinal.text += Billetes[0] + " billetes de 20";
                if(Billetes[1] > 0 || Billetes[2] > 0)
                {
                    if(Billetes[1]>0 && Billetes[2] > 0)
                    {
                        textoFinal.text += ", ";
                        textoFinal.text += Billetes[1] + " billetes de 50";
                        textoFinal.text += " y ";
                        textoFinal.text += Billetes[2] + " billetes de 100";
                    }
                    else
                    {
                        textoFinal.text += " y ";
                        if (Billetes[1] > 0)
                        {
                            textoFinal.text += Billetes[1] + " billetes de 50";
                        }
                        else
                        {
                            textoFinal.text += Billetes[2] + " billetes de 100";
                        }
                    }
                }
            }
            
        }





    }
}
