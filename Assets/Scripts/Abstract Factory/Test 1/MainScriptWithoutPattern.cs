using Examples.AbstractFactoryExample.Unit;
using Examples.AbstractFactoryExample.Unit.Archer;
using Examples.AbstractFactoryExample.Unit.Knight;
using UnityEngine;
using UnityEngine.UI;

public class MainScriptWithoutPattern : MonoBehaviour
{
    [SerializeField] private Button _knightButton;
    [SerializeField] private Button _mageButton;
    [SerializeField] private Button _archerButton;
    [SerializeField] private Button _clearButton;

    [SerializeField] private GridLayoutGroup _unitGrid;

    [SerializeField] private Toggle _redToggle;
    [SerializeField] private Toggle _blueToggle;
    [SerializeField] private Toggle _greenToggle;

    // Prefabs для каждого юнита.  Можно вынести в ScriptableObject для конфигурации.
    [SerializeField] private GameObject _redKnightPrefab;

    [SerializeField] private GameObject _redMagePrefab;
    [SerializeField] private GameObject _redArcherPrefab;

    [SerializeField] private GameObject _blueKnightPrefab;
    [SerializeField] private GameObject _blueMagePrefab;
    [SerializeField] private GameObject _blueArcherPrefab;

    [SerializeField] private GameObject _greenKnightPrefab;
    [SerializeField] private GameObject _greenMagePrefab;
    [SerializeField] private GameObject _greenArcherPrefab;

    private string _currentTeam = "red"; // Начальная команда

    private void Awake()
    {
        InitButtons();
        InitToggles();
    }

    private GameObject InstantiateUnit(GameObject prefab)
    {
        GameObject go = Instantiate(prefab);
        go.transform.SetParent(_unitGrid.transform, false);
        return go;
    }

    private void InitButtons()
    {
        _knightButton.onClick.AddListener(() =>
        {
            GameObject knightPrefab = null;
            switch (_currentTeam)
            {
                case "red":
                    knightPrefab = _redKnightPrefab;
                    break;

                case "blue":
                    knightPrefab = _blueKnightPrefab;
                    break;

                case "green":
                    knightPrefab = _greenKnightPrefab;
                    break;
            }
            var knightGo = InstantiateUnit(knightPrefab);
            if (_currentTeam == "red")
            {
                knightGo.GetComponent<RedKnight>().Init(3.3f);
            }
            else if (_currentTeam == "blue")
            {
                knightGo.GetComponent<BlueKnight>().Init(4.0f, 2.0f);
            }
        });

        _mageButton.onClick.AddListener(() =>
        {
            GameObject magePrefab = null;
            switch (_currentTeam)
            {
                case "red":
                    magePrefab = _redMagePrefab;
                    break;

                case "blue":
                    magePrefab = _blueMagePrefab;
                    break;

                case "green":
                    magePrefab = _greenMagePrefab;
                    break;
            }
            var mageGo = InstantiateUnit(magePrefab);
            if (_currentTeam == "red")
            {
                mageGo.GetComponent<RedMage>().Init(1.0f, 5.0f);
            }
            else if (_currentTeam == "blue")
            {
                mageGo.GetComponent<BlueMage>().Init(5.0f);
            }
        });

        _archerButton.onClick.AddListener(() =>
        {
            GameObject archerPrefab = null;
            switch (_currentTeam)
            {
                case "red":
                    archerPrefab = _redArcherPrefab;
                    break;

                case "blue":
                    archerPrefab = _blueArcherPrefab;
                    break;

                case "green":
                    archerPrefab = _greenArcherPrefab;
                    break;
            }
            var archerGo = InstantiateUnit(archerPrefab);
            if (_currentTeam == "red")
            {
                archerGo.GetComponent<RedArcher>().Init(1.0f, 1.0f);
            }
            else if (_currentTeam == "green")
            {
                archerGo.GetComponent<GreenArcher>().Init(1.0f);
            }
        });

        _clearButton.onClick.AddListener(() =>
        {
            foreach (Transform child in _unitGrid.transform)
            {
                Destroy(child.gameObject);
            }
        });
    }

    private void InitToggles()
    {
        _redToggle.onValueChanged.AddListener((val =>
        {
            if (val)
            {
                _currentTeam = "red";
            }
        }));

        _blueToggle.onValueChanged.AddListener((val =>
        {
            if (val)
            {
                _currentTeam = "blue";
            }
        }));

        _greenToggle.onValueChanged.AddListener((val =>
        {
            if (val)
            {
                _currentTeam = "green";
            }
        }));
    }

    //Tests
    public void CreateKnight(string team)
    {
        GameObject knightPrefab = null;
        switch (team)
        {
            case "red":
                knightPrefab = _redKnightPrefab;
                break;

            case "blue":
                knightPrefab = _blueKnightPrefab;
                break;

            case "green":
                knightPrefab = _greenKnightPrefab;
                break;
        }
        var knightGo = InstantiateUnit(knightPrefab);
        if (team == "red")
        {
            knightGo.GetComponent<RedKnight>().Init(3.3f);
        }
        else if (team == "blue")
        {
            knightGo.GetComponent<BlueKnight>().Init(4.0f, 2.0f);
        }
    }

    public void CreateMage(string team)
    {
        GameObject magePrefab = null;
        switch (team)
        {
            case "red":
                magePrefab = _redMagePrefab;
                break;

            case "blue":
                magePrefab = _blueMagePrefab;
                break;

            case "green":
                magePrefab = _greenMagePrefab;
                break;
        }
        var mageGo = InstantiateUnit(magePrefab);
        if (team == "red")
        {
            mageGo.GetComponent<RedMage>().Init(1.0f, 5.0f);
        }
        else if (team == "blue")
        {
            mageGo.GetComponent<BlueMage>().Init(5.0f);
        }
    }

    public void CreateArcher(string team)
    {
        GameObject archerPrefab = null;
        switch (team)
        {
            case "red":
                archerPrefab = _redArcherPrefab;
                break;

            case "blue":
                archerPrefab = _blueArcherPrefab;
                break;

            case "green":
                archerPrefab = _greenArcherPrefab;
                break;
        }
        var archerGo = InstantiateUnit(archerPrefab);
        if (team == "red")
        {
            archerGo.GetComponent<RedArcher>().Init(1.0f, 1.0f);
        }
        else if (team == "green")
        {
            archerGo.GetComponent<GreenArcher>().Init(1.0f);
        }
    }

    public void ClearGrid()
    {
        foreach (Transform child in _unitGrid.transform)
        {
            Destroy(child.gameObject);
        }
    }
}