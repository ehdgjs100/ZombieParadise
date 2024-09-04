using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSword : MonoBehaviour
{
    private float attackTime = 3.0f;

    private void Update()
    {
        attackTime -= Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && attackTime <= 0.0f)
        {
            Debug.Log("Player hit");
            CharacterManager.instance.characterHp -= 10.0f;
            attackTime = 3.0f;
        }   
    }
}
