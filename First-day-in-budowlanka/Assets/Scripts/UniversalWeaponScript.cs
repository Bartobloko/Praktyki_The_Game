using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalWeaponScript : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public float buletSpeed;
    public float bulletSpread;

    // Update is called once per frame
    void Update(){
        if(Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }
    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position , firepoint.rotation);
        Rigidbody2D rb =  bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * buletSpeed,ForceMode2D.Impulse);
    }
}
