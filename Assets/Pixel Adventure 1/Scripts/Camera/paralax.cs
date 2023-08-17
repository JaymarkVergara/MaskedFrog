using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{   
    //we need to know length and transform positoion of our sprite
    private float length, startpos;
    //camera
    public GameObject cam;
    //tell how much parralex effect we apply
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        //get position
        startpos = transform.position.x;
          //get component size
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        //bacgorund to repeat itself
        //how far we move rlative to camera
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        //how far we move in world space
        float dist = (cam.transform.position.x * parallaxEffect);
        //actually move the camera
      
      
      
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
       
        if(temp > startpos + length) startpos += length;
        else if(temp < startpos - length) startpos -= length;
    }

}

