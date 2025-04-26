using System.Numerics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool playerInSights;
    public UnityEngine.Vector2 playerDirection;

    [SerializeField]
    private float detectionDistance;
    private Transform player;
    private float lastShot = 5f;

    public GameObject bulletPrefab;
    [SerializeField]
    private Transform muzzleLocation;

    void Awake()
    {
        player = FindAnyObjectByType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector2 currentPos = player.position - transform.position;
        playerDirection = currentPos.normalized;

        if(currentPos.magnitude <= detectionDistance){
            playerInSights = true;
            if(Time.deltaTime - lastShot >=3.5){
                lastShot = Time.deltaTime;
                FireBullet();
            }

        } else playerInSights =false;
    }

    void FireBullet(){
        GameObject bullet = Instantiate(bulletPrefab, muzzleLocation.transform.position, transform.rotation);
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();

        rigidbody2D.linearVelocity = 12 * transform.up;
    }
}
