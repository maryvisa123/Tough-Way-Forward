using UnityEngine;

public class LifeTimeDes : MonoBehaviour
{
    public float LifeTime; 
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, LifeTime);
    }
}
