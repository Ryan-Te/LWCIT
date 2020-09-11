using PiTung.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace LW_Components_In_TUNG
{
	class Oracle : UpdateHandler
	{
		protected override void CircuitLogicUpdate()
		{
			if (this.Inputs[0].On)
			{
				int RandomBool = (int)Math.Round(UnityEngine.Random.value);
				this.Outputs[0].On = Convert.ToBoolean(RandomBool);
			}
			else
			{
				this.Outputs[0].On = false;
			}
		}
	}
}
