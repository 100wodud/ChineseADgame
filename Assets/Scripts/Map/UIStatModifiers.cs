using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStatModifiers : MonoBehaviour
{
    [SerializeField] private List<CharacterStats> statsModifier;
    public GameObject Player;
    public void OnSelectItem()
    {
        CharacterStatsHandler statsHandler = Player.GetComponent<CharacterStatsHandler>();

        foreach (CharacterStats stat in statsModifier)
        {
            statsHandler.AddStatModifier(stat);

        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
