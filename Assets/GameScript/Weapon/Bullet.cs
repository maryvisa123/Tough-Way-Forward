using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject HitPrefab; 
    public float MoveSpeed; 
    public float Damage; 
    public LayerMask TargetLayer; 
    public float r; 

    private Vector3 LastPos; 

    // Update is called once per frame
    void Update()
    {
        LastPos = transform.position;
        transform.Translate(  MoveSpeed * Time.deltaTime * transform.up, Space.World);

        //Detect Collision
        Vector3 dir = transform.position - LastPos;
        RaycastHit2D hit2D = Physics2D.CircleCast(LastPos, r, dir, dir.magnitude, TargetLayer);
        if (hit2D.transform)
        {
            OnHit(hit2D.transform);
        }
    }

    private void OnHit(Transform hitTr)
    {
        Player player = hitTr.GetComponent<Player>();
        if (player)
        {
            player.Hit(Damage, false, Vector2.zero);
        }
        else
        {
            HPBar hpBar = hitTr.GetComponent<HPBar>();
            if (hpBar)
            {
                hpBar.Hit(Damage);
            }
        }

        if (hitTr.CompareTag("Bullet"))
        {
            Destroy(hitTr.gameObject);
        }
        
        if (HitPrefab)
        {
            Instantiate(HitPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);

    }
}
