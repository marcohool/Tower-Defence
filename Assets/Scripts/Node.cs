using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColorPlaceable;
    public Color hoverColorUnplaceable;
    private readonly Vector3 positionOffset = new Vector3(0f,0.5f,0f);
    private GameObject turret;
    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("ALREADY TURRET THERE LOOOOOL !");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
        rend.material.color = hoverColorUnplaceable;
    }

    private void OnMouseEnter()
    {
        if (turret != null)
        {
            rend.material.color = hoverColorUnplaceable;
            return;
        }
        rend.material.color = hoverColorPlaceable;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
