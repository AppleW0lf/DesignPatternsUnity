using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpaghettiCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private Button _incrementButton;

    private int _count;

    private void Start()
    {
        _incrementButton.onClick.AddListener(() =>
        {
            _count++;
            _countText.text = _count.ToString();
        });
    }

    // Лишние операции в Update для демонстрации проблем
    private void Update()
    {
        // Ненужное постоянное обновление
        /*if (Input.GetKeyDown(KeyCode.Space))
            _countText.text = _count.ToString();*/
    }

    public void IncrementCount()
    {
        _count++;
        _countText.text = _count.ToString();
    }
}