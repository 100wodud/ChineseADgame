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
        // ������ �±׸� ���� ��� GameObject�� ã�Ƽ� �ı��մϴ�.
        GameObject[] items = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject item in items)
        {
            Destroy(item);
        }
    }
}



