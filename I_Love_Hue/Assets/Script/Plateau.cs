using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plateau : MonoBehaviour
{
    GridLayoutGroup gridLayout;

    [SerializeField]
    Gradient gradientX;

    [SerializeField]
    Gradient gradientY;

    [SerializeField]
    GameObject cell;

    // Start is called before the first frame update
    void Awake()
    {
        gridLayout = GetComponent<GridLayoutGroup>();

        RectTransform aRectTransformReference = GetComponent<RectTransform>();

        print(aRectTransformReference.rect.height / UndestroyRule.instance.NbColone);

        Vector2 newSize = new Vector2(aRectTransformReference.rect.width / UndestroyRule.instance.NbLigne, aRectTransformReference.rect.height / UndestroyRule.instance.NbColone);

        gridLayout.cellSize = newSize;


        for (int i = 0; i < UndestroyRule.instance.NbLigne * UndestroyRule.instance.NbColone; i++)
        {
            if (cell.GetComponent<RectTransform>() != null)
            {
                GameObject tempG = Instantiate(cell, transform);
                tempG.name = i.ToString();
                Color color = Color.black;
                color += gradientX.Evaluate((i % UndestroyRule.instance.NbLigne) / (float)UndestroyRule.instance.NbLigne);
                color *= gradientY.Evaluate((i / UndestroyRule.instance.NbLigne) / (float)UndestroyRule.instance.NbColone);
                tempG.GetComponent<Image>().color = color;
                tempG.GetComponent<Cell>().cBase = tempG.GetComponent<Image>().color;
            }
        }
    }

    private void Start()
    {
        for (int i = 0; i < (UndestroyRule.instance.NbLigne * UndestroyRule.instance.NbColone / 5); i++)
        {
            int tempCase = Random.Range(0, transform.childCount);
            int tempNewPose = Random.Range(0, transform.childCount);
            Color tempColor = transform.GetChild(tempCase).GetComponent<Image>().color;
            transform.GetChild(tempCase).GetComponent<Image>().color = transform.GetChild(tempNewPose).GetComponent<Image>().color;
            transform.GetChild(tempNewPose).GetComponent<Image>().color = tempColor;

            if (!transform.GetChild(tempNewPose).GetComponent<Cell>().IsGood())
            {
                if (transform.GetChild(tempNewPose).GetChild(0).gameObject != null)
                    transform.GetChild(tempNewPose).GetChild(0).gameObject.SetActive(false);
            }

            if (!transform.GetChild(tempCase).GetComponent<Cell>().IsGood())
            {
                if (transform.GetChild(tempCase).GetChild(0).gameObject != null)
                    transform.GetChild(tempCase).GetChild(0).gameObject.SetActive(false);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
