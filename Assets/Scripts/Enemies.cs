using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    [HideInInspector] public float speed;
    private Rigidbody2D myBody;

    void Awake(){
        myBody = GetComponent<Rigidbody2D>();
        ;


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myBody.velocity= new Vector2(speed,myBody.velocity.y);

    }
}
