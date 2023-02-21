using Constructor;
using TheSTAR.GUI;
using TheSTAR.GUI.Screens;
using UnityEngine;
using Zenject;

namespace Game
{
    /// <summary>
    /// Main game controller
    /// </summary>
    public class GameController : MonoBehaviour
    {
        [Inject] private GuiController _guiController;
        [Inject] private CharacterVisualController _characterVisualController;

        public GameConfig GameConfig { get; private set; }

        private const string GameConfigPath = "Configs/GameConfig";

        /// <summary>
        /// Main logic entry point
        /// </summary>
        private void Start()
        {
            Init();
            TestCharacterConstructor();
        }

        private void Init()
        {
            GameConfig = Resources.Load<GameConfig>(GameConfigPath);
            _guiController.Init();
            _characterVisualController.Init();
        }

        /// <remarc>
        /// Not for release, demo only
        /// </remarc>
        private void TestCharacterConstructor()
        {
            var ctorScreen = _guiController.FindScreen<ConstructorScreen>();
            ctorScreen.Init(CharacterType.Naomi);
            _guiController.Show(ctorScreen);
        }
    }
}