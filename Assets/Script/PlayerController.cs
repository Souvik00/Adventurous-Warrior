using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 5f;
	public float jumpspeed = 5f;
	private float HorizontalMovement = 0f;
    private float VerticalMovement;
	private Rigidbody2D rigidBody;
	public Transform groundCheckPoint;
	public float groundRadius;
	public LayerMask groundlayer;
	private bool isTouchGround;
	private Animator anm;
    public bool OnLadder;
    public float LadSpeed = 0f;
    [SerializeField]
    private GameObject knief;
    // Start is called before the first frame update
    void Start()
    {
    	rigidBody = GetComponent<Rigidbody2D> ();
    	anm = GetComponent<Animator> ();
        OnLadder = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        HorizontalMovement = Input.GetAxis ("Horizontal");
        VerticalMovement = Input.GetAxis ("Vertical");
        
        isTouchGround = Physics2D.OverlapCircle(groundCheckPoint.position,groundRadius,groundlayer);
        if(HorizontalMovement > 0.2f)
        {
        	rigidBody.velocity = new Vector2 (HorizontalMovement * MovementSpeed , rigidBody.velocity.y);
        	transform.localScale = new Vector2(0.3491092f,0.3491092f);
        }
        else if(HorizontalMovement < -0.2f)
        {
        	rigidBody.velocity = new Vector2 (HorizontalMovement * MovementSpeed , rigidBody.velocity.y);
        	transform.localScale = new Vector2(-0.3491092f,0.3491092f);
        }
        else 
        {
            rigidBody.velocity = new Vector2 (0 , rigidBody.velocity.y);
        }
        if(Input.GetButtonDown("Jump") && isTouchGround)
        {
        	rigidBody.velocity = new Vector2 (rigidBody.velocity.x , jumpspeed);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(isTouchGround){
                anm.SetBool("throw", true);
                anm.SetBool("jumpAndThrow" , false);
            }
            else{
             anm.SetBool("throw", false);
             anm.SetBool("jumpAndThrow" , true);
            }
            throwknief();
        }
        else if(Input.GetKeyUp(KeyCode.F))
        {
            anm.SetBool("throw", false);
             anm.SetBool("jumpAndThrow" , false);
        }

        anm.SetFloat("speed", Mathf.Abs(rigidBody.velocity.x));
        anm.SetBool("Ground", isTouchGround);
        anm.SetBool("OnLadder", OnLadder);
        anm.SetFloat("LadSpeed", Mathf.Abs(rigidBody.velocity.y));
        
        if(Input.GetKeyDown(KeyCode.B))
        {
            anm.SetBool("Attack", true);
        }
        else if(Input.GetKeyUp(KeyCode.B))
        {
            anm.SetBool("Attack", false);
        } 
        if(OnLadder)
        {
            if(VerticalMovement > 0.2f)
                    rigidBody.velocity = new Vector2 (rigidBody.velocity.x , VerticalMovement*MovementSpeed);
                else if(VerticalMovement < -0.2f)
                    rigidBody.velocity = new Vector2 (rigidBody.velocity.x , VerticalMovement*MovementSpeed);
                else
                   rigidBody.velocity = new Vector2 (rigidBody.velocity.x , 0);
            rigidBody.gravityScale = 0;
        }
        else rigidBody.gravityScale = 1;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
            if(other.tag == "Ladder")
            {
                OnLadder = true;
            }
    }
    void OnTriggerExit2D(Collider2D other)
    {
            if(other.tag == "Ladder")
            {
                OnLadder = false;
            }
    }
    public void throwknief()
    {
        if (transform.localScale.x==0.3f)
        {

            GameObject tm = (GameObject)Instantiate(knief, transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            tm.GetComponent<knief>().Initialize(Vector2.right);
        }

        else if(transform.localScale.x==(-0.3f))
        {
           GameObject tm = (GameObject)Instantiate(knief, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            tm.GetComponent<knief>().Initialize(Vector2.left); 

        }
    }

}
