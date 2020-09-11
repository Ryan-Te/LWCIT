using PiTung;
using PiTung.Components;
using PiTung.Console;
using System;
using System.Text;
using UnityEngine;

namespace LW_Components_In_TUNG
{
	public class LW_Components_In_TUNG : Mod
	{
		public static Color hexToColor(string hex)
		{
			hex = hex.Replace("0x", "");//in case the string is formatted 0xFFFFFF
			hex = hex.Replace("#", "");//in case the string is formatted #FFFFFF
			byte a = 255;//assume fully visible unless specified in hex
			byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
			//Only use alpha if the string has enough characters
			if (hex.Length == 8)
			{
				a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
			}
			return new Color32(r, g, b, a);
		}

		public override string Name => "LW Components In TUNG";
		public override string PackageName => "Ryan.LW Comps In TUNG";
		public override string Author => "Ryan";
		public override Version ModVersion => new Version("0.1.0");

		public override void BeforePatch()
		{

			var XORRight = PrefabBuilder.Custom(() => CPUFP.createCube(1, 2, hexToColor("#1D2f8E")))
				.WithInput(CPUFP.getPegPos(1, 2, "B", 0.5f, 0), CPUFP.getPegQuat("B"), "A")
				.WithInput(CPUFP.getPegPos(1, 2, "B", -0.5f, 0), CPUFP.getPegQuat("B"), "B")
				.WithOutput(CPUFP.getPegPos(1, 2, "F", 0.5f, 0), CPUFP.getPegQuat("F"), "A XOR B");
			ComponentRegistry.CreateNew<XOR>("LWXORRight", "XOR Gate (Right blot)", XORRight);

			var XORLeft = PrefabBuilder.Custom(() => CPUFP.createCube(1, 2, hexToColor("#1D2f8E")))
				.WithInput(CPUFP.getPegPos(1, 2, "B", 0.5f, 0), CPUFP.getPegQuat("B"), "A")
				.WithInput(CPUFP.getPegPos(1, 2, "B", -0.5f, 0), CPUFP.getPegQuat("B"), "B")
				.WithOutput(CPUFP.getPegPos(1, 2, "F", -0.5f, 0), CPUFP.getPegQuat("F"), "A XOR B");
			ComponentRegistry.CreateNew<XOR>("LWXORLeft", "XOR Gate (Left blot)", XORLeft);

			var DLatch = PrefabBuilder.Custom(() => CPUFP.createCube(2, 1, hexToColor("#349F16")))
				.WithInput(CPUFP.getPegPos(2, 1, "B"), CPUFP.getPegQuat("B"), "Input")
				.WithInput(CPUFP.getPegPos(2, 1, "T", 0f, -0.5f), CPUFP.getPegQuat("T"), "Enable")
				.WithOutput(CPUFP.getPegPos(2, 1, "T", 0f, 0.5f), CPUFP.getPegQuat("T"), "Output");
			ComponentRegistry.CreateNew<DLatch>("LWDLatch", "D Latch", DLatch);

			var Oracle = PrefabBuilder.Custom(() => CPUFP.createCube(1, 2, 1, hexToColor("#F365AB")))
				.WithInput(CPUFP.getPegPos(1, 2, 1, "B", 0, -.5f), CPUFP.getPegQuat("B"), "Input")
				.WithOutput(CPUFP.getPegPos(1, 2, 1, "F", 0, .5f), CPUFP.getPegQuat("F"), "Output");
			ComponentRegistry.CreateNew<Oracle>("LWOracle", "Oracle", Oracle);

			var And2 = PrefabBuilder.Custom(() => CPUFP.createCube(1, 1, hexToColor("#6D1916")))
				.WithInput(CPUFP.getPegPos(1, 1, "B", .25f, 0), CPUFP.getPegQuat("B"), "A")
				.WithInput(CPUFP.getPegPos(1, 1, "B", -.25f, 0), CPUFP.getPegQuat("B"), "B")
				.WithOutput(CPUFP.getPegPos(1, 1, "F"), CPUFP.getPegQuat("F"), "A & B");
			ComponentRegistry.CreateNew<AND2>("LWAND", "AND Gate", And2);

			var And3 = PrefabBuilder.Custom(() => CPUFP.createCube(1, 1.5f, hexToColor("#6D1916")))
				.WithInput(CPUFP.getPegPos(1, 1.5f, "B", .5f, 0), CPUFP.getPegQuat("B"), "A")
				.WithInput(CPUFP.getPegPos(1, 1.5f, "B", 0f, 0), CPUFP.getPegQuat("B"), "B")
				.WithInput(CPUFP.getPegPos(1, 1.5f, "B", -.5f, 0), CPUFP.getPegQuat("B"), "C")
				.WithOutput(CPUFP.getPegPos(1, 1.5f, "F"), CPUFP.getPegQuat("F"), "A & B & C");
			ComponentRegistry.CreateNew<AND3>("LWAND3", "Three-way AND Gate", And3);

			var And4 = PrefabBuilder.Custom(() => CPUFP.createCube(1, 2, hexToColor("#6D1916")))
				.WithInput(CPUFP.getPegPos(1, 2, "B", .75f, 0), CPUFP.getPegQuat("B"), "A")
				.WithInput(CPUFP.getPegPos(1, 2, "B", .25f, 0), CPUFP.getPegQuat("B"), "B")
				.WithInput(CPUFP.getPegPos(1, 2, "B", -.25f, 0), CPUFP.getPegQuat("B"), "C")
				.WithInput(CPUFP.getPegPos(1, 2, "B", -.75f, 0), CPUFP.getPegQuat("B"), "D")
				.WithOutput(CPUFP.getPegPos(1, 2, "F"), CPUFP.getPegQuat("F"), "A & B & C & D");
			ComponentRegistry.CreateNew<AND4>("LWAND4", "Four-way AND Gate", And4);

			var ShortDelayer = PrefabBuilder.Custom(() => CPUFP.createCube(0.75f, 1))
				.WithInput(CPUFP.getPegPos(0.75f, 1, "BT",0,0.35f), CPUFP.getPegQuat("BT"), "Input")
				.WithOutput(CPUFP.getPegPos(0.75f, 1, "FT", 0, 0.35f), CPUFP.getPegQuat("FT"), "Output");
			ComponentRegistry.CreateNew<SDelay>("LWDelayShort", "Short Delayer", ShortDelayer);

			var Relay = PrefabBuilder.Custom(() => CPUFP.createCube(2, 1, hexToColor("#7E133B")))
				.WithInput(CPUFP.getPegPos(2, 1, "B"), CPUFP.getPegQuat("B"), "Input")
				.WithInput(CPUFP.getPegPos(2, 1, "F"), CPUFP.getPegQuat("F"), "Input2")
				.WithInput(CPUFP.getPegPos(2, 1, "T"), CPUFP.getPegQuat("T"), "Enable");
			ComponentRegistry.CreateNew<Relay>("LWRelay","Relay",Relay);
		}
	}
}
