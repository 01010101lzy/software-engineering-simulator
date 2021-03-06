using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;


namespace Sesim.Game.Controllers.MainGame
{
    public class CompanyLayoutController : MonoBehaviour
    {
        public CompanyActionController src;

        public GameObject computerPrefab;
        public GameObject floorPrefab;
        public GameObject chairPrefab;
        public GameObject wallPrefab;

        public GameObject rootObject;

        public Material defaultMaterial;
        public Material highlightMaterial;

        public Camera cam;

        // TODO: replace this with more flexible stuff
        bool[,] floorPlan = new bool[30, 30];
        Dictionary<(int x, int z), GameObject> floorLayout
                = new Dictionary<(int x, int z), GameObject>();


        void Awake()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    floorPlan[i, j] = true;
                }
            }
        }

        void Start()
        {
            for (int i = 0; i < floorPlan.GetLength(0); i++)
            {
                for (int j = 0; j < floorPlan.GetLength(1); j++)
                {
                    if (floorPlan[i, j])
                    {
                        var floor = Instantiate(floorPrefab, new Vector3(i * 10, 0, j * 10), new Quaternion());
                        floor.AddComponent<ObjectSelectionController>();
                        floor.transform.SetParent(rootObject.transform);
                        floorLayout.Add((i, j), floor);
                    }
                }
            }
        }
    }
}
