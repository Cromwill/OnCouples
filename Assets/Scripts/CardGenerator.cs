using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab; 

    private RectTransform _selfRectTransform;
    private GridLayoutGroup _selfGridLayoutGroup;
    private Random _r = new Random();
    private Generator _generator;
    private const int _startNumberForGeneration = 1;
    private const int _finishNumberForGeneration = 8;
    private const float _aspectForElements = 1.5f;

    private void Start()
    {
        _generator = new Generator();
        _selfRectTransform = GetComponent<RectTransform>();
        _selfGridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    public void Generate(int elementCount)
    {
        _selfGridLayoutGroup.cellSize = _generator.GetSizeForRect(_selfRectTransform.rect, _selfGridLayoutGroup, elementCount, _aspectForElements);
        var doubleValueArray = _generator.GetDoubleMeaningArray(elementCount, _startNumberForGeneration, _finishNumberForGeneration, _r);

        for (int i = 0; i < elementCount; i++)
        {
            GameObject cardObject = _generator.CardGenerate(this.transform, doubleValueArray[i], _cardPrefab);
        }
    }

    public void ReGenerate(int elementCount)
    {
        var childs = GetComponentsInChildren<GameCard>();

        foreach(var v in childs) Destroy(v.gameObject);

        if(elementCount != 0) Generate(elementCount);
    }
}
