using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float off,offsmoth;
    private Vector3 playerpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerpos= new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        if(player.transform.localScale.x>0f)
        {
            playerpos = new Vector3(playerpos.x + off, playerpos.y, playerpos.z);
        }
        else
        {
            playerpos = new Vector3(playerpos.x - off, playerpos.y, playerpos.z);
        }
        transform.position = Vector3.Lerp(transform.position, playerpos, offsmoth * Time.deltaTime);
    }
}
