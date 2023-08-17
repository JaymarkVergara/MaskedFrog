using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHp : MonoBehaviour
{
    public int enemyHp;
    private int currentHp;
    private Animator anim;
    public bool isdead;
    private Collider2D parentCol;
    private Collider2D hurtCol;
    [SerializeField] AudioSource deathEnemySfx;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = enemyHp;
        anim = transform.parent.GetComponent<Animator>();
        parentCol = transform.parent.GetComponent<Collider2D>();
        hurtCol = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHp <= 0){
            isdead = true;
           
            anim.SetBool("isDead", isdead);
            parentCol.enabled = false;
            hurtCol.enabled = false;
            StartCoroutine("death");

      
        }
    }
    IEnumerator death(){
        yield return new WaitForSeconds(2f);
        Destroy(transform.parent.gameObject);
    }
    public void takedamage(int damage){
        currentHp -= damage;
         deathEnemySfx.Play();

    }
}
