using UnityEngine;

namespace InGameMenu
{
    public class InGameSetting : MonoBehaviour
    {
        public enum PageType
        {
            AudioPanel,
            VideoPanel,
            MouseAndKeyboardPanel,
        }

        public PageType pageType;
    }
}