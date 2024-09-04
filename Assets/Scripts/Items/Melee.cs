using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] public float damage;
    float damageTerm = 1.0f;

    [SerializeField] ThirdPersonShooterController TPSC;


    private void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.tag == "DeafZombie")
        {
            hit.transform.gameObject.GetComponent<DeafZombieController>().zombieHp -= damage;
        }
        else if (hit.transform.tag == "CrawlZombie")
        {
            hit.transform.gameObject.GetComponent<CrawlZombieController>().GetShortWeaponHit(damage);
        }
        else if (hit.transform.tag == "ShortZombie")
        {
            hit.transform.gameObject.GetComponent<ShortZombieController>().GetShortWeaponHit(damage);
        }
        else if (hit.transform.tag == "LongZombie")
        {
            TPSC.PublicPlaySFX(2);
            hit.transform.gameObject.GetComponent<LongZombieController>().zombieHp -= damage;
        }
    }
}
