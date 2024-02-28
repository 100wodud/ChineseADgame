using UnityEngine;

public abstract class PickupItem: MonoBehaviour
{

    [SerializeField] private bool destroyOnPickup = true;
    [SerializeField] private LayerMask canBePickupBy;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canBePickupBy.value == (canBePickupBy.value | (1 << other.gameObject.layer)))
        {

            Debug.Log("충돌했다!");
            OnPickedUp(other.gameObject);
            if (destroyOnPickup)
            {
                DestroyAllItemsWithTag("Item");
            }

        }
    }

    private void DestroyAllItemsWithTag(string tag)
    {
   
        GameObject[] items = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject item in items)
        {
            Destroy(item);
        }
    }
    protected abstract void OnPickedUp(GameObject receiver);
}



