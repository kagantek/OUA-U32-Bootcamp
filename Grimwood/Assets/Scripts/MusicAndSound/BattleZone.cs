using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleZone : MonoBehaviour
{
    public MusicManager musicManager;
    public EnemyManager enemyManager;

    public GameObject battleZone;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<MusicManager>().StartBattleMusic();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<MusicManager>().StopBattleMusic();
        }
    }
}
