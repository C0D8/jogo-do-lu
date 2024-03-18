using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private Timer timer;
    AudioManager audioManager;

private void Awake() {
    audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

}

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0; 
        SetCountText();
        winTextObject.SetActive(false);
        timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.timeRemaining <= 0){
            SceneManager.LoadScene("MainMenu");
        }

    }

    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText(){
        countText.text = "Count: " + count.ToString();
        if(count >= 14){
            winTextObject.SetActive(true);
            // restar after winning 3 seconds
            Invoke("GameWon", 3);
        }
    }


    void FixedUpdate(){
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("PickUp")){
        other.gameObject.SetActive(false);

        count = count + 1;
        SetCountText();
        audioManager.PlaySFX(audioManager.collectClip);
        }

       

        if((other.gameObject.CompareTag("Enemy") | other.gameObject.CompareTag("Enemy2")) & count < 14){
            // restart game if hit enemy
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            audioManager.PlaySFX(audioManager.loseClip);

            Invoke("GameLost", 1.5f );
        }

    }


    void GameWon(){
       // resstart game if won and turn off win text and go to the main menu
       // passar para o próximo nível  tela atual + 1
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadSceneAsync(0);
}

    void GameLost(){
        // restart game if lost
        SceneManager.LoadScene("MainMenu");
    }

}
