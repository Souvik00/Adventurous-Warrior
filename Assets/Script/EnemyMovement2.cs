using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{
    private Vector3 Position_A,Position_B,Next_Position;
	[SerializeField]
	private Transform From;
	[SerializeField]
	private Transform To;
	[SerializeField]
	private float EnemySpeed;
     private PlayerController player;
    private bool isPlayerComeNear = false;
    private bool atPoint = true;
    private Animator enemyAttack;
    private float dis;
    private bool attack = false;
    // Start is called before the first frame update
    void Start()
    {
        Position_B = To.localPosition;
        Position_A = From.localPosition;
        Next_Position = Position_B;
        player = FindObjectOfType<PlayerController>();
        enemyAttack = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        move();
        isAttack();
    }
    private void move()
    {
        From.localPosition = Vector3.MoveTowards(From.localPosition,Next_Position,EnemySpeed*Time.deltaTime);
        if(Vector2.Distance(Next_Position,From.localPosition) <= 0.2f && !isPlayerComeNear)
        {
            if(!atPoint)
            {
                if(Vector2.Distance(Next_Position,Position_A)<=0.1f)
                {
                    Next_Position = Position_B;
                    From.localScale =new Vector2 (0.2909813f , 0.3247121f);
                }
                else 
                {
                    Next_Position = Position_A;
                    From.localScale =new Vector2 (-0.2909813f , 0.3247121f);
                }
                atPoint = true;
            }
            changePosition();
        }
        if(( Position_B.x >= player.transform.localPosition.x)   && ( player.transform.localPosition.y >=Position_B.y )
            && ( Position_A.x <= player.transform.localPosition.x)   && ( player.transform.localPosition.y >=Position_B.y ))
        {
            isPlayerComeNear = true;
            Next_Position.x = player.transform.localPosition.x;
            if(From.localPosition.x-player.transform.localPosition.x>=0)
                From.localScale =new Vector2 (-0.2909813f , 0.3247121f);
            else
                From.localScale =new Vector2 (0.2909813f , 0.3247121f);
            atPoint = false;
        }
        else
        {
            isPlayerComeNear = false;
            
        }


    }
    private void changePosition()
    {
        if(Vector2.Distance(Next_Position,Position_A)<=0.1f){
            Next_Position = Position_B;
            From.localScale =new Vector2 (0.2909813f , 0.3247121f);
        
        }
        else if(Vector2.Distance(Next_Position,Position_B)<=0.1f){
            Next_Position = Position_A;
            From.localScale =new Vector2 (-0.2909813f , 0.3247121f);
        }
    }
    private void isAttack()
    {
        if(Vector2.Distance(player.transform.localPosition,From.localPosition)<=2f && dis <= 0.4f)
            {
                attack = true;
                
            }
            else
                attack = false;

        enemyAttack.SetBool("Attack", attack);
        
    }
}
