using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectiveBehaviour : MonoBehaviour
{
    private void OnDestroy()
    {
        GameManager.Instance.ObjectiveDestroyed();
    }
}
