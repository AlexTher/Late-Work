using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public List<GameObject> placementPointsList = new List<GameObject>();
    public GameObject towerOne;
    public GameObject towerTwo;
    public GameObject towerThree;
    public bool placeTower = false;
    private GameObject t;
    public int currency = 100;
    public int baseCost = 10;
    private GameObject tower;
    public Ray ray;
    public RaycastHit2D hit;
    //public Text textCurrency;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                Debug.Log("Hit");
                if (hit.collider.CompareTag("TowerOne")) {
                    towerOneButton();
                    Debug.Log("TwoerOne");
                }
                if (hit.collider.CompareTag("TowerTwo"))
                    towerTwoButton(hit.collider.gameObject);
                if (hit.collider.CompareTag("TowerThree"))
                    towerThreeButton(hit.collider.gameObject);
            }
        }
        if (placeTower)
        {

            placeATower(tower);
        }
        //textCurrency.text = "Currency = " + currency.ToString();
    }

    public void towerOneButton()
    {
        if (currency > (baseCost * 1))
        {
            currency -= (baseCost * 1);
            placeTower = true;
            tower = towerOne;
        }
    }

    public void towerTwoButton(GameObject t)
    {
        if (currency > (baseCost * 1))
        {
            currency -= (baseCost * 1);
            placeTower = true;
            tower = towerTwo;
        }
    }

    public void towerThreeButton(GameObject t)
    {
        if (currency > (baseCost * 1))
        {
            currency -= (baseCost * 1);
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
                Debug.Log("PlacementPoint");
                Instantiate(t, new Vector3(hit.point.x,hit.point.y,0f), Quaternion.identity);
                placeTower = false;
            }
        }

    }
}
