using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Rigidbody enemyRb;
    private GameObject player;
    public float speed = 100f;
    public float enemyHealth { get; private set; } // ENCAPSULATION


    // Start is called before the first frame update
    void Start()
    {
        enemyRb= GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MovementToPlayer();
    }

    public void MovementToPlayer() // ABSTRACTION
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed); 
    }


}
