using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{

    public int type; // 1 - sin, 2 - infinite
    public float directionX; // 1 = right, -1 = left, 
    public float directionY; // 1 = up, -1 = down
    public float offsetX; // 180 is completely out of phase, 90 is half out of phase
    public float offsetY; 
    public float speed; // The parallax speed
    public float timeElapsed; //current time elapsed
    public float cycleTime; //How long it takes to complete a Sin cycle *relatively
    public bool random;

    public Transform killPos;
    public Transform spawnPos;


    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;

        if (random) 
        {
            //type = Random.Range(1,3);
            //directionX = Random.Range(-1,2);
            //directionY = Random.Range(-1,2);
            offsetX = Random.Range(-180,180);
            offsetY = Random.Range(-180,180);
            speed = Random.Range(0.1f,1f);
            cycleTime = Random.Range(1f,2f);

        }

    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;


        switch (type)
        {
            case 1:
                //Sin wave parallax
                this.transform.position = new Vector3(this.transform.position.x + Mathf.Sin((timeElapsed + offsetX)/cycleTime ) * speed * directionX, this.transform.position.y + Mathf.Sin((timeElapsed + offsetY)/cycleTime ) * speed * directionY, this.transform.position.z);

                break;
            case 2:
                //Single direction parallax
                this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime*100 * speed * directionX, this.transform.position.y + Time.deltaTime*100 * speed * directionY, this.transform.position.z);
                break;
            default:
                Debug.Log("Default case");
                break;
      }

    //Need to rewrite general case
        if(this.transform.position.x > killPos.position.x)
        {
            this.transform.position = spawnPos.position;

        }
        
    }
}
