using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{

    public Animator animator;

    public CharacterController cc;

    int leafCount = 0;

    public TMP_Text leafScoreTxt;

    public GameObject sparks;
    public GameObject endScreen;
    public GameObject winScreen; 

    float health = 100;
    float boxHealth = 40;

    public Image healthImage;

    GameManager gm; 

    // Start is called before the first frame update
    void Start()
    {
        sparks.SetActive(false);
        endScreen.SetActive(false);
        winScreen.SetActive(false);

        gm = GetComponent<GameManager>();

    }


    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        transform.Rotate(0, 80 * hAxis * Time.deltaTime, 0);

        cc.Move(transform.forward * 35 * vAxis * Time.deltaTime);

        if (Mathf.Abs(vAxis) > 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("hitBox", true);
            boxHealth -= 1;
        }
        else
        {
            animator.SetBool("hitBox", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collect"))
        {
            leafCount++;
            leafScoreTxt.text = "Leaf Count: " + leafCount.ToString();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("craftStation"))
        {

            if (leafCount >= 4)
            {
                BuildPlane();
            }
        }

        if (other.CompareTag("boxOne"))
        {
            if (boxHealth <= 0 && leafCount >= 3)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("boxTwo"))
        {
            if (boxHealth <= 25)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("boxThree"))
        {
            if (boxHealth <= 35)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("boxFour"))
        {
            if (boxHealth <= 10 && leafCount >= 2)
            {
                Destroy(other.gameObject);
            }
        }
    }

    public void BuildPlane()
    {
        sparks.SetActive(true);
        winScreen.SetActive(true);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemy")
        {
            health = health - 30;

            healthImage.fillAmount = health / 100;

        }

        if (health <= 0)
        {
            PlayerLost();
        }
    }

    public void PlayerLost()
    {
        endScreen.SetActive(true);
    }
}
