

using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour
{

    public float speed = 15;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    

    private float distance;
    private float startTime;
    public static int MoneyFactor = 2;
    public static int MoneyFactorBoss = 1;
    private GameManagerBehavior gameManager;

    public void hard()
    {
        MoneyFactor = 1;
    }
    public void easy()
    {
        MoneyFactor = 2;
    }
    void Start()
    {

        startTime = Time.time;
        distance = Vector2.Distance(startPosition, targetPosition);
        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManagerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

        // 2 
        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
                // 3
                Transform healthBarTransform = target.transform.Find("HealthBar");
                HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
                healthBar.currentHealth -= Mathf.Max(damage, 0);
                // 4
                if (healthBar.currentHealth <= 0)
                {
                    Destroy(target);
                    AudioSource audioSource = target.GetComponent<AudioSource>();
                    AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

                    gameManager.Gold += 40 + (gameManager.Wave * MoneyFactor);
                }
            }
            Destroy(gameObject);
        }
    }

}
