using System;
using UnityEngine;

//traps move control
public class MoveControl : MonoBehaviour
{
    public bool IsLoop; 
    public Transform[] MoveTrs; 
    public float MoveSpeed; 

    private int index; 

    private void Start()
    {
        index = 0;
    }

    private void Update()
    {
        Vector3 targetPos = MoveTrs[index].position;
        Vector3 direction = targetPos - transform.position;
        Vector3 moveDis = MoveSpeed * Time.deltaTime * direction.normalized;
        if (direction.magnitude < 0.05f || moveDis.magnitude >= direction.magnitude)
        {
            transform.position = targetPos;
            index++;

            if (index >= MoveTrs.Length)
            {
                if (!IsLoop)
                {
                    Array.Reverse(MoveTrs);
                }
                index = 0;
            }
        }
        else
        {
            transform.position += moveDis;
        }
    }
}
