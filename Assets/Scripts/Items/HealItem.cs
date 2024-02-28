using UnityEngine;

public class HealItem : ItemScript
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {



            DestroyAllItemsWithTag("Item");
        }
    }

    private void DestroyAllItemsWithTag(string tag)
    {
        // 지정된 태그를 가진 모든 GameObject를 찾아서 파괴합니다.
        GameObject[] items = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject item in items)
        {
            Destroy(item);
        }
    }
}



