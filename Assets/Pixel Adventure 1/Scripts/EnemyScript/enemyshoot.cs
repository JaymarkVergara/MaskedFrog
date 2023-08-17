using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class enemyshoot : MonoBehaviour
{
    public GameObject hitFX;
    private void OnTriggerEnter2D(Collider2D other)
    {
    GameObject effect = Instantiate(hitFX, transform.position, Quaternion.identity);
     Destroy(effect, 0.3f);
     Destroy(gameObject);
   }
   
}
