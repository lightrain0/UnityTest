using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour {
    [Range(1,10)]
    public float moveSpeed = 5f;

    public float jumpSpeed = 5f;

    public float distToGround = 0.5f;

    public Rigidbody rb;

    public LayerMask groundLayers;

    public SphereCollider col;

    public float jumpForce = 7f;

    public float fallFactor = 2.0f;

    public float lowJumpFactor = 1.5f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
    //! Update -> FixedUpdate
    /**! FixedUpdate :  the interval between frames is same.
     *    Update : the interval between frames is random.
     *    LateUpdate : After all updates done , then it is called. Usually to execute the tasks that need be implemented after all other tasks finished.
    */
	void FixedUpdate () {
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(0.1f, 0, 0);
        //    Debug.Log("RightArrow key was pressed.");
        //}  
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(-0.1f, 0, 0);
        //    Debug.Log("LeftArrow key was pressed.");
        //}  
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.Translate(0, 0, 0.1f);
        //    Debug.Log("UpArrow key was pressed.");
        //}  
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.Translate(0,  0,- 0.1f);
        //    Debug.Log("DownArrow key was pressed.");
        //}  

        //if (Input.GetKeyUp(KeyCode.Space))
        //Debug.Log("Space key was released.");

        //if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.AddForce(0, jumpSpeed / Time.deltaTime, 0);
        //    print("Space key is pressed , Player jumps");
        //}
      
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //    transform.Translate(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);

        Vector3 movement = new Vector3(horizontal * moveSpeed * Time.deltaTime, 0, vertical * moveSpeed * Time.deltaTime);
        rb.MovePosition(movement + transform.position);

        //Vector3 movement = new Vector3(horizontal, 0, vertical);
        //rb.AddForce(movement * moveSpeed);

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector3.up * jumpSpeed;
       
         //   rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         //   print("Space key is pressed , Player jumps");

        }
        if(rb.velocity.y < 0)
            rb.velocity += Vector3.up * Physics.gravity.y * fallFactor * Time.deltaTime;
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * lowJumpFactor * Time.deltaTime;
        }
        print("Velocity:" + rb.velocity);

	}
    private bool IsGrounded(){
             return Physics.Raycast(transform.position, Vector3.down, distToGround);

        //return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
                                    //                              col.bounds.min.y, col.bounds.center.z),
                                    //col.radius * .9f, groundLayers);
    }
}
