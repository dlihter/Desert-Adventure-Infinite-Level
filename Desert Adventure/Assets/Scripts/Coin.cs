using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip CoinSFX;
    public GameObject ExplosionPrefab;

    private int Value = 1;
    private int TimeValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        
            if (CoinSFX)
            {
                AudioSource.PlayClipAtPoint(CoinSFX, transform.position);
            }

            if (ExplosionPrefab)
            {
                GameObject clone = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(clone, 1.0f);
            }

            GameManager.instance.AddScore(Value);
            GameManager.instance.AddTime(TimeValue);
            Destroy(gameObject);
        }
    }

}
