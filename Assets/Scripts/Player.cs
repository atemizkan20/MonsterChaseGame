using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveforce=10f;

    [SerializeField]
    private float jumpforce=30f;
    private float movementX;
    public Rigidbody2D mybody;
    private Animator anim;
    private string Walkanimation ="Walk";
    private string Groundtag= "Ground";
    private string enemytag ="Enemy";
    private SpriteRenderer sr;

    private bool isGrounded;
    private void Awake() {

        mybody= GetComponent<Rigidbody2D>();
        //ınspectorda drag and drop yapmakla aynı şey
        anim= GetComponent<Animator>();
        sr= GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementKeyboard();
        AnimatePlayer();
        PlayerJump();
        
    }

    void FixedUpdate(){
        

    }

    void PlayerMovementKeyboard() {

        movementX = Input.GetAxisRaw("Horizontal");
        // Input.GetAxisRaw ile yatay eksende alınan girdi, ya -1, 0, ya da 1 olur

        transform.position += new Vector3(movementX,0f,0f)* moveforce* Time.deltaTime;  

    }

    void AnimatePlayer() {

        if (movementX>0) {
            anim.SetBool(Walkanimation,true);
            sr.flipX=false;
        }

        else if (movementX<0) {
            anim.SetBool(Walkanimation,true);
            sr.flipX=true;
        }

        else {
            anim.SetBool(Walkanimation,false);
        } 

    }

    void PlayerJump() {
        if (Input.GetButtonDown("Jump") && isGrounded){
            isGrounded=false;
            mybody.AddForce(new Vector2(0f,jumpforce), ForceMode2D.Impulse);
            //ForceMode2D.Impulse
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag(Groundtag)){
            isGrounded=true;
        }
        if(collision.gameObject.CompareTag(enemytag)){
            Destroy(gameObject);
        }
    }
    // bu fonksiyon unityde collideri olan ve en az biirnde rigidbody olan nesnelerde otomatik tespit ediliyor.

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag(enemytag)){
            Destroy(gameObject);

        }

    }

}//class




