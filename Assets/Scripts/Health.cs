using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject FX; //particle effect
    Vector3 offset;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerFX();
            Destroy(gameObject); 
        }
    }

    private void TriggerFX() //after deadth 
    {
        if (!FX) {return;} // gra idzie dalej mimo ze particle nie bedzie przeciagniete
        offset = new Vector3(-0.5f,-0.2f,-1f);
        GameObject FXObject = Instantiate(FX, transform.position + offset, transform.rotation);
        Destroy(FXObject, 2.5f);
    }
}
