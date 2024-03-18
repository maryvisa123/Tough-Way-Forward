using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform FollowTargetTr; // 
    public Vector3 FollowOffset; // 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = FollowTargetTr.position + FollowOffset;
    }
}
