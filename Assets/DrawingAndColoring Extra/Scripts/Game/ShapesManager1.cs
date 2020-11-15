using UnityEngine;
using System.Collections;
using System.Collections.Generic;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

namespace IndieStudio.DrawingAndColoring.Logic
{
    public class ShapesManager1 : MonoBehaviour
    {
        /// <summary>
        /// The shapes list.
        /// </summary>
        public List<Shape1> shapes = new List<Shape1> ();

        /// <summary>
        /// The last selected shape.
        /// </summary>
        [HideInInspector]
        public int lastSelectedShape;

        /// <summary>
        /// The instance of this class.
        /// </summary>
        public static ShapesManager1 instance;

        void Awake ()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad (gameObject);
                lastSelectedShape = 0;
            } else {
                Destroy (gameObject);
            }
        }

        [System.Serializable]
        public class Shape1
        {
            public bool showContents1 = true;
            public GameObject gamePrefab1;
        }
    }
}