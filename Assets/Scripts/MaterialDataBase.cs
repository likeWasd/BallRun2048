using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName="SphereMaterial")]
public class MaterialDataBase : ScriptableObject
{
    [SerializeField] Material[] sphere;
    public Material[] Sphere => sphere;
}
