using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointsReader : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _pointsTx;
    void Update()
    {
        _pointsTx.text = GameManager.points.ToString("00");//si ponemos F2 nos redondea a dos cifras un float
    }
}
