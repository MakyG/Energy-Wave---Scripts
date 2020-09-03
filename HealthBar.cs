
using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public GameObject Healthbar1;
    public GameObject Healthbar2;
    public float maxHealth = 100;
    public float currentHealth = 100;
    public static float currentHealth2 = 100;
    private float originalScale;

    void Start()
    {
        originalScale = gameObject.transform.localScale.x;
    }

    void Update()
    {
        currentHealth2 = currentHealth;
        if(currentHealth == maxHealth)
        {
            Healthbar1.transform.localScale = new Vector3(0, 0, 0);
            Healthbar2.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            Healthbar1.transform.localScale = new Vector3(1, 1, 1);
            Healthbar2.transform.localScale = new Vector3(1, 1, 1);
        }
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = currentHealth / maxHealth * originalScale;
        gameObject.transform.localScale = tmpScale;
    }

}
