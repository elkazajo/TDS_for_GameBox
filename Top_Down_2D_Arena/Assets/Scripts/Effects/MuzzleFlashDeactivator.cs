using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashDeactivator : MonoBehaviour
{
    private void OnDeactivate()
    {
        gameObject.SetActive(false);
    }
}
