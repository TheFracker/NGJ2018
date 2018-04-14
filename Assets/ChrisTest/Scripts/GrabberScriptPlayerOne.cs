using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberScriptPlayerOne : MonoBehaviour {

    public string playerInter1;
    private bool grabbed;

    RaycastHit2D hit;
    public Transform holdPoint;
    public Transform otherConsolePoint;
    public float distance = 2f;
    public bool playerOnConsol;
    public GameObject consol;
    public GameObject kit;
    public LayerMask mask = 8;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    // Update is called once per frame
    void FixedUpdate()
    {


        if (Input.GetButtonDown("Player1Inter1"))
        {
            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, mask.value );

                if (hit.collider != null)
                {
                    grabbed = true;
                    GetComponent<Animator>().SetBool("carringStarFish", grabbed);


                }
                //grab
            }
            else if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
               
                //throw
                grabbed = false;
                GetComponent<Animator>().SetBool("carringStarFish", grabbed);


                if (playerOnConsol == true)
                {
                    hit.collider.gameObject.SetActive(true);
                    hit.collider.gameObject.transform.position = new Vector2(otherConsolePoint.position.x, otherConsolePoint.position.y);
                    print("is trigger");
                }

                else

                {
                    hit.collider.gameObject.SetActive(true);
                    hit.collider.gameObject.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                }



                hit.collider.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;


            }
        }

        if (grabbed)
        {
            hit.collider.gameObject.SetActive(false);
            hit.collider.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;


        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == consol)
        {
            playerOnConsol = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerOnConsol = false;
    }
}
