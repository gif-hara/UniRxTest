using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;

namespace UniRxTest
{
	/// <summary>
	/// .
	/// </summary>
	public class AutoDestroy : MonoBehaviour
	{
		[SerializeField]
		private float delay;

		void Start()
		{
			Destroy(this.gameObject, this.delay);
		}
	}
}