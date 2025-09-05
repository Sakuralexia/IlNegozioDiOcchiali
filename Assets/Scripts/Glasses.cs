using UnityEngine;

public enum Models
{
    Square,
    Round,
    Monocle,
    Sunglasses
}

public enum Brand
{
    Gucci,
    Polar,
    Vision,
    Nerdium
}

public enum GlassesColor
{
    Red,
    Green,
    Blue,
    Purple,
    Yellow
}

public class Glasses : MonoBehaviour
{
    [SerializeField] public float cost;
    [SerializeField] public Models model;
    [SerializeField] public Brand brand;
    [SerializeField] public GlassesColor color;
    [SerializeField] public int popularity;
    [SerializeField] private GameObject[] models;
    [SerializeField] private Material[] materials;
    
    private void Start()
    {
        
        switch (model)
        {
            case Models.Square:
                Instantiate(models[0], transform.position, Quaternion.Euler(0, 90, 0), gameObject.transform);
                break;
            case Models.Round:
                Instantiate(models[1], transform.position, Quaternion.Euler(0, 90, 0), gameObject.transform);
                break;
            case Models.Monocle:
                Instantiate(models[2], transform.position, Quaternion.Euler(0, 90, 0), gameObject.transform);
                break;
            case Models.Sunglasses:
                Instantiate(models[3], transform.position, Quaternion.Euler(180, 90, 0), gameObject.transform);
                break;

        }

        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
        switch (color)
        {
            case GlassesColor.Red:
                meshRenderer.material = materials[0];
                break;
            case GlassesColor.Blue:
                meshRenderer.material = materials[1];
                break;
            case GlassesColor.Green:
                meshRenderer.material = materials[2];
                break;
            case GlassesColor.Purple:
                meshRenderer.material = materials[3];
                break;
            case GlassesColor.Yellow:
                meshRenderer.material = materials[4];
                break;

        }

        
    }

}
