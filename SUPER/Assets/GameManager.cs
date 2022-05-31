using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    float moveSpeed = 5f;
    Vector2 whereToMove;
    Vector2 whereToMove2;
    bool isMoving = false;
    bool isMoving2 = false;

    float previousDistanceToTouchPos, currentDistanceToTouchPos;
    float previousDistanceToTouchPos2, currentDistanceToTouchPos2;

    public GameObject player;
    public GameObject player2;
    public GameObject text1, text2,peleen;
    public GameObject ninja;

    private Animator Animator;

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
    float distancia1;

    bool arriba = false;
    bool abajo = false;
    bool izq = false;
    bool der = false;

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
        Animator = ninja.GetComponent<Animator>();
        Animator.SetBool("Jumping",false);
        Animator.SetBool("Falling",false);
        Animator.SetBool("JumpUpwards",false);
        Animator.SetBool("JumpDownwards",false);
        Animator.SetBool("Landed",true);
    }

    // Update is called once per frame
    void Update()
    {
        if(ronda == false){
            round();
        }else{
            if(isMoving){
                currentDistanceToTouchPos = (new Vector2(sig1x,sig1y) - new Vector2(player.transform.position.x,player.transform.position.y)).magnitude;
            }
            if(isMoving2){
                currentDistanceToTouchPos2 = (new Vector2(sig2x,sig2y) - new Vector2(player2.transform.position.x,player2.transform.position.y)).magnitude;
            }


            if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Ended){
                toque++;
                move();
                if(toque == 2){
                    previousDistanceToTouchPos = 0;
                    currentDistanceToTouchPos = 0;
                    previousDistanceToTouchPos2 = 0;
                    currentDistanceToTouchPos2 = 0;
                    isMoving = true;
                    Animator.SetBool("Landed",false);
                    isMoving2 = true;
                    whereToMove = (new Vector2(sig1x,sig1y) - new Vector2(player.transform.position.x,player.transform.position.y)).normalized;
                    if(sig1y - (int) player.transform.position.y < 0){
                        Debug.Log("ABAJO Y ");
                        abajo = true;
                        arriba = false;
                    }else if(sig1y - (int) player.transform.position.y > 0){
                        Debug.Log("ARRIBA Y ");
                        arriba = true;
                        abajo = false;
                    }else{
                        Debug.Log("IGUAL Y");
                        arriba = false;
                        abajo = false;
                    }

                    if(sig1x - (int) player.transform.position.x > 0){
                        Debug.Log("DERECHA ");
                        der = true;
                        izq = false;
                    }else if(sig1x - (int) player.transform.position.x < 0){
                        Debug.Log("IZQUIERDA ");
                        izq = true;
                        der = false;
                    }else{
                        Debug.Log("IGUAL X");
                        izq = false;
                        der = false;
                    }

                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * moveSpeed);
                    whereToMove2 = (new Vector2(sig2x,sig2y) - new Vector2(player2.transform.position.x,player2.transform.position.y)).normalized;
                    player2.GetComponent<Rigidbody2D>().velocity = new Vector2(whereToMove2.x * moveSpeed, whereToMove2.y * moveSpeed);
                    distancia1 = (new Vector2(sig1x,sig1y) - new Vector2(player.transform.position.x,player.transform.position.y)).magnitude;
                    ronda = false;
                    toque = 0;
                }
            }

            if(arriba == true && abajo == false){
                if(der == true && izq == false){
                    ninja.transform.localScale = new Vector3(4.654349f,4.654349f,4.654349f);
                }else if(der == false && izq == true){
                    ninja.transform.localScale = new Vector3(-4.654349f,4.654349f,4.654349f);
                }else if(der == false && izq == false){
                    ninja.transform.localScale = new Vector3(4.654349f,4.654349f,4.654349f);
                }
                Animator.SetBool("JumpUpwards",true);
                Animator.SetBool("Jumping",true);
                Animator.SetBool("JumpDownwards",false);
            }else if(arriba == false && abajo == true){
                if(der == true && izq == false){
                    ninja.transform.localScale = new Vector3(4.654349f,4.654349f,4.654349f);
                }else if(der == false && izq == true){
                    ninja.transform.localScale = new Vector3(-4.654349f,4.654349f,4.654349f);
                }else if(der == false && izq == false){
                    ninja.transform.localScale = new Vector3(4.654349f,4.654349f,4.654349f);
                }
                Animator.SetBool("JumpUpwards",false);
                Animator.SetBool("JumpDownwards",true);
            }else if(arriba == false && abajo == false){
                if(der == true && izq == false){
                    ninja.transform.localScale = new Vector3(4.654349f,4.654349f,4.654349f);
                }else if(der == false && izq == true){
                    ninja.transform.localScale = new Vector3(-4.654349f,4.654349f,4.654349f);
                }else if(der == false && izq == false){
                    ninja.transform.localScale = new Vector3(4.654349f,4.654349f,4.654349f);
                }
                Animator.SetBool("JumpUpwards",false);
                Animator.SetBool("JumpDownwards",false);
                if(currentDistanceToTouchPos > (distancia1/3)){
                    Animator.SetBool("Jumping",true);
                    Animator.SetBool("JumpUpwards",true);
                    Animator.SetBool("Falling",false);
                }else if(currentDistanceToTouchPos < (distancia1/3)){
                    Animator.SetBool("Jumping",false);
                    Animator.SetBool("JumpUpwards",false);
                    Animator.SetBool("Falling",true);
                }
            }

            
                            
            if(currentDistanceToTouchPos > previousDistanceToTouchPos){
                isMoving = false;
                player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Animator.SetBool("Falling",false);    
                Animator.SetBool("Landed",true);    
                Animator.SetBool("JumpUpwards",false);    
                Animator.SetBool("JumpDownwards",false); 
                ninja.transform.localScale = new Vector3(4.654349f,4.654349f,4.654349f);   
            }
            if(currentDistanceToTouchPos2 > previousDistanceToTouchPos2){
                isMoving2 = false;
                player2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;    
            }

            if(isMoving){
                previousDistanceToTouchPos = (new Vector2(sig1x,sig1y) - new Vector2(player.transform.position.x,player.transform.position.y)).magnitude;
            }
            if(isMoving2){
                previousDistanceToTouchPos2 = (new Vector2(sig2x,sig2y) - new Vector2(player2.transform.position.x,player2.transform.position.y)).magnitude;
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
                }else if(touchPos.x > -2 && touchPos.x < 2 && touchPos.y > -5 && touchPos.y < -2){ //bloque4
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
                    toque--;
                }
            }else{
                toque--;
            }
        }
    }

    void round(){   
        pos1 = posTemp1;
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
