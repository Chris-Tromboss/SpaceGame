using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera mainCam;

    private void Awake(){
        mainCam = Camera.main;
    }

    public void Update(){
        DestroyBullets();
    }
    
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Destructible"){
            // Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Blocking"){
            Destroy(gameObject);
        }
    }

    private void DestroyBullets() {
        Vector2 screenPosition = mainCam.WorldToScreenPoint(transform.position);

        if(screenPosition.x < -25 || screenPosition.x > mainCam.pixelWidth + 25
        || screenPosition.y < -25 || screenPosition.y > mainCam.pixelHeight + 25){
            Destroy(gameObject);
        }

    }
}
