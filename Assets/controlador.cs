using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class controlador : MonoBehaviour
{
    [SerializeField] GameObject[] paneles = new GameObject[5];
    [SerializeField] TMP_InputField valorQuerido;
    [SerializeField] TMP_Text textoFinal;
    [SerializeField] GameObject textoDeError;
    [SerializeField] calculo a;
    int valorDeseado;
    int[] Billetes = new int[3];

    [Header("depositar")]
    [SerializeField] TMP_InputField BilletesDe20;
    [SerializeField] TMP_InputField BilletesDe50;
    [SerializeField] TMP_InputField BilletesDe100;

    [SerializeField] int billetesDe20;
    [SerializeField] int billetesDe50;
    [SerializeField] int billetesDe100;
    [SerializeField] TMP_Text TextoDeposito;
    int dineroIngresado=0;


    // Start is called before the first frame update
    void Start()
    {
        paneles[0].SetActive(true);
        paneles[1].SetActive(false);
        paneles[2].SetActive(false);
        paneles[3].SetActive(false);
        paneles[4].SetActive(false);
        paneles[5].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (paneles[0].active == true && Input.GetKeyDown(KeyCode.M))
        {
            paneles[0].SetActive(false);
            paneles[3].SetActive(true);
        }
    }

    public void pedir()
    {
        paneles[3].SetActive(false);
        paneles[1].SetActive(true);

    }

    public void entregar()
    {
        paneles[3].SetActive(false);
        paneles[4].SetActive(true);
    }

    public void cuantoIngresas()
    {
        paneles[4].SetActive(false);
        paneles[5].SetActive(true);
        billetesDe20 =int.Parse(BilletesDe20.text);
        billetesDe50 = int.Parse(BilletesDe50.text);
        billetesDe100 = int.Parse(BilletesDe100.text);
        dineroIngresado += billetesDe20 * 20;
        dineroIngresado += billetesDe50 * 50;
        dineroIngresado += billetesDe100 * 100;

        TextoDeposito.text = "Gracias por elegirnos \n\nEl dinero que depositaste fue de " + dineroIngresado+" soles";
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
