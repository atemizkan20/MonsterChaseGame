using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision){

        if (collision.CompareTag("Enemy") || collision.CompareTag("Player")){
            Destroy(collision.gameObject); //collision.gameobject refers to the enemy instad destroying collector

        }

    }


}
