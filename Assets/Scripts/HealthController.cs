using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int healthAmount;
    [SerializeField] private GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.PlaySound(SoundManager.Sound.heal);
            PlayerController player = collision.GetComponent<PlayerController>();
            player.IncrementHealth(healthAmount);
            Instantiate(particles, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
