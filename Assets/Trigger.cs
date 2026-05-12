using UnityEngine;

public class NewComponent : MonoBehaviour
{
    public static int totalCollectibles = 4;
    public static int collected = 0;

    public bool isCollectible = false;
    public bool isTriggerZone = false;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerCapsule")
        {
            if (isCollectible)
            {
                collected++;
                Debug.Log("Collected: " + collected + "/" + totalCollectibles);
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerCapsule")
        {
            if (isTriggerZone)
            {
                if (collected >= totalCollectibles)
                {
                    Debug.Log("You Win! All collectibles gathered.");
                }
                 else
                {
                Debug.Log("Collect all items first!");
                }
            }
        }
    }
}
