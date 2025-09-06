using Mediapipe.Unity;
using UnityEngine;

public class TryOnGlassesManager : MonoBehaviour
{
    [SerializeField] private GameObject chosenGlasses;
    private GameObject instantiatedGlasses;

    private GameObject left;
    private GameObject right;


    private void Start()
    {
        chosenGlasses.GetComponent<Glasses>().brand = ChosenGlasses.brand;
        chosenGlasses.GetComponent<Glasses>().cost = ChosenGlasses.cost;
        chosenGlasses.GetComponent<Glasses>().color = ChosenGlasses.color;
        chosenGlasses.GetComponent<Glasses>().model = ChosenGlasses.model;
        chosenGlasses.GetComponent<Glasses>().popularity = ChosenGlasses.popularity;

        instantiatedGlasses = Instantiate(chosenGlasses);
        instantiatedGlasses.transform.localScale = new Vector3(80, 80, 80);
        instantiatedGlasses.transform.rotation = Quaternion.Euler(0, 90, 0);
        
    }

    private void Update()
    {
        if (left == null && right == null)
        {
            left = GameObject.Find("Left IrisLandmarkList Annotation/Point List Annotation/Point Annotation(Clone)");
            right = GameObject.Find("Right IrisLandmarkList Annotation/Point List Annotation/Point Annotation(Clone)");
        }
        
        

        if (left != null && right != null)
        {
            instantiatedGlasses.transform.position = Vector3.Lerp(left.transform.position, right.transform.position, 0.5f);
        }

        

        
    }
}
