using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStatModifiers : MonoBehaviour
{
    [SerializeField] private List<CharacterStats> statsModifier;
    public GameObject Player;
    public GameObject bulletDmg;
    public float CurScore;
    public void OnSelectItem()
    {
        CharacterStatsHandler statsHandler = Player.GetComponent<CharacterStatsHandler>();

        foreach (CharacterStats stat in statsModifier)
        {
            statsHandler.AddStatModifier(stat);

        }
        CurScore = GameManager.I.Score;
        DataManager.I.StageLevelup();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        DataManager.I.CurrentScore = CurScore;
        bulletDmg.GetComponent<Bullet>().dmg = 3;
        Time.timeScale = 1.0f;

    }
}
