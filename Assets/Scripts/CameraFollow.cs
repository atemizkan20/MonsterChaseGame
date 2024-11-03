using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 temppos;
    [SerializeField] private float minX, maxX;


    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player){
            return; //any code below the return will not be executed since the func is void
        }

        temppos=transform.position;
        temppos.x = player.position.x;

        temppos.x = Mathf.Clamp(temppos.x, minX, maxX);
        // Mathf.Clamp fonksiyonu pozisyona sınır getirir
        transform.position= temppos;

        if (temppos.x<minX) {
            temppos.x=minX;
        }

        if (temppos.x>maxX) {
            temppos.x=maxX;
        }
        
    }
}
