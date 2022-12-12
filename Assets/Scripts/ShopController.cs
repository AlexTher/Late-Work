using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopController : MonoBehaviour
{
    public List<GameObject> placementPointsList = new List<GameObject>();
    public GameObject towerOne;
    public GameObject towerTwo;
    public GameObject towerThree;
    public bool placeTower = false;
    private GameObject t;
    public float currency;
    public float baseCost1 = 10f;
    public float baseCost2 = 20f;
    public float baseCost3 = 30f;
    private GameObject tower;
    public Ray ray;
    public RaycastHit2D hit;

    GameObject background;
    GameObject button1;
    GameObject button2;
    GameObject button3;
    GameObject cost1;
    GameObject cost2;
    GameObject cost3;

    int costToChange = 0;

    int upOrDown = 1;

    void Start()
    {
        currency = 100;
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
                if (hit.collider.CompareTag("TowerOne"))
                {
                    towerOneButton();
                }
                else if (hit.collider.CompareTag("TowerTwo"))
                {
                    towerTwoButton();
                }
                else if(hit.collider.CompareTag("TowerThree"))
                {
                    towerThreeButton();
                }
            }
        }

        GameObject.Find("CurrencyText").GetComponent<Text>().text = "Currency = " + currency.ToString();
        GameObject.Find("TowerOneCost").GetComponent<TMPro.TextMeshProUGUI>().text = baseCost1.ToString();
        GameObject.Find("TowerTwoCost").GetComponent<TMPro.TextMeshProUGUI>().text = baseCost2.ToString();
        GameObject.Find("TowerThreeCost").GetComponent<TMPro.TextMeshProUGUI>().text = baseCost3.ToString();
    }

    public void towerOneButton()
    {
        if (currency >= (baseCost1))
        {
            costToChange = 1;
            placeTower = true;
            tower = Instantiate(towerOne, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }
    }

    public void towerTwoButton()
    {
        if (currency >= (baseCost2))
        {
            costToChange = 2;
            placeTower = true;
            tower = Instantiate(towerTwo, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }
    }

    public void towerThreeButton()
    {
        if (currency >= (baseCost3))
        {
            costToChange = 3;
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
                //Instantiate(t, new Vector3(hit.point.x, hit.point.y, 0f), Quaternion.identity);
                //placeTower = false;
                //GameObject.Destroy(hit.transform.gameObject);

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
            if (costToChange == 1)
            {
                currency -= (baseCost1);
                baseCost1 *= 2f;
            }
            if (costToChange == 2)
            {
                currency -= (baseCost2);
                baseCost2 *= 2f;
            }
            if (costToChange == 3)
            {
                currency -= (baseCost3);
                baseCost3 *= 2f;
            }
            costToChange = 0;
        }
    }
        
    public void enemyKilledAddCurr(int curr)
    {
        Debug.Log(currency + " enemyKilledAddCurr is called");
        currency += curr;
    }

    public void shopMover()
    {
        upOrDown *= -1;
        background = GameObject.Find("ShopBackground");
        button1 = GameObject.Find("TowerOneButton");
        button2 = GameObject.Find("TowerTwoButton");
        button3 = GameObject.Find("TowerThreeButton");
        cost1 = GameObject.Find("TowerOneCost");
        cost2 = GameObject.Find("TowerTwoCost");
        cost3 = GameObject.Find("TowerThreeCost");

        if (upOrDown > 0)
        {
            background.transform.position = new Vector3(transform.position.x, -4.52f, transform.position.z);
            button1.transform.position = new Vector3(-4.74f, -4.52f, 10);
            button2.transform.position = new Vector3(-2.29f, -4.52f, 10);
            button3.transform.position = new Vector3(0.5f, -4.52f, 10);
            cost1.GetComponent<RectTransform>().localPosition = new Vector3(-169, -207f, 0);
            cost2.GetComponent<RectTransform>().localPosition = new Vector3(-58, -207f, 0);
            cost3.GetComponent<RectTransform>().localPosition = new Vector3(68, -207f, 0);
        }
        else
        {
            background.transform.position = new Vector3(0, -54.52f, 0);
            button1.transform.position = new Vector3(0, -54.52f, 0);
            button2.transform.position = new Vector3(0, -54.52f, 0);
            button3.transform.position = new Vector3(0, -54.52f, 0);
            cost1.GetComponent<RectTransform>().localPosition = new Vector3(-169, -307f, 0);
            cost2.GetComponent<RectTransform>().localPosition = new Vector3(-58, -307f, 0);
            cost3.GetComponent<RectTransform>().localPosition = new Vector3(68, -307f, 0);
        }
    }
}
