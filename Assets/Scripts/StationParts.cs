using UnityEngine;

public class StationParts : MonoBehaviour
{
    [SerializeField]
    int damageTaken;

    [SerializeField]
    public GameObject station;

    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Destructible"){
            Destroy(collision.gameObject);
            station.GetComponent<StationBehavior>().ApplyDamage(damageTaken);
            Destroy(gameObject);
        }
    }
}
