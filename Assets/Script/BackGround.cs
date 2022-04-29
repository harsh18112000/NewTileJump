using System;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;

using UnityEngine;
using UnityEngine.UIElements;




    public class BackGround : MonoBehaviour
    {

        public int curindex;
        public int nextindex;
        public List<Transform> bgPool = new List<Transform>();
        public Transform playerTransform;
        
        public int currentBg;
        public float offset;
        public float distance;
        public float[] positionx;
        

        public void Start(){
            curindex=0;
            nextindex=1;
        }
        
       

        private void Update()
        {


        if (playerTransform.position.z > bgPool[currentBg].transform.position.z + distance)
            {
            
                
                int nextPos;
                if (currentBg != 0)
                {
                    nextPos = currentBg - 1;
                }
                else
                {
                    nextPos = bgPool.Count - 1;
                }
           
                float xPos = positionx[UnityEngine.Random.Range(0, positionx.Length)];
                
                Vector3 newPos = bgPool[nextPos].transform.position + new Vector3(0, 0f,5.09f); // Add offset!
                newPos = new Vector3(xPos, newPos.y,newPos.z);
                bgPool[currentBg].transform.position = newPos;
                currentBg++;

                if (currentBg == bgPool.Count)
                {
                    currentBg = 0;
                }
            }
        }

}
