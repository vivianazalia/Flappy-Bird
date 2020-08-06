using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private Ground groundRef;
    private Ground prevGround;

    private void SpawnGround()
    {
        if(prevGround != null)
        {
            Ground newGround = Instantiate(groundRef);
            newGround.gameObject.SetActive(true);
            prevGround.SetNextGround(newGround.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //membuat variabel untuk menyimpan ground yang baru keluar dari collider
        Ground ground = collision.GetComponent<Ground>();

        prevGround = ground;
        SpawnGround();
    }
}
