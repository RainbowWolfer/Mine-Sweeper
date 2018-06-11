using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace mineSweeper.ui {
	public class SideTriangleButton: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {
		public Image bg;
		public Action action;
		public bool isMouseOn;

		private void Update() {
			bg.color = Color.Lerp(bg.color, isMouseOn ? new Color(0.8f, 0.8f, 0.8f, 1) : Color.white, Time.deltaTime * 5);
		}

		public void OnPointerEnter(PointerEventData eventData) {
			isMouseOn = true;
		}

		public void OnPointerExit(PointerEventData eventData) {
			isMouseOn = false;
		}

		public void OnPointerClick(PointerEventData eventData) {
			if(action != null) {
				action.Invoke();
			}
		}
	}
}
