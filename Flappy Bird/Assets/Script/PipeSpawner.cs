using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private Pipe pipeUp, pipeDown;
    [SerializeField] private Point point;
    [SerializeField] private float spawnInterval = 1;
    [SerializeField] private float holeSize;
    [SerializeField] private float maxMinOffset = 1;   

    //penampung coroutine
    private Coroutine CR_Spawn;

    void Start()
    {
        StartSpawn();
    }

    void StartSpawn()
    {
        if(CR_Spawn == null)
        {
            CR_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
        if(CR_Spawn != null)
        {
            StopCoroutine(CR_Spawn);
        }
    }

    void SpawnPipe()
    {
        //membuat random holeSize
        holeSize = Random.Range(0.8f, 1.2f);

        float y = maxMinOffset * Mathf.Sin(Time.time);
        //clone pipa atas dimana posisi sama dengan object tetapi diputar 180 derajat
        Pipe newPipeUp = Instantiate(pipeUp, transform.position, Quaternion.Euler(0, 0, 180));
        newPipeUp.gameObject.SetActive(true);
        newPipeUp.transform.position += Vector3.up * (holeSize / 2);
        newPipeUp.transform.position += Vector3.up * y;

        //clone pipa bawah dimana posisi dan rotasi sama dengan object
        Pipe newPipeDown = Instantiate(pipeDown, transform.position, Quaternion.identity);
        newPipeDown.gameObject.SetActive(true);
        newPipeDown.transform.position += Vector3.down * (holeSize / 2);
        newPipeDown.transform.position += Vector3.up * y;

        Point newPoint = Instantiate(point, transform.position, Quaternion.identity);
        newPoint.gameObject.SetActive(true);
        newPoint.SetSize(Screen.height);
        newPoint.transform.position += Vector3.up * y; 
    }

    IEnumerator IeSpawn()
    {
        while (true)
        {
            if (bird.IsDead())
            {
                StopSpawn();
            }

            SpawnPipe();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
