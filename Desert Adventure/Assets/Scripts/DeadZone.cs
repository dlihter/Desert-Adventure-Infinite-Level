using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private float Time = 2.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Invoke("LoadQuitMenu", Time);
        }
    }

    public void LoadQuitMenu()
    {
        Application.LoadLevel(2);
    }

}
