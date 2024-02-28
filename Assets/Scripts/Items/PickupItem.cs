using UnityEngine;

public abstract class PickupItem: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("충돌했다!");
            OnPickedUp(other.gameObject);
            DestroyAllItemsWithTag("Item");
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



