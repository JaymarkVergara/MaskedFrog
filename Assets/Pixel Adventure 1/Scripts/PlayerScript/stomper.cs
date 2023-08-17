using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stomper : MonoBehaviour
{
    public int damageDealth;
    //addd force to rigid nbody
    private  Rigidbody2D rb2d;
    private float forceBounce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        //parent gameobject that ourplayer attachto
        rb2d = transform.parent.GetComponent<Rigidbody2D>();
    }

    //hit when we collide
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "HurtBox"){
            other.gameObject.GetComponent<EnemyHp>().takedamage(damageDealth);
            //vector 2 directin //impulse happen instant
            rb2d.AddForce(Vector2.up * forceBounce, ForceMode2D.Impulse);
        }
    }
}
