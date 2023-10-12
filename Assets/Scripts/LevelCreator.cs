using System;
using System.Collections.Generic;
using TowerDefence;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    [SerializeField] private GameObject _sellPrefab;
    [SerializeField] private SpriteRenderer _sellSpr;
    [SerializeField] private Transform _cellParent;

    [SerializeField] private Sprite[] _tileSpr = new Sprite[2];
    [SerializeField] private List<GameObject> _wayPoints = new();

    private int _fieldWidth, _fieldHeight;
    private GameObject[,] _allCells;

    private int currWayX, currWayY;
    private GameObject _firstCell;
    private Vector2 _sprSize;

    public List<GameObject> WayPoints { get => _wayPoints; }
    public static LevelCreator Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _sprSize = new Vector2(_sellSpr.bounds.size.x, _sellSpr.bounds.size.y);
        CreateLevel(SceneManager.GetActiveScene().buildIndex);
        LoadWaypoints();
        GetComponent<CastleController>().InitCastle(WayPoints[^1].transform);
    }

    private void CreateLevel(int level)
    {
        Vector3 worldVec = _mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        string[] levelStr = LoadLevelText(level);

        _fieldHeight = levelStr.Length;
        _fieldWidth = levelStr[0].Length;
        _allCells = new GameObject[_fieldHeight, _fieldWidth];

        for (int i = 0; i < _fieldHeight; i++)
        {
            for (int j = 0; j < _fieldWidth; j++)
            {
                int sprIndex = int.Parse(levelStr[i].ToCharArray()[j].ToString());
                Sprite spr = _tileSpr[sprIndex];

                bool isGround = spr == _tileSpr[1];
                bool isDecorate = (spr == _tileSpr[2]) || (spr == _tileSpr[3]) || (spr == _tileSpr[4]);

                Vector2 cellPosition = new Vector2(worldVec.x + (_sprSize.x * j),
                                                   worldVec.y + (_sprSize.y * -i));
                CreateCell(isGround, isDecorate, spr, j, i, cellPosition);
            }
        }
    }

    private void CreateCell(bool isGround, bool isDecorate, Sprite spr, int x, int y, Vector2 cellPosition)
    {
        GameObject tmpCell = Instantiate(_sellPrefab);

        tmpCell.transform.SetParent(_cellParent, false);
        tmpCell.GetComponent<SpriteRenderer>().sprite = spr;
        var plotController = tmpCell.GetComponent<PlotTowerSettings>();

        tmpCell.transform.position = cellPosition;

        _allCells[y, x] = tmpCell;

        if (isGround)
        {
            plotController.IsGround = true;

            if (_firstCell == null)
            {
                _firstCell = tmpCell;
                currWayX = x;
                currWayY = y;
            }
        }

        if (isDecorate)
        {
            plotController.IsDecorate = true;
        }
    }

    private string[] LoadLevelText(int levelNum)
    {
        TextAsset tmpTxt = Resources.Load<TextAsset>($"Level{levelNum}Ground");
        string tmpStr = tmpTxt.text.Trim();
        string[] separators = { "\r\n", "\n" };
        return tmpStr.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    }

    private void LoadWaypoints()
    {
        GameObject currWayGO;
        _wayPoints.Add(_firstCell);

        while (true)
        {
            if (CanMoveLeft(currWayX, currWayY))
            {
                currWayGO = _allCells[currWayY, currWayX - 1];
                currWayX--;
            }
            else if (CanMoveRight(currWayX, currWayY))
            {
                currWayGO = _allCells[currWayY, currWayX + 1];
                currWayX++;
            }
            else if (CanMoveUp(currWayX, currWayY))
            {
                currWayGO = _allCells[currWayY - 1, currWayX];
                currWayY--;
            }
            else if (CanMoveDown(currWayX, currWayY))
            {
                currWayGO = _allCells[currWayY + 1, currWayX];
                currWayY++;
            }
            else
            {
                break;
            }

            _wayPoints.Add(currWayGO);
        }
    }

    private bool CanMoveLeft(int x, int y)
    {
        return x > 0 && _allCells[y, x - 1].GetComponent<PlotTowerSettings>().IsGround &&
               !_wayPoints.Exists(cell => cell == _allCells[y, x - 1]);
    }

    private bool CanMoveRight(int x, int y)
    {
        return x < (_fieldWidth - 1) && _allCells[y, x + 1].GetComponent<PlotTowerSettings>().IsGround &&
               !_wayPoints.Exists(cell => cell == _allCells[y, x + 1]);
    }

    private bool CanMoveUp(int x, int y)
    {
        return y > 0 && _allCells[y - 1, x].GetComponent<PlotTowerSettings>().IsGround &&
               !_wayPoints.Exists(cell => cell == _allCells[y - 1, x]);
    }

    private bool CanMoveDown(int x, int y)
    {
        return y < (_fieldHeight - 1) && _allCells[y + 1, x].GetComponent<PlotTowerSettings>().IsGround &&
               !_wayPoints.Exists(cell => cell == _allCells[y + 1, x]);
    }
}