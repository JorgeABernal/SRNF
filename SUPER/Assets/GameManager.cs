using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public GameObject player;
    public GameObject player2;

    Touch touch,touch2;
    Vector2 touchPosition;
    int toque = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Ended){
            toque++;
            move();
        }
    }

    void move(){
        if(toque % 2 == 1){
            touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            player.transform.position = new Vector2(touchPos.x,touchPos.y);
        }else if(toque % 2 == 0){
            touch2 = Input.GetTouch(0);
            Vector2 touchPos2 = Camera.main.ScreenToWorldPoint(touch2.position);
            player2.transform.position = new Vector2(touchPos2.x,touchPos2.y);
        }
        

    }
}
