using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMetrics : MonoBehaviour
{
    [SerializeField] private Transform endPositionTransform;
    public Vector3 endPosition => endPositionTransform.position;
}
