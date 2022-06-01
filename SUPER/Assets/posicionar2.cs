using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posicionar2 : MonoBehaviour{

    public GameObject player2;
    public GameObject ninja2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ninja2.transform.position = player2.transform.position;
        if(ninja2.transform.position.x < -3.5){
            ninja2.transform.localScale = new Vector3(4.654349f,4.654349f,4.654349f);
        }
    }
}
