using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableManager : MonoBehaviour
{
    List<GameObject> Cables = new List<GameObject>();


    void Start()
    {
        Manager.GetInstance().EndEdit();

      
    }

    void CableColour(SpriteRenderer cable)
    {

        cable.color = Color.red;






    }





    void Update()
    {
        
    }
}
