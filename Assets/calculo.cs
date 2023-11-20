using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calculo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[] calcular(int valorPedido)
    {
        int[] billetes = new int[3];
        int a = valorPedido;
        int billetesDe20 = 0;
        int billetesDe50 = 0;
        int billetesDe100 = 0;
        bool yaNoSePuedeSegir = false;
        while (yaNoSePuedeSegir == false)
        {
            if (valorPedido >= 100)
            {
                valorPedido -= 100;
                billetesDe100 += 1;
            }
            else
            {
                if(valorPedido >= 50)
                {
                    valorPedido -= 50;
                    billetesDe50 += 1;
                }
                else
                {
                    if(valorPedido >= 20)
                    {
                        valorPedido -= 20;
                        billetesDe20 += 1;
                    }
                    else
                    {
                        yaNoSePuedeSegir = true;
                    }
                }
            }
        }




        billetes[0] = billetesDe20;
        billetes[1] = billetesDe50;
        billetes[2] = billetesDe100; 
        return billetes;
    }
}
