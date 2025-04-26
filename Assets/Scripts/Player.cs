using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Player Stats")]
    public int lives = 3;
    public int example;

    private bool isDead;
    private float lastDeath;
    
    [Header("Speeds")]
    public float speed = 5f;
    public float rotationSpeed;

    void Start () {
        var rigidbody = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
            if(!isDead){
                float horizMovement = Input.GetAxis("Horizontal");
                float vertMovement = Input.GetAxis("Vertical");

                Vector2 movementDirection = new Vector2(horizMovement, vertMovement);
                float inputMag = Mathf.Clamp01(movementDirection.magnitude);
                movementDirection.Normalize();

                transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

                if(movementDirection != Vector2.zero){
                    Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
                }

                //Screen Wrap
                if(Mathf.Abs(transform.position.x) >= 30){
                    transform.position = new Vector3(transform.position.x * -.95f, transform.position.y, transform.position.z);
                }
                if(Mathf.Abs(transform.position.y) >= 30){
                    transform.position = new Vector3(transform.position.x, transform.position.y * -.95f, transform.position.z);
                }
            } else {
                if(Time.deltaTime - lastDeath >= 5){
                    Respawn();
                }
            }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Destructible"){
            //Dies
            Destroy(collision.gameObject);
            isDead = true;
            lastDeath = Time.deltaTime;
            
            lives--;
            if(lives == 0){
                //GameOver
            }
        }
    }

    void Respawn(){
        transform.position = new Vector3(0,0,0);
            isDead = false;
    }

}
