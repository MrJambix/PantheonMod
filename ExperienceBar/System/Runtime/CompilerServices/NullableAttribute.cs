using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x02000004 RID: 4
	[NullableContext(1)]
	[Nullable(0)]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, Inherited = false)]
	public sealed class NullableAttribute : Attribute
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002067 File Offset: 0x00000267
		public NullableAttribute(byte value)
		{
			this.NullableFlags = new byte[]
			{
				value
			};
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000207F File Offset: 0x0000027F
		public NullableAttribute(byte[] value)
		{
			this.NullableFlags = value;
		}

		// Token: 0x04000002 RID: 2
		public readonly byte[] NullableFlags;
	}
}
