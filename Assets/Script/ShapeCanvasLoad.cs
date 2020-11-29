using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieStudio.DrawingAndColoring.Logic
{
    [DisallowMultipleComponent]
    public class ShapeCanvasLoad : MonoBehaviour
    {

        public static ShapeCanvasLoad instance;

        // Use this for initialization
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                //Set up the render camera of the Canvas
                Canvas canvas = instance.GetComponent<Canvas>();
                if (canvas.worldCamera == null)
                {
                    canvas.worldCamera = Camera.main;
                }

                Destroy(gameObject);
            }
        }
    }
}