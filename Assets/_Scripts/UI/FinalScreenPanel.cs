using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScreenPanel : MonoBehaviour
{
    public void PlayAgainButton()
    {
        SceneManagerObject.Instance.LoadScene(0);
    }
}
