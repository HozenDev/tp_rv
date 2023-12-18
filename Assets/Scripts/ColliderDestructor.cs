using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDestructor : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay(Collider col)
    {
        if (Input.GetMouseButton(1) && col.tag == "Ingredient")
        {  
            Destroy(col.gameObject);
        }
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
