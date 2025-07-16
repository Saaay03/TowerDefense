using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CoinsUI : MonoBehaviour
{
    [SerializeField]
    private Text _coinsText;
    [SerializeField]
    private UnityEvent _onCoinsUpdated;
    public void UpdatedCoins(int coins)
    {
        _coinsText.text = "X " + coins.ToString();
        _onCoinsUpdated ?. Invoke();
    }
}
