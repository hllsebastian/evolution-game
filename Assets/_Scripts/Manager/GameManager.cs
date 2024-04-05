using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject keyPrefab;
    [SerializeField] private Transform keySpawnPosition;
    private NextLevelDoor nextLevelDoor;
    private int totalObjectives;
    private int actualDetroyectObjectives;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitialiceGameLevel();
    }

    private void InitialiceGameLevel()
    {
        totalObjectives = FindObjectsByType<DestroyObjectiveBehaviour>(FindObjectsSortMode.None).Length;
        nextLevelDoor = FindFirstObjectByType<NextLevelDoor>();
    }

    public void ObjectiveDestroyed()
    {
        actualDetroyectObjectives += 1;

        if (actualDetroyectObjectives >= totalObjectives)
        {
            Instantiate(keyPrefab, keySpawnPosition.position, Quaternion.identity);
        }
    }

    public void KeyPickedUp()
    {
        nextLevelDoor.KeyPickedUp();
    }
}
