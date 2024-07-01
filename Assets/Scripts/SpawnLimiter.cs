using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnLimiter : MonoBehaviour
{
    public List<GameObject> Personagens;
    public int limitePersonagem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var charList = GameObject.FindGameObjectsWithTag("Fine");

        foreach (GameObject Personagem in Personagens)
        {
            if(Personagem == null)
            {
                Personagens.Remove(Personagem);
            }
        }

        foreach (GameObject newPersonagem in charList)
        {
            if (!Personagens.Contains(newPersonagem))
            {
                    Personagens.Add(newPersonagem);
            }
            else
            {
                    Debug.Log("Já está na lista");
            }
        }

        if (Personagens.Count > limitePersonagem)
        {
            Destroy(Personagens.Last());
            Personagens.RemoveAt(Personagens.Count - 1);
        }
            
    }
       
}
