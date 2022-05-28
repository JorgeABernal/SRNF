using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public GameObject player;
    public GameObject player2;
    public GameObject text1, text2,peleen;

    Touch touch,touch2;
    Vector2 touchPosition;

    int pos1, pos2;

    int[,] grafo = new int[5,5]{{0,1,1,1,0},
                                {1,0,1,0,1},
                                {1,1,0,1,1},
                                {1,0,1,0,1},
                                {0,1,1,1,0}};

    int toque = 0;
    bool ronda;
    bool unoAtaca;
    int posTemp1, posTemp2;
    int sig1x,sig1y,sig2x,sig2y;

    // Start is called before the first frame update
    void Start()
    {
        pos1 = 1;
        pos2 = 5;
        ronda = true;
        unoAtaca = true;
        text2.SetActive(false);
        text1.SetActive(false);
        peleen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(ronda == false){
            round();
        }else{
            
            if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Ended){
                toque++;
                move();
                if(toque == 2){
                    ronda = false;
                    toque = 0;
                }
            }
        }
    }

    void move(){
        if(unoAtaca == true){
            if(toque % 2 == 1){
                
                touch = Input.GetTouch(0);
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                if(touchPos.x > -2 && touchPos.x < 2 && touchPos.y < 5 && touchPos.y > 2){ // bloque2
                    avanzar(pos1,2,player,1);
                }else if(touchPos.x < -3 && touchPos.x > -5 && touchPos.y > -2 && touchPos.y < 2){ // bloque1
                    avanzar(pos1,1,player,1);
                }else if(touchPos.x < 2 && touchPos.x > -2 && touchPos.y < 2 && touchPos.y > -2){ //bloque3
                    avanzar(pos1,3,player,1);
                }else if(touchPos.x > -2 && touchPos.x < 2 && touchPos.y > -5 && touchPos.y < -3){ //bloque4
                    avanzar(pos1,4,player,1);
                }else if(touchPos.x > 3 && touchPos.x < 5 && touchPos.y > -2 && touchPos.y < 2){ // bloque5
                    avanzar(pos1,5,player,1);
                }else{
                    toque--;
                } 
            }else if(toque % 2 == 0){
                
                touch2 = Input.GetTouch(0);
                Vector2 touchPos2 = Camera.main.ScreenToWorldPoint(touch2.position);
                if(touchPos2.x > -2 && touchPos2.x < 2 && touchPos2.y < 5 && touchPos2.y > 2){ // bloque2
                    avanzar(pos2,2,player2,2);
                }else if(touchPos2.x < -3 && touchPos2.x > -5 && touchPos2.y > -2 && touchPos2.y < 2){ // bloque1
                    avanzar(pos2,1,player2,2);
                }else if(touchPos2.x < 2 && touchPos2.x > -2 && touchPos2.y < 2 && touchPos2.y > -2){ //bloque3
                    avanzar(pos2,3,player2,2);
                }else if(touchPos2.x > -2 && touchPos2.x < 2 && touchPos2.y > -5 && touchPos2.y < -2){ //bloque4
                    avanzar(pos2,4,player2,2);
                }else if(touchPos2.x > 3 && touchPos2.x < 5 && touchPos2.y > -2 && touchPos2.y < 2){ // bloque5
                    avanzar(pos2,5,player2,2);
                }else{
                    toque--;
                }
            }
        }else{
            if(toque % 2 == 0){
                
                touch = Input.GetTouch(0);
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                if(touchPos.x > -2 && touchPos.x < 2 && touchPos.y < 5 && touchPos.y > 2){ // bloque2
                    avanzar(pos1,2,player,1);
                }else if(touchPos.x < -3 && touchPos.x > -5 && touchPos.y > -2 && touchPos.y < 2){ // bloque1
                    avanzar(pos1,1,player,1);
                }else if(touchPos.x < 2 && touchPos.x > -2 && touchPos.y < 2 && touchPos.y > -2){ //bloque3
                    avanzar(pos1,3,player,1);
                }else if(touchPos.x > -2 && touchPos.x < 2 && touchPos.y > -5 && touchPos.y < -3){ //bloque4
                    avanzar(pos1,4,player,1);
                }else if(touchPos.x > 3 && touchPos.x < 5 && touchPos.y > -2 && touchPos.y < 2){ // bloque5
                    avanzar(pos1,5,player,1);
                }else{
                    toque--;
                } 
            }else if(toque % 2 == 1){
               
                touch2 = Input.GetTouch(0);
                Vector2 touchPos2 = Camera.main.ScreenToWorldPoint(touch2.position);
                if(touchPos2.x > -2 && touchPos2.x < 2 && touchPos2.y < 5 && touchPos2.y > 2){ // bloque2
                    avanzar(pos2,2,player2,2);
                }else if(touchPos2.x < -3 && touchPos2.x > -5 && touchPos2.y > -2 && touchPos2.y < 2){ // bloque1
                    avanzar(pos2,1,player2,2);
                }else if(touchPos2.x < 2 && touchPos2.x > -2 && touchPos2.y < 2 && touchPos2.y > -2){ //bloque3
                    avanzar(pos2,3,player2,2);
                }else if(touchPos2.x > -2 && touchPos2.x < 2 && touchPos2.y > -5 && touchPos2.y < -2){ //bloque4
                    avanzar(pos2,4,player2,2);
                }else if(touchPos2.x > 3 && touchPos2.x < 5 && touchPos2.y > -2 && touchPos2.y < 2){ // bloque5
                    avanzar(pos2,5,player2,2);
                }else{
                    toque--;
                }
            }
        }
        
        
        void avanzar(int act, int sig, GameObject player,int jug){
            Debug.Log(act + " " + sig + " " + player.name + " " + jug);
            if(grafo[act-1,sig-1] == 1){
                if(sig != pos1 && sig!= pos2){
                    switch (sig){
                        case 1:
                            if(jug == 1){
                                posTemp1 = 1;
                                sig1x = -4;
                                sig1y = 1;
                            }else{
                                posTemp2 = 1;
                                sig2x = -4;
                                sig2y = 1;
                            }
                            break;
                        case 2:
                            if(jug == 1){
                                posTemp1 = 2;
                                sig1x = 0;
                                sig1y = 4;
                            }else{
                                posTemp2 = 2;
                                sig2x = 0;
                                sig2y = 4;
                            }
                            break;
                        case 3:
                            if(jug == 1){
                                posTemp1 = 3;
                                sig1x = 0;
                                sig1y = 1;
                            }else{
                                posTemp2 = 3;
                                sig2x = 0;
                                sig2y = 1;
                            }
                            break;
                        case 4:
                            if(jug == 1){
                                posTemp1 = 4;
                                sig1x = 0;
                                sig1y = -2;
                            }else{
                                posTemp2 = 4;
                                sig2x = 0;
                                sig2y = -2;
                            }
                            break;
                        case 5:
                            if(jug == 1){
                                posTemp1 = 5;
                                sig1x = 4;
                                sig1y = 1;
                            }else{
                                posTemp2 = 5;
                                sig2x = 4;
                                sig2y = 1;
                            }
                            break;
                    }
                }else{
                    Debug.Log("pos1/pos2 == sig");
                    toque--;
                }
            }else{
                Debug.Log("grafo[act,sig] es 0");
                toque--;
            }
        }
    }

    void round(){
        
        player.transform.position = new Vector2(sig1x,sig1y);
        pos1 = posTemp1;
        player2.transform.position = new Vector2(sig2x,sig2y);
        pos2 = posTemp2;
        if(unoAtaca == true){
            unoAtaca = false;
        }else{
            unoAtaca = true;
        }
        new WaitForSeconds(1);
        ronda = true;
    }
}
