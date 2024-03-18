using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//HP Bar and HPBarManager are used to manage the HP of the game object
public class HPBar : MonoBehaviour
{
    public float MaxHP; 
    public Slider HpBar; 
    public bool isDes; 
    public UnityEvent DesEvent; 
    private float nowHP; 
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        nowHP = MaxHP; 
        HpBar.value = 1;
        audioSource = GetComponent<AudioSource>();
    }

    // Update the HP bar
    public void Hit(float damage)
    {
        nowHP -= damage;

        Debug.Log($"Damage received: {damage}");
        
        if (nowHP <= 0)
        {
            nowHP = 0;
            if (isDes)
            {
                Destroy(gameObject);
            }
        }

        HpBar.value = nowHP / MaxHP;

        // Play the sound effect if damage is received and health is above 0
        if (audioSource && damage > 0) 
        {
            audioSource.Play();
        }
    }

    public void OnDestroy()
    {
        DesEvent?.Invoke();
    }
}
