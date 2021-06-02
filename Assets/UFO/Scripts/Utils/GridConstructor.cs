#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Utils
{
    public class GridConstructor : MonoBehaviour
    {
        [SerializeField] private Transform prefab;
        [SerializeField] private Vector3 startPoint = Vector3.zero;
        [SerializeField] private Vector3 offsetHexagon  = Vector3.zero;
        [SerializeField] private Vector3 scalePrefabOnInit = Vector3.one;
        [SerializeField] private Vector3 distance = Vector3.one;
        [SerializeField] private int sizeX = 10;
        [SerializeField] private int sizeZ = 10;

        [SerializeField] private List<Transform> list = new List<Transform>();

        public void Create()
        {
            Clear();
            bool isOffset = false;
            if (prefab != null)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    for (int z = 0; z < sizeZ; z++)
                    {
                        var cell = InitCell();
                        list.Add(cell);
                        cell.localPosition = new Vector3(startPoint.x + (distance.x * x), 0f, startPoint.z + (distance.z * z));
                        if (isOffset)
                        {
                            cell.localPosition += offsetHexagon;
                        }
                    }                    
                    isOffset = !isOffset;
                }
            }
        }

        public void Clear()
        {
            list.ForEach(cell => DestroyImmediate(cell.gameObject));
            list.Clear();
        }

        public void SetCenterParentCoord()
        {
            startPoint = new Vector3(-(sizeX/2 * distance.x), 0f, -(sizeZ / 2 * distance.z));
        }

        private Transform InitCell()
        {
            var cell = PrefabUtility.InstantiatePrefab(prefab) as Transform;
            cell.SetParent(this.transform);
            cell.localScale = scalePrefabOnInit;
            return cell;
        }
    }
}
#endif