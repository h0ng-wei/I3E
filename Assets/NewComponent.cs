using UnityEngine;

public class NewComponent : MonoBehaviour
{
    //Vector3 valueToMove = new Vector3(0, 0, 0.01f);
    //Vector3 rotationMovement = new Vector3(0, 0.1f, 0);
    //float rotationLimit = 180f;
    // Update is called once per frame
    //void Update()
    //{
    //    transform.localPosition += valueToMove;
        
    //    if (transform.localPosition.z > 5f || transform.localPosition.z < -5f)
    //    {
    //        valueToMove.z *= -1;
    //    }

    //    transform.Rotate(rotationMovement, Space.Self);
    //    float currentYRotation = transform.localEulerAngles.y;
    //    if (currentYRotation > 180) currentYRotation -= 360;
        
    //    if (currentYRotation > rotationLimit || currentYRotation < -rotationLimit)
    //    {
    //        rotationMovement.y *= -1;
    //    }
    //}
    public static int totalCollectibles = 9;
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
