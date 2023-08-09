using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEditor.Animations;
using UnityEngine;

public class CableManager : MonoBehaviour
{
    List<SpriteRenderer> Cables = new List<SpriteRenderer>();

    public GameObject Cable1;

    void Start()
    {

    }

    void CableColour(SpriteRenderer cable)
    {

        cable.color = Color.red;


    }





    void Update()
    {
        
    }
}
