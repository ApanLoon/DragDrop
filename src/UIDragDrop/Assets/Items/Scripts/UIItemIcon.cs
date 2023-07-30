using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    [RequireComponent(typeof(RawImage))]
    public class UIItemIcon : MonoBehaviour
    {
        public ItemDefinition Definition;
        public int StackSize 
        {
            get => _stackSize;
            set  
            {
                _stackSize = value;
                _stackCountText.text = _stackSize.ToString();
                _stackCountPanel.gameObject.SetActive(_stackSize > 1);
            }
        }
        private int _stackSize;

        private RawImage _icon;
        private Transform _stackCountPanel;
        private TMP_Text _stackCountText;

        private void Awake()
        {
            if (Definition == null)
            {
                Debug.LogError($"Item {gameObject.name} has no item definition!");
                return;
            }

            _icon = GetComponent<RawImage>();
            _icon.texture = Definition.Icon;

            _stackCountPanel = transform.Find("StackPanel");
            if (_stackCountPanel == null)
            {
                Debug.LogError($"Item {gameObject.name} has no StackPanel child!");
                return;
            }

            var go = _stackCountPanel.Find("Text").gameObject;
            if (_stackCountPanel == null)
            {
                Debug.LogError($"Item {gameObject.name} has no Text child in its StackPanel!");
                return;
            }

            _stackCountText = go.GetComponent<TMP_Text>();
            if (_stackCountText == null)
            {
                Debug.LogError($"Item {gameObject.name} has no TMP_Text component in its StackPanel/Text!");
                return;
            }

            StackSize = 1;
        }
    }
}
