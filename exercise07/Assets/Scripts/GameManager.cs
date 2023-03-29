using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject wheat;
    public GameObject leaf; 
    public GameObject startMenu;
    public GameObject leafPanel;
    Controller pc;


    // Start is called before the first frame update
    void Start()
    {
        startMenu.SetActive(true);
        leafPanel.SetActive(false);

        pc = GetComponent<Controller>();

        for (int i = 0; i < 250; i++)
        {
            float wheatX = Random.Range(600, 260);
            float wheatZ = Random.Range(660, 120);
            GameObject grassEffect = Instantiate(wheat, wheat.transform.position, Quaternion.identity);
            wheat.transform.position = new Vector3(wheatX, -3, wheatZ);
        }

        //for (int i = 0; i < 6; i++)
        //{
        //    float leafX = Random.Range(700, 460);
        //    float leafZ = Random.Range(760, 320);
        //    GameObject leafCollect = Instantiate(leaf, leaf.transform.position, Quaternion.identity);
        //    leaf.transform.position = new Vector3(leafX, 0, leafZ);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonClicked()
    {
        startMenu.SetActive(false);
        leafPanel.SetActive(true);
    }

   
}
