using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UniRx.Operators;
using System;
using UnityEngine.UI;

namespace UniRxTest
{
	/// <summary>
	/// .
	/// </summary>
	public class CreatePrefab : MonoBehaviour
	{
		[SerializeField]
		private Transform parent;

		[SerializeField]
		private GameObject prefab;

		private Queue<int> requestQueue = new Queue<int>();

		private GameObject currentObject = null;

		void Start()
		{
			// リクエストがあった場合にプレハブ生成.
			this.LateUpdateAsObservable()
				.Where(_ => this.requestQueue.Count > 0 && this.currentObject == null)
				.Subscribe(x =>
			{
				var damage = this.requestQueue.Dequeue();
				this.currentObject = Instantiate(this.prefab, this.parent, false) as GameObject;
				this.currentObject.GetComponent<Text>().text = damage.ToString();
			});

			// リクエストする.
			this.UpdateAsObservable()
				.Where(_ => Input.GetMouseButtonDown(0))
				.Subscribe(_ =>
			{
				var damage = UnityEngine.Random.Range(0, 100);
				this.requestQueue.Enqueue(damage);
				Debug.Log("Enqueue = " + damage);
			});
		}

	}
}