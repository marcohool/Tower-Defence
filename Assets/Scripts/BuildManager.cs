using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    private GameObject turretToBuild;
    public GameObject stadardTurretPrefab;

    private void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        turretToBuild = stadardTurretPrefab;
    }


    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }

}
