using UnityEngine;
using UnityEngine.UI;

public class GameCard : MonoBehaviour
{
    [SerializeField] private Text _cardNumber;
    [SerializeField] private float _openLeftTime;
    private IVerificationData _verification;

    private Animator _animator;
    private CardState _state = CardState.Close;
    private RectTransform _transform;
    private ITimer _timer;
    private Button _selfButton;

    public Text CardNumber { get => _cardNumber;}

    private void Start()
    {
        _transform = GetComponent<RectTransform>();
        _animator = GetComponent<Animator>();
        _selfButton = GetComponent<Button>();
        _verification = GetComponentInParent<IVerificationData>();
        _selfButton.onClick.AddListener(delegate () { Turn(); });
        _timer = new Timer();

        if (_state == CardState.Close && _transform.localScale.x > 0) Turn();
    }

    private void Update()
    {
        if(_state == CardState.Open)
        {
            _timer.StartTimer(_openLeftTime);
            if (!_timer.Countdown(Time.deltaTime)) Turn();
        }
        if(_state == CardState.Offside) Destroy(_selfButton);
    }

    public void Turn()
    {
        if (_state != CardState.Offside)
        {
            if (_transform.localScale.x < 0) _animator.Play("OpenCard");
            else _animator.Play("CloseCard");
        }
    }

    public void SetValue(int value)
    {
        CardNumber.text = value.ToString();
    }

    public bool IsOpen()
    {
        return _state == CardState.Open;
    }

    public bool IsOffside()
    {
        return _state == CardState.Offside;
    }

    public void ChangeCardState(CardState NewState)
    {
        _state = NewState;
    }

    public void SendForVerification()
    {
        _verification.Verification(this);
    }

    public enum CardState
    {
        Open,
        Close,
        Offside
    }
}
