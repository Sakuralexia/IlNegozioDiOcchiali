using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public enum OrderType
{
    None,
    Cost,
    Model,
    Brand,
    Color,
    Popularity
}

public class ShelveManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Glasses;
    [SerializeField] private Shelf[] shelves;
    [SerializeField] private Shelf[,] shelfMatrix;
    [SerializeField] private GameObject[,] InstantiatedGlasses;

    [SerializeField] private OrderType orderType;
    [SerializeField] private int rows = 2;
    [SerializeField] private int columns = 8;
    [SerializeField] private Vector3 startingPosition;

    private void Start()
    {
        InstantiatedGlasses = new GameObject[columns, rows];
        shelfMatrix = new Shelf[columns, rows];

        for (int i = 0; i < columns; i++)
        {
            InstantiatedGlasses[i, 0] = Instantiate(Glasses[i], new Vector3(startingPosition.x + (0.90f * i), startingPosition.y - (0.90f * 0), startingPosition.z), Glasses[i].transform.rotation);
        }
        for (int i = 8; i < columns * 2; i++)
        {
            InstantiatedGlasses[i-8, 1] = Instantiate(Glasses[i], new Vector3(startingPosition.x + (0.90f * i), startingPosition.y - (0.90f * 1), startingPosition.z), Glasses[i].transform.rotation);
        }
        for (int i = 0; i < 8; i++) 
        {
            shelfMatrix[i, 0] = shelves[i];
        }
        for (int i = 8; i < 16; i++)
        {
            shelfMatrix[i - 8, 1] = shelves[i];
        }
    }

    private void Update()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                InstantiatedGlasses[i, j].transform.position = shelfMatrix[i, j].transform.position;
                shelfMatrix[i, j].GlassesInformation(InstantiatedGlasses[i, j].GetComponent<Glasses>());
            }
        }

        switch (orderType)
        {
            case OrderType.Cost:
                SortGlassesByCost();
                break;
            case OrderType.Brand:
                SortGlassesByBrand();
                break;
            case OrderType.Model:
                SortGlassesByModel();
                break;
            case OrderType.Color:
                SortGlassesByColor();
                break;
            case OrderType.Popularity:
                SortGlassesByPopularity();
                break;
        }
    }

    public void SortGlassesByColor()
    {
        int rows = InstantiatedGlasses.GetLength(1);
        int cols = InstantiatedGlasses.GetLength(0);
        int total = rows * cols;

        GameObject[] flatArray = new GameObject[total];
        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                flatArray[index++] = InstantiatedGlasses[j, i];
            }
        }

        System.Array.Sort(flatArray, (a, b) =>
        {
            var brandA = a.GetComponent<Glasses>().color;
            var brandB = b.GetComponent<Glasses>().color;
            return brandA.CompareTo(brandB);
        });
        index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                InstantiatedGlasses[j, i] = flatArray[index++];
            }
        }
    }

    public void SortGlassesByModel()
    {
        int rows = InstantiatedGlasses.GetLength(1);
        int cols = InstantiatedGlasses.GetLength(0);
        int total = rows * cols;

        GameObject[] flatArray = new GameObject[total];
        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                flatArray[index++] = InstantiatedGlasses[j, i];
            }
        }

        System.Array.Sort(flatArray, (a, b) =>
        {
            var brandA = a.GetComponent<Glasses>().model;
            var brandB = b.GetComponent<Glasses>().model;
            return brandA.CompareTo(brandB);
        });
        index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                InstantiatedGlasses[j, i] = flatArray[index++];
            }
        }
    }

    public void SortGlassesByBrand()
    {
        int rows = InstantiatedGlasses.GetLength(1);
        int cols = InstantiatedGlasses.GetLength(0);
        int total = rows * cols;

        GameObject[] flatArray = new GameObject[total];
        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                flatArray[index++] = InstantiatedGlasses[j, i];
            }
        }

        System.Array.Sort(flatArray, (a, b) =>
        {
            var brandA = a.GetComponent<Glasses>().brand;
            var brandB = b.GetComponent<Glasses>().brand;
            return brandA.CompareTo(brandB);
        });
        index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                InstantiatedGlasses[j, i] = flatArray[index++];
            }
        }
    }

    public void SortGlassesByCost()
    {
        int rows = InstantiatedGlasses.GetLength(1);
        int cols = InstantiatedGlasses.GetLength(0);
        int total = rows * cols;

        GameObject[] flatArray = new GameObject[total];
        int index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                flatArray[index++] = InstantiatedGlasses[j, i];
            }
        }
        System.Array.Sort(flatArray, (a, b) =>
        {
            float costA = a.GetComponent<Glasses>().cost;
            float costB = b.GetComponent<Glasses>().cost;
            return costA.CompareTo(costB); 
        });
        index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                InstantiatedGlasses[j, i] = flatArray[index++];
            }
        }
    }

    public void SortGlassesByPopularity()
    {
        int rows = InstantiatedGlasses.GetLength(1);
        int cols = InstantiatedGlasses.GetLength(0);
        int total = rows * cols;

        GameObject[] flatArray = new GameObject[total];
        int index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                flatArray[index++] = InstantiatedGlasses[j, i];
            }
        }
        System.Array.Sort(flatArray, (a, b) =>
        {
            float costA = a.GetComponent<Glasses>().popularity;
            float costB = b.GetComponent<Glasses>().popularity;
            return costA.CompareTo(costB);
        });
        index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                InstantiatedGlasses[j, i] = flatArray[index++];
            }
        }
    }
}
