using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float followDistance;
    void Update()
    {
        Vector3 pos = target.position;
        pos.y = transform.position.y;
        pos.z = target.position.z - followDistance;
        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
    }
}