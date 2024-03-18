using UnityEngine;

//Trap will bounce the player when the player touch it
public class Prickle : MonoBehaviour
{
    public float Damage; 
    public float Force; 

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Player player = col.GetComponent<Player>();
            player.Hit(Damage, true, Force * (col.transform.position - transform.position).normalized);
        }
    }
}
