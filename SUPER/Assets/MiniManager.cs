using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniManager : MonoBehaviour{

    public GameObject player1;
    public GameObject player2;

    private TextMeshProUGUI text1;
    private TextMeshProUGUI text2;

    int p1=0;
    int p2=0;

    Touch touch;

    private float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        text1 = player1.GetComponent<TextMeshProUGUI>();
        text2 = player2.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update(){
        timer -= Time.deltaTime;
        int i= 0;
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
        text1.text = p1.ToString();
        text2.text = p2.ToString();

        if(timer <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }


}
