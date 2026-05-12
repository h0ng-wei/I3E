using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    GameObject currentCollectible;

    int collCount = 0;
    int score = 0;

    // Distance player can collect from
    public float collectDistance = 5f;

    void OnCollisionEnter(Collision collision)
    {
        // Detect collectible object
        if (collision.gameObject.CompareTag("Collectible"))
        {
            currentCollectible = collision.gameObject;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == currentCollectible)
        {
            currentCollectible = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Goal area trigger
        if (other.gameObject.CompareTag("GoalArea") && collCount >= 3)
        {
            print("Player entered trigger zone with " + collCount + " collectibles");
            print("Final Score: " + score);
        }
    }

    void OnInteract()
    {
        // Find collectibles within distance
        GameObject[] collectibles =
            GameObject.FindGameObjectsWithTag("Collectible");

        foreach (GameObject obj in collectibles)
        {
            float distance =
                Vector3.Distance(transform.position, obj.transform.position);

            // Check if collectible is close enough
            if (distance <= collectDistance)
            {
                currentCollectible = obj;
                break;
            }
        }

        if (currentCollectible != null)
        {
            Collectible collectible =
                currentCollectible.GetComponent<Collectible>();

            if (collectible != null)
            {
                score += collectible.score;
            }

            collCount++;

            print("Collectibles: " + collCount);
            print("Current Score: " + score);

            Destroy(currentCollectible);

            currentCollectible = null;
        }
    }
}