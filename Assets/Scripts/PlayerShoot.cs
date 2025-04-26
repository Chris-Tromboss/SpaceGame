using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float shotDelay;

    private bool shootingConst;
    private bool fireSingle;
    private float lastShot;

    void Update()
    {
        if(shootingConst || fireSingle){
            
            float timeSinceLastShot = Time.time - lastShot;

            if(timeSinceLastShot >= shotDelay){
                FireBullet();

                lastShot = Time.time;
                fireSingle = false;
            }
        }        
    }

    private void FireBullet(){
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();

        rigidbody2D.linearVelocity = bulletSpeed * transform.up;
        
        GameObject bullet2 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rigidbody2D2 = bullet2.GetComponent<Rigidbody2D>();

        rigidbody2D2.linearVelocity = -bulletSpeed * transform.up;
    }

    private void OnAttack(InputValue inputValue){
        shootingConst = inputValue.isPressed;

        if(inputValue.isPressed){
            fireSingle = true;
        }
    }
}
