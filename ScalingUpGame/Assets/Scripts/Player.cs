using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Class creator: Faith Faulkner
/// Class purpose: Holds information about the player character
/// </summary>
public class Player : MonoBehaviour
{
    //fields
    [SerializeField] private Sprite texture;
    private Collider2D collider;
    [SerializeField] private Rigidbody2D playerBody;

    //movement-based fields
    private float minSpeed;
    private float maxSpeed;

    private Vector3 velocity; //the player's velocity
    private Vector3 directionVector; //where the player is facing

    private Vector3 acceleration; //the player's acceleration
    private Vector3 accelerationRate; //how fast the player should accelerate

    //properites

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //start velocity at 0
        velocity = Vector3.zero;

        //start facing right

        directionVector = new Vector3(1,0,0);
        //set min and max speed
        minSpeed = 1;
        maxSpeed = 10;

        //get the player's rigidbody
        playerBody = gameObject.GetComponent<Rigidbody2D>();

        //get the sprite attachted to the player
        texture = gameObject.GetComponent<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {

        //apply the velocity force to the rigidbody
        playerBody.AddForce(velocity);

    }

    //methods
    ///<summary>
    ///method creator: Faith Faulkner
    ///Method purpose: use unity input actions to move the player with WASD
    ///</summary>
    public void OnPlayerMove(InputAction.CallbackContext context)
    {
        Debug.Log("Actions happening");
        //get a vector2d representation of the input action
        Vector2 inputVector = context.ReadValue<Vector2>();

        //normalize this vector, make this the direction vector
        directionVector = inputVector.normalized;

        //multiply the direction vector by the speed to find velocity
        velocity = directionVector * minSpeed;
   
    }

    //debugging
    public void OnDrawGizmos()
    {
        //draw the current Velocity from the center of the player to one unit away from it
        Gizmos.DrawLine(transform.position,
            new Vector3(transform.position.x+velocity.x, transform.position.y+velocity.y,
            transform.position.z));
    }
}
