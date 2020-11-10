
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public ParticleSystem muzzleFlash;

    public Camera FPScamera;

    private float nextTimeToFire = 0f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(FPScamera.transform.position, FPScamera.transform.forward, out hit,range))
        {
            Debug.Log(hit.transform.name);
             
           Enemy enemy = hit.transform.GetComponent<Enemy>();

            if(enemy!=null)
            {
                enemy.takeDamage(damage);
            }
               
        }
    }
}
