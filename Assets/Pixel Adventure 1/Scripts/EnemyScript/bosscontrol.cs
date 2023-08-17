using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class bosscontrol : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;
    public float shotForce;

    public float timebetweenshots;
    //time between shots
    [SerializeField] private float shotTimer;
    private EnemyHp bossHp;
    public GameObject goal;
    

        // Start is called before the first frame update
    void Start()
    {

            shotTimer = timebetweenshots;
            //get child object attach to our game object
            bossHp = transform.GetChild(0).GetComponent<EnemyHp>();

    }

    // Update is called once per frame
    void Update()
    {
        shotTimer -= Time.deltaTime;
        if(shotTimer <= 0){
            shotTimer = timebetweenshots;
            Shoot();
        }
        if(bossHp.isdead){
               StartCoroutine("vic");
        }
    }

    IEnumerator vic(){
        yield return new WaitForSeconds(0.5f);
        goal.SetActive(true);
    }
    

    void Shoot(){
        GameObject bullets = Instantiate(bullet, firepoint.position, firepoint.rotation);
        //position shotfoce then add pyshiscs
        Rigidbody2D rb = bullets.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * shotForce, ForceMode2D.Impulse);
    }
}
