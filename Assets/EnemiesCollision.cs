using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCollision : MonoBehaviour
{

    private void Awake()
    {
        Collider boxCollider=gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger=false;
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("collision"+gameObject.name);
    }
}
