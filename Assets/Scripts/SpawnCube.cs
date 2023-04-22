using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    private GameObject button;
    public GameObject spawnpointNoPhysics, spawnPointPhysics;
    public GameObject cubeNoPhysicsPrefab, cubePhysicsPrefab;

    public void Start()
    {
        button = gameObject;
    }


    public void InstantiateCubeNoPhysics()
    {
        Instantiate(cubeNoPhysicsPrefab, spawnpointNoPhysics.transform.position, Quaternion.identity);
    }

    public void InstantiateCubePhysics()
    {
        Instantiate(cubePhysicsPrefab, spawnPointPhysics.transform.position, Quaternion.identity);
    }
}
