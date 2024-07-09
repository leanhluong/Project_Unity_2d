using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MenuConfiguration
{
    public class OptionMenu : MonoBehaviour
    {
        public Button soundButton;
        public Button displayButton;
        public Button mouseAndKeyBoardButton;
        public Button backButton;

        // Start is called before the first frame update
        void Start()
        {
            backButton.onClick.AddListener(MenuConfiguration.Instance.BackToMenu);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
