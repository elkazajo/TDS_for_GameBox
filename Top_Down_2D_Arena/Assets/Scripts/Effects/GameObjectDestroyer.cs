using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
