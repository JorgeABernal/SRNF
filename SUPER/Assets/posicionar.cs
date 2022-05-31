using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posicionar : MonoBehaviour{

    public GameObject player;
    public GameObject ninja;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ninja.transform.position = player.transform.position;
        if(ninja.transform.position.x > 1){
            ninja.transform.localScale = new Vector3(-4.654349f,4.654349f,4.654349f);
        }else{
            ninja.transform.localScale = new Vector3(4.654349f,4.654349f,4.654349f);
        }
    }
}
