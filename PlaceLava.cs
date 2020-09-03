
using UnityEngine;
using System.Collections;

public class PlaceLava : MonoBehaviour
{

    public GameObject fieldPrefab;
    private GameObject field;
    private GameManagerBehavior gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }

    void Update()
    {

    }

    private bool CanPlaceField()
    {
        int cost = fieldPrefab.GetComponent<FieldData>().levels[0].costField;
        return field == null && gameManager.Gold >= cost;
    }

    void OnMouseUp()
    {
        if (CanPlaceField())
        {
            field = (GameObject) Instantiate(fieldPrefab, transform.position, Quaternion.identity);
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            gameManager.Gold -= field.GetComponent<FieldData>().CurrentLevel.costField;
        }
        else if (CanUpgradeField())
        {
            field.GetComponent<FieldData>().increaseLevel();
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            gameManager.Gold -= field.GetComponent<FieldData>().CurrentLevel.costField;
        }
    }

    private bool CanUpgradeField()
    {
        if (field != null)
        {
            FieldData fieldData = field.GetComponent<FieldData>();
            FieldLevel nextLevel = fieldData.getNextLevel();
            if (nextLevel != null)
            {
                return gameManager.Gold >= nextLevel.costField;
            }
        }
        return false;
    }

}
