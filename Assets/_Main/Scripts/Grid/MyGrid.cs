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

		private void Start() {
			transform.name = ToString();
		}

		private void Update() {
			if(state == GridState.Undiscovered) {
				img.sprite = null;
			} else if(state == GridState.Discovered) {
				if(isMine) {
					img.sprite = mine;
					return;
				}
				if(mineSuround == 0) {
					img.sprite = blank;
				} else if(mineSuround == 1) {
					img.sprite = one;
				} else if(mineSuround == 2) {
					img.sprite = two;
				} else if(mineSuround == 3) {
					img.sprite = three;
				} else if(mineSuround == 4) {
					img.sprite = four;
				} else if(mineSuround == 5) {
					img.sprite = five;
				} else if(mineSuround == 6) {
					img.sprite = six;
				} else if(mineSuround == 7) {
					img.sprite = seven;
				} else if(mineSuround == 8) {
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