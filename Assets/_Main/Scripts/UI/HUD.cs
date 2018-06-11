using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace mineSweeper.ui {
	public class HUD: MonoBehaviour {
		public RectTransform rectTransform { get; private set; }

		private bool activated;
		public bool Activated {
			get { return activated; }
			set {
				activated = value;
				this.gameObject.SetActive(value);
			}
		}


		private void Awake() {
			rectTransform = GetComponent<RectTransform>();
		}

	}
}
