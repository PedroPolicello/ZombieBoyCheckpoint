using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance;

    [SerializeField] private float speed;
    [SerializeField] private Camera playerCam;
    [SerializeField] private Animator anim;

    private string hitTag;
    private Touch touch;
    private Ray ray;
    private RaycastHit hit;

    private Transform playerTransform => GetComponent<Transform>();

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
    }

    void Update()
    {
        ActionTouch();
    }

    void ActionTouch()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                ray = playerCam.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Ground"))
                    {
                        Vector3 pos = hit.point;
                        pos.y = transform.position.y;
                        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
                        transform.LookAt(pos);
                        anim.SetBool("isRunning", true);
                    }
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                hitTag = null;
                anim.SetBool("isRunning", false);
            }
        }
    }
}