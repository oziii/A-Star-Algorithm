using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDown : MonoBehaviour
{
    private void OnMouseDown()//Mouse tıklandığında işleve giriyor
    {
        GameObject.Find("GameManager").GetComponent<PathFinding>().MousePos(gameObject);//Mouse ile tıkladığımız düğümü hedef olarak gönderiyoruz.
    }
}
