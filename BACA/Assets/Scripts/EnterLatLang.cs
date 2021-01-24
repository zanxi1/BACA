using System;
using System.Collections;
using Google.Maps.Examples.Shared;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Google.Maps.Examples {
    public class EnterLatLang : MonoBehaviour
    {
        [Tooltip("Reference to the base map loader")]
        public BaseMapLoader BaseMapLoader;

        // [Tooltip("Reference to MapService")]
        // public MapsService MapsService;

        public GameObject Text;

        public float Lat = 43.68227926446662f;
        public float Lng = -79.41597133915326f;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {   
            if (Text.GetComponent<Text>().text != ""){
                string phrase = Text.GetComponent<Text>().text;
                string[] latLng = phrase.Split(',');

                Lat = (float) Convert.ToDouble(latLng[0]);
                Lng = (float) Convert.ToDouble(latLng[1]);

                BaseMapLoader.IsInitialized = false;
                BaseMapLoader.Start();

                Debug.Log("Changed Floating Origin");

            }
            // BaseMapLoader.InitFloatingOrigin();
        }
    }
}
