
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Components")]
    public Camera cam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    [Header("Values")]
    public float damage = 10f;
    public float range = 100f;
    public float bulletForce = 50f;

  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            // Identifiying object with the Damage script
            Damage enemy = hit.transform.GetComponent<Damage>(); 
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * bulletForce);
            }

            GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);

        }
    }
}
