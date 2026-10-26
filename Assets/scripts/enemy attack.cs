using UnityEngine;

public class enemyattack : MonoBehaviour
{
    float playerHealth = 100f;
    public GameObject GameOverUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision Collision)
    {
        if(Collision.gameObject.CompareTag("Enemy"))
        {
            playerHealth -= 50f;
            if (playerHealth > 0)
            {
                playerHealth -= 50f;
            }
            else
            {
                playerHealth = 0f;
                GameOverUI.SetActive(true);
                Time.timeScale = 0f; 
            }
        }
    }

}
