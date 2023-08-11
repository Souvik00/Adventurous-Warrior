using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class knief : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    private Vector2 direct;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
     void FixedUpdate()
    {
        rb.velocity = direct * speed; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initialize(Vector2 direct)
    {
        this.direct = direct;
    }
    void OnBecameInvisible()
    {
        //Destroy(gameObject);
    }
}
