using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // these appear in the gui on under whatever script is applied to from public declaration
    public Rigidbody2D theRB;
    public float moveSpeed;
    public Animator myAnim;
    //because of the static var, player can only be instantiated once(i think)
    public static PlayerController instance;

    public string areaTransitionName;
    // Start is called before the first frame update

    //character boundaries
    private Vector3 bottomLeftLimit;

    private Vector3 topRightLimit;

    public bool canMove = true;


    void Start()
    {
        if(instance == null) 
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            { 
                Destroy(gameObject);
            }
        }
        //dont destroy attached object when load(in this place, player), probably automatically done for garbage collection purposes etc.
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
            //Matrix4x4 and y only for 2d
            myAnim.SetFloat("moveX", theRB.velocity.x);
            myAnim.SetFloat("moveY", theRB.velocity.y);

        }
        else
        {
            theRB.velocity = Vector2.zero;
        }
 
        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1 ) {
            
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        
        }
        //youre just taking the current value and limiting it to our parameters
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);

    }

    public void SetBounds(Vector3 botleft, Vector3 topRight)
    {
                                               //this part keeps player from half leaving the screen 
        bottomLeftLimit = botleft + new Vector3(1f, 1f, 0f);
        topRightLimit = topRight + new Vector3(-1f, -1f, 0f);
    }
}
