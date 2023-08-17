using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookplayer : MonoBehaviour
{
    private Transform player;
    private float rotationSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //eye rotate 
        Vector2 direction = player.position - transform.position;
        //atan return angle form of radiants d
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        //rotation
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        //rotation f the object
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
}
}
