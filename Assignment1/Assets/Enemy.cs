
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    public void takeDamage (float amount)
    {
        health -= amount;
        if(health<=0f)
        {
            Dead();
        }
    }
    void Dead()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
