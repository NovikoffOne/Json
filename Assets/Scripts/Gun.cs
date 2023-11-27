using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _force;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var bullet = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
            var rgbody = bullet.GetComponent<Rigidbody>();

            var direction = CalculateDistance(_shootPoint.position);

            rgbody.AddForce(direction * _force * Time.deltaTime, ForceMode.Impulse);
        }
    }

    private Vector3 CalculateDistance(Vector3 shootPosition)
    {
        var distance = Input.mousePosition;

        distance.z = 16;

        return distance;
    }
}
