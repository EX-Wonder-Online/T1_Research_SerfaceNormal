using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReyCastController : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = 100; // 飛ばす&表示するRayの長さ
        float duration = 0f;   // 表示期間（秒）

        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, duration, false);

        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, distance)) {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.tag != "Wall") return;
            Instantiate(arrowPrefab, hit.point, Quaternion.FromToRotation(transform.forward, hit.normal),hitObject.transform);
        }
    }
}
