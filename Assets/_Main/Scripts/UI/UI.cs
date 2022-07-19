using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace mineSweeper.ui {
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Canvas))]
	public class UI: MonoBehaviour {
		public static UI Instance;
		public Animator anim;

		[Header("Canvas")]
		public Canvas canvas;

		[Header("HUDs")]
		public HUD entryHUD;
		public HUD inGame;
		public HUD outro;

		[Header("Buttons")]
		public ModeButton easy;
		public ModeButton normal;
		public ModeButton hard;
		public ModeButton custom;
		public ModeButton back;
		public ModeButton start;
		public ModeButton backToRestart;

		[Header("Side")]
		public SideTriangleButton quit;
		public SideTriangleButton credits;
		public SideTriangleButton sideBackButton;

		[Header("About")]
		public RectTransform aboutPanel;
		public ModeButton githubButton;

		[Header("Entry")]
		public CustomPanel customPanel;

		[Header("In Game")]
		public Text timeText;
		public Text mineText;

		[Header("Outro")]
		public Text title;
		public Text modeText;
		public Text minesSweptText;
		public Text timePassedText;
		public Text bestMines;
		public Text bestTime;

		private void Awake() {
			Instance = this;
			entryHUD.Activated = true;
			inGame.Activated = false;
			outro.Activated = false;
			easy.action = () => {
				Level.Instance.StartGame(9, 9, 10, "Easy");
			};
			normal.action = () => {
				Level.Instance.StartGame(16, 16, 40, "Normal");
			};
			hard.action = () => {
				Level.Instance.StartGame(30, 16, 99, "Hard");
			};
			custom.action = () => {
				OpenRightGroup();
			};
			back.action = () => {
				OpenLeftGroup();
			};
			start.action = () => {
				Level.Instance.StartGame(
					customPanel.row.value,
					customPanel.column.value,
					customPanel.mine.value,
					customPanel.row.value + "x" + customPanel.column.value + " : " + customPanel.mine.value);
			};
			backToRestart.action = () => {
				outro.Activated = false;
				inGame.Activated = false;
				entryHUD.Activated = true;
				Level.Instance.ClearGrids();
				CameraController.Instance.InitializeCameraPosition();
			};
			quit.action = () => {
				Application.Quit();
			};
			sideBackButton.action = () => {
				if(!Level.Instance.isGameStarted) {
					return;
				}
				Level.Instance.BackToMenu();
			};
			credits.action = () => {
				aboutPanel.gameObject.SetActive(!aboutPanel.gameObject.activeSelf);
			};
			githubButton.action = () => {
				Application.OpenURL("https://github.com/RainbowWolfer/Mine-Sweeper");
			};
		}

		private void Start() {

		}

		private void Update() {
			if(Level.Instance.isGameStarted) {
				quit.gameObject.SetActive(false);
				sideBackButton.gameObject.SetActive(true);
			} else {
				quit.gameObject.SetActive(true);
				sideBackButton.gameObject.SetActive(false);
			}
		}

		public void OpenLeftGroup() {
			anim.SetBool("Right", false);
		}
		public void OpenRightGroup() {
			anim.SetBool("Right", true);
		}
		public void SetScore(int mines, int allMines, int seconds, string mode) {
			minesSweptText.text = mines + "/" + allMines;
			timePassedText.text = Level.TransTimeSecondIntToString(seconds);
			bestMines.text = "???";
			bestTime.text = "???";
			modeText.text = mode;
		}
		public void GameOver(bool win) {
			if(win) {
				title.text = "Congratulations";
				title.color = Color.red;
			} else {
				title.text = "Game Over";
				title.color = Color.black;
			}
		}
	}
}
