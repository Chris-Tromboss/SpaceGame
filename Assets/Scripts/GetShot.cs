using UnityEngine;

public class GetShot : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Destructible" || collision.gameObject.tag == "Bullet"){
            //Dies
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
