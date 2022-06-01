using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniManager : MonoBehaviour{

    public GameObject player1;
    public GameObject player2;
    public GameObject timerObject;

    private TextMeshProUGUI text1;
    private TextMeshProUGUI text2;
    private TextMeshProUGUI textTimer;

    private Animator Animator;
    private Animator Animator2;

    public GameObject ninja;
    public GameObject ninja2;

    int p1=0;
    int p2=0;

    Touch touch;

    private float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        text1 = player1.GetComponent<TextMeshProUGUI>();
        text2 = player2.GetComponent<TextMeshProUGUI>();
        textTimer = timerObject.GetComponent<TextMeshProUGUI>();

        Animator = ninja.GetComponent<Animator>();
        Animator2 = ninja2.GetComponent<Animator>();

        Animator.SetBool("Gano1",false);
        Animator2.SetBool("Gano2",false);
        Animator.SetBool("Perdio1",false);
        Animator2.SetBool("Perdio2",false);
    }

    // Update is called once per frame
    void Update(){
        timer -= Time.deltaTime;
        int i= 0;
        if(timer > 0){
            while(i < Input.touchCount){
                Touch t = Input.GetTouch(i);
                if(t.phase == TouchPhase.Ended){
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(t.position);
                    if(touchPos.x < 0){
                        p1++;
                    }else{
                        p2++;
                    }
                }
                i++;
            }
        }
        text1.text = p1.ToString();
        text2.text = p2.ToString();
        int tempo = (int) timer;
        textTimer.text = tempo.ToString();

        if(timer <= 0){
            timer = 0;
            if(p1>p2){
                Animator.SetBool("Gano1",true);
                Invoke("gano1",.4f);
            }else if(p1<p2){
                Animator2.SetBool("Gano2",true);
                Invoke("gano2",.4f);
            }else if(p1==p2){
                Animator.SetBool("Gano1",true);
                Animator2.SetBool("Gano2",true);
            }
            Invoke("regresar",1.2f);
        }
    }

    void regresar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void gano1(){
        Animator2.SetBool("Perdio2",true);
    }

    void gano2(){
        Animator.SetBool("Perdio1",true);
    }
}
