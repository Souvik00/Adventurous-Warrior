using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{

	private Vector3 Position_A,Position_B,Next_Position;
	[SerializeField]
	private Transform From;
	[SerializeField]
	private Transform To;
	[SerializeField]
	private float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Position_B = To.localPosition;
        Position_A = From.localPosition;
        Next_Position = Position_B;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
    	From.localPosition = Vector3.MoveTowards(From.localPosition,Next_Position,Speed*Time.deltaTime);
    	if(Vector3.Distance(From.localPosition,Next_Position) <=0.1f)
    	{
    		changePosition();
    	}
    }
    private void changePosition()
    {
    	if(Next_Position==Position_A)
    	    Next_Position = Position_B;
    	else if(Next_Position == Position_B)
    	    Next_Position = Position_A;
    }
}
