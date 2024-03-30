using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Pumpkins : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;

    private void Start()
    {
        StartCoroutine(SpawnTime());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position =
                Vector3.MoveTowards(transform.position, other.transform.position, speed * Time.deltaTime);
            
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            ScoreManager.Instance.AddScore(1);
        }
    }

    IEnumerator SpawnTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}