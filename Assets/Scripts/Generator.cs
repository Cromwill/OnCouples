using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Random = System.Random;

public class Generator : ScriptableObject
{
    public GameObject CardGenerate(Transform parent, int valueIndex, GameObject objectPrefab)
    {
        GameObject cardObject = Instantiate(objectPrefab, parent);
        cardObject.GetComponent<GameCard>().SetValue(valueIndex);
        return cardObject;
    }

    /// <summary>
    /// This Calss
    /// </summary>
    /// <param name="gameRect"></param>
    /// <param name="elementSize"></param>
    /// <param name="spacing"></param>
    /// <param name="elementCount"></param>
    /// <param name="aspectRatio"> height to width</param>
    /// <returns></returns>
    public Vector2 GetSizeForRect(Rect gameRect, GridLayoutGroup grid, int elementCount, float aspectRatio, int columns = 5)
    {
        int x, y;
        int rows;
        x = (int)((gameRect.size.x / columns) - grid.spacing.x);
        y = Mathf.FloorToInt(x * aspectRatio);
        rows = (elementCount / columns);

        if ((rows * y) + (grid.spacing.y * (elementCount - 1)) > gameRect.size.y)
        {
            y = (int)((gameRect.size.y / rows) - grid.spacing.y);
            x = Mathf.FloorToInt(y / aspectRatio);
        }
        return new Vector2(x, y);
    }

    public int[] GetDoubleMeaningArray(int count, int min, int max, Random _r)
    {
        int[] doubleMeaningArray = new int[count];
        List<int> positionsinArray = new List<int>();

        for (int i = 0; i < count; i++) positionsinArray.Add(i);

        while (positionsinArray.Count > 0)
        {
            for (int i = min; i <= max; i++)
            {
                if (positionsinArray.Count > 0) SetDoubleIntValues(positionsinArray, doubleMeaningArray, _r, i, 2);
            }
        }
        return doubleMeaningArray;
    }

    private void SetDoubleIntValues(List<int> positionsArray, int[] elements, Random _r, int values, int cicle)
    {
        for (int i = 0; i < cicle; i++)
        {
            int index = _r.Next(0, positionsArray.Count);
            elements[positionsArray[index]] = values;
            positionsArray.Remove(positionsArray[index]);
        }
    }
}
