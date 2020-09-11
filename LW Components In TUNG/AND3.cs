using PiTung.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LW_Components_In_TUNG
{
	class AND3 : UpdateHandler
	{
		protected override void CircuitLogicUpdate()
		{
			this.Outputs[0].On = this.Inputs[0].On && this.Inputs[1].On && this.Inputs[2].On;
		}
	}
}
