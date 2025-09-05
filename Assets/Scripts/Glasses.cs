using UnityEngine;

public enum Models
{
    Round,
    Cube,
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
    [SerializeField] private Material[] materials;
    
    private void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
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
