using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixeltron.Utils;

namespace Punk.Runespirit
{
    public class RSClouds : MonoBehaviour
    {
        public float cloudSpeed = 0.1f; 
        public Flickscreen2DSystem flickscreen2D;
        SpriteRenderer[] _clouds;
        // Start is called before the first frame update
        void Start()
        {
            //_clouds = new List<SpriteRenderer>();
            _clouds = GetComponentsInChildren<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            foreach(SpriteRenderer s in _clouds)
            {
                float ppu = 16.0f;
                float y = s.transform.localPosition.y;
                //Vector3 pixelpos = Camera.main.WorldToScreenPoint(s.transform.localPosition);
                Vector2 pixelpos = flickscreen2D.CameraPointToPixels(s.transform.localPosition); //.localPosition);
                //Debug.Log("Cloud pixel pos is " + pixelpos);
                //pixelpos = flickscreen2D.NormalisePixelsForScreen(pixelpos);
                
                
                Vector2 newpixelpos = pixelpos + (Vector2.right * Time.deltaTime * pixelpos.y * cloudSpeed);
                if (newpixelpos.x > (flickscreen2D.cameraPixels.x + (s.bounds.size.x * ppu)) )
                {
                    newpixelpos = new Vector2(-s.bounds.size.x * ppu, pixelpos.y);                
                }
                
                
                //Vector3 newworldpos = Camera.main.ScreenToWorldPoint(newpixelpos);
                //Vector3 newpixelpos = pixelpos;
                Vector2 newworldpos = flickscreen2D.CameraPixelsToPoint(newpixelpos); 
                s.transform.localPosition = new Vector3(newworldpos.x, y, 0);
            }   
        }
    }
}