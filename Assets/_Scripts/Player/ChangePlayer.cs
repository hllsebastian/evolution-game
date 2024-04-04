using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    [SerializeField] private List<GameObject> characterList;
    [SerializeField] private float TimeBetweenCharacterChange;
    private int actualCharacterIndex = 0;
    private float lastCharacterChangeTime = 0;

    private void Start()
    {
        ActivateFirstCharacter();
    }

    private void Update()
    {
        if (Input.GetButtonDown("NextCharacter") && CanChangeCharacter())
        {
            ChangeNextCharacter();
        }

        if (Input.GetButtonDown("PreviousCharacter") && CanChangeCharacter())
        {
            ChangePreviousCharacter();
        }
    }

    private void ChangeNextCharacter()
    {
        int temporalIndex = actualCharacterIndex + 1;

        if (temporalIndex >= characterList.Count)
        {
            temporalIndex = 0;
        }

        ActivateCharacter(temporalIndex, actualCharacterIndex);
    }

    private void ChangePreviousCharacter()
    {
        int temporalIndex = actualCharacterIndex - 1;

        if (temporalIndex < 0)
        {
            temporalIndex = characterList.Count - 1;
        }

        ActivateCharacter(temporalIndex, actualCharacterIndex);
    }

    private void ActivateCharacter(int nextCharacterIndex, int previousCharacterIndex)
    {
        foreach (GameObject character in characterList)
        {
            character.SetActive(false);
        }

        GameObject selectedCharacter = characterList[nextCharacterIndex];
        GameObject previousCharacter = characterList[previousCharacterIndex];

        selectedCharacter.transform.position = previousCharacter.transform.position;

        selectedCharacter.SetActive(true);

        selectedCharacter.GetComponent<Rigidbody2D>().velocity = previousCharacter.GetComponent<Rigidbody2D>().velocity;


        actualCharacterIndex = nextCharacterIndex;

        lastCharacterChangeTime = Time.time;
    }

    private void ActivateFirstCharacter()
    {
        if (actualCharacterIndex >= characterList.Count)
        {
            actualCharacterIndex = 0;
        }

        characterList[actualCharacterIndex].SetActive(true);
    }

    private bool CanChangeCharacter()
    {
        if (Time.time < lastCharacterChangeTime + TimeBetweenCharacterChange)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
