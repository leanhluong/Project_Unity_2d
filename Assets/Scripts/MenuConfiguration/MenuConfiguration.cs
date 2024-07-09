using UnityEngine;

namespace MenuConfiguration
{
    public class MenuConfiguration : MonoBehaviour
    {
        public enum PageType
        {
            Menu,
            Option,
        }

        public StartMenu startMenuPanel;
        public OptionMenu optionMenuPanel;

        public static MenuConfiguration Instance { get; private set; }
        public PageType currentPage = PageType.Menu;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void SetCurrentPage()
        {
            startMenuPanel.gameObject.SetActive(currentPage == PageType.Menu);
            optionMenuPanel.gameObject.SetActive(currentPage == PageType.Option);
        }

        public void SetPage(PageType page)
        {
            currentPage = page;
            SetCurrentPage();
        }

        public void LoadGame(int index)
        {

        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void BackToMenu()
        {
            SetPage(PageType.Menu);
        }
    }
}
