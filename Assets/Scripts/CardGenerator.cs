using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

[RequireComponent(typeof(GridLayoutGroup))]
public class CardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab; 

    private RectTransform _selfRectTransform;
    private GridLayoutGroup _selfGridLayoutGroup;
    private Random _random = new Random();
    private Generator _generator;
    private const int _startNumberForGeneration = 1;
    private const int _finishNumberForGeneration = 8;
    private const float _aspectForElements = 1.5f;
    private List<GameCard> _gameCardList = new List<GameCard>();

    private void Start()
    {
        _generator = new Generator();
        _selfRectTransform = GetComponent<RectTransform>();
        _selfGridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    public void Generate(int count)
    {
        _selfGridLayoutGroup.cellSize = _generator.GetSizeForRect(_selfRectTransform.rect, _selfGridLayoutGroup, count, _aspectForElements);
        var doubleValueArray = _generator.GetDoubleMeaningArray(count, _startNumberForGeneration, _finishNumberForGeneration, _random);

        for (int i = 0; i < count; i++)
        {
            GameObject cardObject = _generator.CardGenerate(transform, doubleValueArray[i], _cardPrefab);
            _gameCardList.Add(cardObject.GetComponent<GameCard>());
        }
    }

    public bool IsCardsOpen()
    {
        return _gameCardList.Where(a => !a.IsOffside()).Count() <= 0;
    }

    public void ReGenerate(int elementCount)
    {
        foreach (var v in _gameCardList)
        {
            Destroy(v.gameObject);
        }
        _gameCardList.Clear();

        if(elementCount != 0)
            Generate(elementCount);
    }
}
