using PiTung.Components;
using PiTung.Console;
using References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LW_Components_In_TUNG
{
	class Relay : UpdateHandler
	{
		InputInputConnection IIC = null;

		protected override void CircuitLogicUpdate()
		{
			var ChildInputs = GetComponentsInChildren<CircuitInput>();

			if (!this.Inputs[2].On && IIC != null)
			{
				StuffDeleter.DestroyIIConnection(IIC);
				IIC = null;
			}

			if (GetComponentsInChildren<Wire>().Length < 1 && this.Inputs[2].On)
			{
				InputInputConnection inputInputConnection = Instantiate(Prefabs.Wire, base.transform).AddComponent<InputInputConnection>();
				inputInputConnection.Input1 = ChildInputs[0];
				inputInputConnection.Input2 = ChildInputs[1];
				inputInputConnection.DrawWire();
				inputInputConnection.unbreakable = true;
				StuffConnector.LinkConnection(inputInputConnection);
				IIC = inputInputConnection;
			}
		}
	}
}
