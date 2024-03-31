using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    [SerializeField] private Vector2 minPos, maxPos;
    [SerializeField] private GameObject pumpkinsPrefab;

    private float spawnPosX;
    private float spawnPosZ;
    private Vector3 spawnPosFinal;
    void Start()
    {
        GeneratePos();
    }

    void GeneratePos()
    {
        spawnPosX = Random.Range(minPos.x, maxPos.x);
        spawnPosZ = Random.Range(minPos.y, maxPos.y);
        spawnPosFinal = new Vector3(spawnPosX,0, spawnPosZ);
        StartCoroutine(SpawnObj());
    }

    IEnumerator SpawnObj()
    {
        Instantiate(pumpkinsPrefab, spawnPosFinal,Quaternion.Euler(-90,0,0));
        yield return new WaitForSeconds(spawnTime);
        GeneratePos();
    }
}
