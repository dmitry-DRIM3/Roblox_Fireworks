using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{   
    private Camera directionCamera;
    public LayerMask layer;

    public GameObject Cube;
    public GameObject SpawnForm;

    private void Start()
    {
        directionCamera = Camera.main;
    }

    public void Update()
    {
        RaycastHit hit;

        bool hitFlag = false;
        Vector3 point = Vector3.zero;

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(directionCamera.transform.position, directionCamera.transform.forward * 10, out hit, 10, layer))
            {
                point = hit.point;
                SpawnForm.transform.position = point;
                hitFlag = true;
            }
        }

        if (Input.GetMouseButtonUp(0) && hitFlag)
        {
            GameObject spawnObj = Instantiate(Cube, point,Quaternion.identity);
            Destroy(spawnObj, 10);
        }
    }
}
