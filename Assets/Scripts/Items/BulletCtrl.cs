using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    [SerializeField] private Transform vfxHitZombie;
    [SerializeField] private Transform vfxHit;

    public int damage = 20;
    public float speed = 70.0f;

    private Rigidbody bulletRigid;


    private void Awake()
    {
        bulletRigid = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        bulletRigid.velocity = transform.forward * speed;

        Destroy(gameObject, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("ShortWeaponArea"))
        {
            if (other.gameObject.CompareTag("ShortZombie"))
            {
                other.GetComponent<ShortZombieController>().zombieHp -= CharacterManager.weaponDmg;
                Instantiate(vfxHitZombie, transform.position, Quaternion.identity);
            }
            else if (other.gameObject.CompareTag("LongZombie"))
            {
                Instantiate(vfxHitZombie, transform.position, Quaternion.identity);
                other.GetComponent<LongZombieController>().zombieHp -= CharacterManager.weaponDmg;
            }
            else if (other.gameObject.CompareTag("CrawlZombie"))
            {
                Instantiate(vfxHitZombie, transform.position, Quaternion.identity);
                other.GetComponent<CrawlZombieController>().zombieHp -= CharacterManager.weaponDmg;
            }
            else if (other.gameObject.CompareTag("DeafZombie"))
            {
                Instantiate(vfxHitZombie, transform.position, Quaternion.identity);
                other.GetComponent<DeafZombieController>().zombieHp -= CharacterManager.weaponDmg;
            }
            else if (other.gameObject.tag == "BossZombie")
            {
                Instantiate(vfxHitZombie, transform.position, Quaternion.identity);
                other.GetComponent<BossZombieController>().zombieHp -= CharacterManager.weaponDmg;
            }else
            {
                Instantiate(vfxHit, transform.position, Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
        
    }
}
