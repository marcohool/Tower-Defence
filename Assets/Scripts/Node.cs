using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColorPlaceable;
    public Color hoverColorUnplaceable;
    private readonly Vector3 positionOffset = new Vector3(0f,0.5f,0f);
    private GameObject _turret;
    private Renderer _rend;
    private Color _startColor;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
    }

    private void OnMouseDown()
    {
        if (_turret != null)
        {
            Debug.Log("ALREADY TURRET THERE LOOOOOL !");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        _turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
        _rend.material.color = hoverColorUnplaceable;
    }

    private void OnMouseEnter()
    {
        if (_turret != null)
        {
            _rend.material.color = hoverColorUnplaceable;
            return;
        }
        _rend.material.color = hoverColorPlaceable;
    }

    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }
}
