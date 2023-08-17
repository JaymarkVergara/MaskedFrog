using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
   
   //how many times we want to rotate our saw
   //img 360 degrees 2x times 360
   //2full rotation persecond of image
[SerializeField] private float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        //we execute our update per frame
        //time delta we make our values independent ;
        transform.Rotate(0,0,360 * speed * Time.deltaTime);
    }
}
