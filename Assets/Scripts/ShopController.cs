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
        if (placeTower)
        {
            tower.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
                placeATower(tower);
            //placeATower(tower);
        }
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
        //textCurrency.text = "Currency = " + currency.ToString();
    }

    public void towerOneButton()
    {
        if (currency > (baseCost * 1))
        {
            currency -= (baseCost * 1);
            placeTower = true;
            tower = Instantiate(towerOne, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }
    }

    public void towerTwoButton(GameObject t)
    {
        if (currency > (baseCost * 1))
        {
            currency -= (baseCost * 1);
            placeTower = true;
            tower = Instantiate(towerTwo, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }
    }

    public void towerThreeButton(GameObject t)
    {
        if (currency > (baseCost * 1))
        {
            currency -= (baseCost * 1);
            placeTower = true;
            tower = Instantiate(towerThree, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }
    }
    void placeATower(GameObject t)
    {
        /*
        if (hit)
        {
            if (hit.collider.CompareTag("PlacementPoint"))
            {
                Debug.Log("PlacementPoint");
                Instantiate(t, new Vector3(hit.point.x,hit.point.y,0f), Quaternion.identity);
                placeTower = false;
            }
        }*/
        print("placing");
        ContactFilter2D contactFilter2D = new()
        {
            layerMask = LayerMask.GetMask("Tower")
        };
        List<Collider2D> touchingTowers = new();
        Tower towerComp = tower.GetComponent<Tower>();
        if (towerComp.boundingCollider.OverlapCollider(contactFilter2D, touchingTowers) == 0)
        {
            towerComp.enabled = true;
            tower = null;
            placeTower = false;
        }

    }
}
