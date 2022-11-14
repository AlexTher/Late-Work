using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopController : MonoBehaviour
{
    public List<GameObject> placementPointsList = new List<GameObject>();
    public GameObject towerOne;
    public GameObject towerTwo;
    public GameObject towerThree;
    public bool placeTower = false;
    private GameObject t;
    public int currency;
    public int baseCost = 10;
    private GameObject tower;
    public Ray ray;
    public RaycastHit2D hit;
    //public Text textCurrency;
    void Start()
    {
        //textCurrency = textPrefab.GetComponent<Text>();
        currency = 100;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (hit.collider.CompareTag("TowerOne"))
                {
                    towerOneButton();
                   // Debug.Log("TowerOne");
                }
                if (hit.collider.CompareTag("TowerTwo"))
                {
                    towerTwoButton(hit.collider.gameObject);
                    //Debug.Log("TowerTwo");
                }
                if (hit.collider.CompareTag("TowerThree"))
                {
                    towerThreeButton(hit.collider.gameObject);
                    //Debug.Log("TowerThree");
                }
            }
        }
        if (placeTower)
        {

            placeATower(tower);
        }
        
        // textCurrency.text = "Currency = " + currency.ToString();
    }

    public void towerOneButton()
    {
        if (currency >= (baseCost * 1))
        {
            currency -= (baseCost * 1);
            placeTower = true;
            tower = towerOne;
        }
    }

    public void towerTwoButton(GameObject t)
    {
        if (currency >= (baseCost * 2))
        {
            currency -= (baseCost * 2);
            placeTower = true;
            tower = towerTwo;
        }
    }

    public void towerThreeButton(GameObject t)
    {
        if (currency >= (baseCost * 3))
        {
            currency -= (baseCost * 3);
            placeTower = true;
            tower = towerThree;
        }
    }
    void placeATower(GameObject t)
    {
        if (hit)
        {
            if (hit.collider.CompareTag("PlacementPoint"))
            {
                //Debug.Log("PlacementPoint");
                Instantiate(t, new Vector3(hit.point.x, hit.point.y, 0f), Quaternion.identity);
                placeTower = false;
                GameObject.Destroy(hit.transform.gameObject);
                GameObject.Find("CurrencyText").GetComponent<Text>().text = "Currency = " + currency.ToString();
            }
        }

    }
}
