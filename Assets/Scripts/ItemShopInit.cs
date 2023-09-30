using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence
{
    public class ItemShopInit : MonoBehaviour
    {
        [SerializeField] private Image _imageItem;
        [SerializeField] private TMP_Text _price;

        [SerializeField] private Sprite _stockSprite;
        [SerializeField] private TowerItem _item;

        private void Awake()
        {
            _imageItem.sprite = _stockSprite;
            _price.text = _item.BuyPrice.ToString();
        }
    }
}