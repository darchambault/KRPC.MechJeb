using System;
using System.Reflection;

using KRPC.MechJeb.ExtensionMethods;
using KRPC.Service.Attributes;

namespace KRPC.MechJeb.Maneuver {
	/**
	 * <summary>Change longitude of ascending node</summary>
	 */
	[KRPCClass(Service = "MechJeb")]
	public class OperationLan : TimedOperation {
		internal new const string MechJebType = "MuMech.OperationLan";

		// Fields and methods
		private static FieldInfo timeSelector;

		internal static new void InitType(Type type) {
			makeNodesImpl = type.GetCheckedMethod("MakeNodesImpl", BindingFlags.NonPublic | BindingFlags.Instance);
			timeSelector = GetTimeSelectorField(type);
		}

		protected internal override void InitInstance(object instance) {
			base.InitInstance(instance);

			this.InitTimeSelector(timeSelector);
		}
	}
}
