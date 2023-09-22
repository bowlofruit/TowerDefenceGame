using TowerDefence;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlotTowerSettings : MonoBehaviour
{
    [SerializeField] private UITowerInfoUpdater _UIUpdater;
    [SerializeField] private GameObject _UITowerCreator;
    [SerializeField] private TowerItem _towerItem;
    [SerializeField] private TowerEconomic _towerEconomic;

    private GameObject _tower;
    [SerializeField]private bool isGround;

    public GameObject Tower { get => _tower; set => _tower = value; }
    public bool IsGround { get => isGround; set => isGround = value; }

    private void Awake()
    {
        _UIUpdater = UITowerInfoUpdater.Instance;
        _UITowerCreator = TowerBuilder.Instance.gameObject;
    }

    private void OnMouseDown()
    {
        if (_tower == null)
        {
            ActivePlotSetter.ActivePlot = this;
        }
        else
        {
            if (_towerItem == null)
            {
                _towerItem = _tower.GetComponent<TowerInicializator>().Item;
            }
            if (_towerEconomic == null)
            {
                _towerEconomic = _tower.GetComponent<TowerEconomic>();
            }
            UpdateUITowerInfo(_towerItem, _towerEconomic);
        }
    }

    public void UpdateUITowerInfo(TowerItem towerItem, TowerEconomic towerEconomic)
    {
        _UIUpdater.InitTowerSetting(towerItem.Range, towerItem.Speed, towerItem.Damage);
        _UIUpdater.SetParamsText(towerEconomic);
        _UIUpdater.SetButtonsListeners(towerEconomic);
    }
}