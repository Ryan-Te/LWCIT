using PiTung.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LW_Components_In_TUNG
{
	class DLatch : UpdateHandler
	{
		protected override void CircuitLogicUpdate()
		{
			if (this.Inputs[1].On)
			{
				this.Outputs[0].On = this.Inputs[0].On;
			}
		}
	}
}
