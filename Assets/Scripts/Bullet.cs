using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(StartLifeTime());
    }

    private IEnumerator StartLifeTime()
    {
        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);
    }
}
