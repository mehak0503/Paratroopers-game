using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Boundary2
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerControl2 : MonoBehaviour
{
    //public float speed;
    public float tilt;

    //public Boundary boundary;
    public GameObject fire;
    public Transform fireSpawn;
    public float fireRate;
    //public GameObject Player;
    private Game_control3 gameControl;

    private float nextFire;

    private void Start()
    {
        //count_left = 0;
        //count_right = 0;
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController3");
        gameControl = gameControllerObject.GetComponent<Game_control3>();

    }

    void Update()
    {
        if (Input.GetButton("Jump") && Time.time > nextFire && (!Game_control3.gameOver))
        {
            nextFire = Time.time + fireRate;
            Instantiate(fire, fireSpawn.position, fireSpawn.rotation);
            //GetComponent<AudioSource>().Play();            

        }

    }

    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        float minRotation = 0;
        float maxRotation = 80;
        float minRotation1 = 280;
        float maxRotation1 = 360;
        Vector3 movement = new Vector3(-0.3f, -2.5f, 0.5f);



        //GetComponent<Rigidbody>().velocity = movement * speed;

        /*GetComponent<Rigidbody>().rotation = Quaternion.Euler
        (
            0.0f,
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().rotation.z, -90, 90)
        );*/

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            /*if (GetComponent<Rigidbody>().rotation.z >= 30)
            {
                return;
            }*/

            transform.RotateAround(movement, new Vector3(0, 0, 1), 5);

            Vector3 currentRotation = transform.localRotation.eulerAngles;
            if (currentRotation.z > 80 && (currentRotation.z < 280))
                currentRotation.z = Mathf.Clamp(currentRotation.z, minRotation, maxRotation);
            transform.localRotation = Quaternion.Euler(currentRotation);
            //if(50*Time.deltaTime>30)

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            /*if (GetComponent<Rigidbody>().rotation.z <= -30)
            {
                return;
            }*/

            transform.RotateAround(movement, new Vector3(0, 0, 1), -5);

            Vector3 currentRotation = transform.localRotation.eulerAngles;
            if (currentRotation.z < 280 && currentRotation.z > 80)
                currentRotation.z = (Mathf.Clamp(currentRotation.z, minRotation1, maxRotation1));
            //print(currentRotation.z);
            transform.localRotation = Quaternion.Euler(currentRotation);

        }
        /*Vector3 currentRotation = transform.localRotation.eulerAngles;
        if(currentRotation.z<-60 || currentRotation.z>60)
        currentRotation.z = Mathf.Clamp(currentRotation.z, minRotation, maxRotation);
        transform.localRotation = Quaternion.Euler(currentRotation);*/

    }
}

