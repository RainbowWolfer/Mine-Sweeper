using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace mineSweeper.grid {
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public class MyGrid: MonoBehaviour {
		public Vector2Int location;
		public bool isMine;
		public GridState state;
		[Range(0, 8)]
		public int mineSuround;

		public Canvas canvas;
		public Image img;

		public Sprite flag;
		public Sprite mine;
		public Sprite blank;

		public Sprite one;
		public Sprite two;
		public Sprite three;
		public Sprite four;
		public Sprite five;
		public Sprite six;
		public Sprite seven;
		public Sprite eight;

		public bool showRed = false;

		private void Start() {
			transform.name = ToString();
		}

		private void Update() {
			if(state == GridState.Undiscovered) {
				img.sprite = null;
			} else if(state == GridState.Discovered) {
				if(isMine) {
					img.sprite = mine;
					if(showRed) {
						img.color = Color.red;
					} else {
						img.color = Color.white;
					}
					return;
				}
				if(mineSuround == 0) {
					img.sprite = blank;
					img.color = new Color(0.2f, 0.2f, 0.2f, 0.7f);
				} else if(mineSuround == 1) {
					img.color = Color.black;
					img.sprite = one;
				} else if(mineSuround == 2) {
					img.color = Color.black;
					img.sprite = two;
				} else if(mineSuround == 3) {
					img.color = Color.black;
					img.sprite = three;
				} else if(mineSuround == 4) {
					img.color = Color.black;
					img.sprite = four;
				} else if(mineSuround == 5) {
					img.color = Color.black;
					img.sprite = five;
				} else if(mineSuround == 6) {
					img.color = Color.black;
					img.sprite = six;
				} else if(mineSuround == 7) {
					img.color = Color.black;
					img.sprite = seven;
				} else if(mineSuround == 8) {
					img.color = Color.black;
					img.sprite = eight;
				}
			} else if(state == GridState.Flag) {
				img.sprite = flag;
			}
		}
		public override string ToString() {
			return location + " : " + (isMine ? "mine" : "grid");
		}
	}
}


public enum GridState {
	Undiscovered, Discovered, Flag
}