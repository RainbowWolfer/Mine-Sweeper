using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace mineSweeper.ui {
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public class ModeButton: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler {
		public Image bg;
		public Text text;
		public Shadow shadow;
		public Outline outline;
		public string content;
		public bool isMouseOn;
		[Range(0, 1f)]
		public float fillAmount = 1;
		public Action action;

		public void OnPointerDown(PointerEventData eventData) {
			bg.color = new Color(0.8f, 0.8f, 0.8f, 1);
		}

		public void OnPointerUp(PointerEventData eventData) {
			bg.color = new Color(1, 1, 1, 1);
			if(action != null) {
				action.Invoke();
			}
		}

		public void OnPointerEnter(PointerEventData eventData) {
			isMouseOn = true;
		}

		public void OnPointerExit(PointerEventData eventData) {
			isMouseOn = false;
			bg.color = new Color(1, 1, 1, 1);
		}

		private void Update() {
			text.text = content;

			bg.fillAmount = fillAmount;
			outline.effectDistance = Vector2.Lerp(outline.effectDistance, Vector2.one * (isMouseOn ? 3 : 0), Time.deltaTime * 5);
		}
	}
}
