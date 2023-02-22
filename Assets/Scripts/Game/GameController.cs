using System;
using System.Threading.Tasks;
using Addressables;
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
        [Inject] private AddressablesManager _addressablesManager;

        public GameConfig GameConfig { get; private set; }

        private const string GameConfigPath = "Configs/GameConfig";

        /// <summary>
        /// Main logic entry point
        /// </summary>
        private async void Start()
        {
            await Init();
            TestCharacterConstructor();
        }

        private async Task Init()
        {
            GameConfig = Resources.Load<GameConfig>(GameConfigPath);
            
            _guiController.Init();
            _characterVisualController.Init();
            await _addressablesManager.Init();

            Debug.Log("Complete Init");
        }

        /// <remarc>
        /// Not for release, demo only
        /// </remarc>
        private async void TestCharacterConstructor()
        {
            Debug.Log("TestCharacterConstructor");
            var ctorScreen = _guiController.FindScreen<ConstructorScreen>();
            await ctorScreen.Init(CharacterType.Naomi);
            _guiController.Show(ctorScreen);
        }
    }
}