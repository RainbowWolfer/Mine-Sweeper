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

		public Canvas canvas;

		public HUD entryHUD;
		public HUD inGame;
		public HUD outro;

		public ModeButton easy;
		public ModeButton normal;
		public ModeButton hard;
		public ModeButton custom;
		public ModeButton back;
		public ModeButton start;
		public ModeButton backToRestart;

		public SideTriangleButton quit;
		public SideTriangleButton credits;
		public Text cresitsText;

		#region entry
		public CustomPanel customPanel;
		#endregion

		#region inGame
		public Text timeText;
		public Text mineText;
		#endregion

		#region outro
		public Text title;
		public Text modeText;
		public Text minesSweptText;
		public Text timePassedText;
		public Text bestMines;
		public Text bestTime;
		#endregion

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
				Level.Instance.StartGame(customPanel.row.value, customPanel.column.value, customPanel.mine.value, customPanel.row.value + "x" + customPanel.column.value + " : " + customPanel.mine.value);
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
			credits.action = () => {
				cresitsText.gameObject.SetActive(!cresitsText.gameObject.activeSelf);
			};
		}

		private void Start() {

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
