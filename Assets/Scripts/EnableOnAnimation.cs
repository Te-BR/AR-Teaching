using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnAnimation : MonoBehaviour
{
    public Animator anim;
    public int animInt;
    public int animIntAtual;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GetInterger", 0.1f, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        //7 = Comer | 5 = Escovar
        if (animIntAtual == animInt)
        {
            gameObject.SetActive(true);
        }else{
            gameObject.SetActive(false);
        }
    }

    public void GetInterger(){
        animIntAtual = anim.GetInteger("Animation");
        Debug.Log(animIntAtual);
        if (animIntAtual == animInt)
        {
            gameObject.SetActive(true);
        }else{
            gameObject.SetActive(false);
        }
    }
}
