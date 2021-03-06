using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public List<ItemObject> myInventory; //creating a reeference
    GameObject player;
    public float horizontalMove;
    public float verticalMove;
    public float speed = 10.0f;
    //player movement control

    //destroy duplicate player when load scenes
    public static PlayerControls Instance;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        myInventory = new List<ItemObject>(); //create a list and save inside inventory variable
        //inventory.Add(ScriptableObject.CreateInstance<FoodObject>());
    }




    private void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            transform.Rotate(0, horizontalMove, 0);
            transform.Translate(0, 0, verticalMove);
            transform.Translate(horizontalMove, 0, 0);
        }


    }


   
}
