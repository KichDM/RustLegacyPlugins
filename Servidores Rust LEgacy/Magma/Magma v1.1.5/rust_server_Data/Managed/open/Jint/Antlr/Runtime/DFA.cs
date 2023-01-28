using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Antlr.Runtime.Debug;

namespace Antlr.Runtime
{
	// Token: 0x0200009F RID: 159
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class DFA
	{
		// Token: 0x0600074B RID: 1867 RVA: 0x0002DF70 File Offset: 0x0002C170
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public DFA() : this(new global::Antlr.Runtime.SpecialStateTransitionHandler(global::Antlr.Runtime.DFA.SpecialStateTransitionDefault))
		{
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x0002DF84 File Offset: 0x0002C184
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public DFA(global::Antlr.Runtime.SpecialStateTransitionHandler specialStateTransition)
		{
			this.SpecialStateTransition = (specialStateTransition ?? new global::Antlr.Runtime.SpecialStateTransitionHandler(global::Antlr.Runtime.DFA.SpecialStateTransitionDefault));
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600074D RID: 1869 RVA: 0x0002DFA8 File Offset: 0x0002C1A8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string Description
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return "n/a";
			}
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x0002DFB0 File Offset: 0x0002C1B0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Predict(global::Antlr.Runtime.IIntStream input)
		{
			if (this.debug)
			{
				global::System.Console.Error.WriteLine("Enter DFA.predict for decision " + this.decisionNumber);
			}
			int marker = input.Mark();
			int num = 0;
			int result;
			try
			{
				char c;
				for (;;)
				{
					if (this.debug)
					{
						global::System.Console.Error.WriteLine(string.Concat(new object[]
						{
							"DFA ",
							this.decisionNumber,
							" state ",
							num,
							" LA(1)=",
							(char)input.LA(1),
							"(",
							input.LA(1),
							"), index=",
							input.Index
						}));
					}
					int num2 = (int)this.special[num];
					if (num2 >= 0)
					{
						if (this.debug)
						{
							global::System.Console.Error.WriteLine(string.Concat(new object[]
							{
								"DFA ",
								this.decisionNumber,
								" state ",
								num,
								" is special state ",
								num2
							}));
						}
						num = this.SpecialStateTransition(this, num2, input);
						if (this.debug)
						{
							global::System.Console.Error.WriteLine(string.Concat(new object[]
							{
								"DFA ",
								this.decisionNumber,
								" returns from special state ",
								num2,
								" to ",
								num
							}));
						}
						if (num == -1)
						{
							break;
						}
						input.Consume();
					}
					else
					{
						if (this.accept[num] >= 1)
						{
							goto Block_8;
						}
						c = (char)input.LA(1);
						if (c >= this.min[num] && c <= this.max[num])
						{
							int num3 = (int)this.transition[num][(int)(c - this.min[num])];
							if (num3 < 0)
							{
								if (this.eot[num] < 0)
								{
									goto IL_2BC;
								}
								if (this.debug)
								{
									global::System.Console.Error.WriteLine("EOT transition");
								}
								num = (int)this.eot[num];
								input.Consume();
							}
							else
							{
								num = num3;
								input.Consume();
							}
						}
						else
						{
							if (this.eot[num] < 0)
							{
								goto IL_316;
							}
							if (this.debug)
							{
								global::System.Console.Error.WriteLine("EOT transition");
							}
							num = (int)this.eot[num];
							input.Consume();
						}
					}
				}
				this.NoViableAlt(num, input);
				return 0;
				Block_8:
				if (this.debug)
				{
					global::System.Console.Error.WriteLine(string.Concat(new object[]
					{
						"accept; predict ",
						this.accept[num],
						" from state ",
						num
					}));
				}
				return (int)this.accept[num];
				IL_2BC:
				this.NoViableAlt(num, input);
				return 0;
				IL_316:
				if (c == '￿' && this.eof[num] >= 0)
				{
					if (this.debug)
					{
						global::System.Console.Error.WriteLine(string.Concat(new object[]
						{
							"accept via EOF; predict ",
							this.accept[(int)this.eof[num]],
							" from ",
							this.eof[num]
						}));
					}
					result = (int)this.accept[(int)this.eof[num]];
				}
				else
				{
					if (this.debug)
					{
						global::System.Console.Error.WriteLine(string.Concat(new object[]
						{
							"min[",
							num,
							"]=",
							this.min[num]
						}));
						global::System.Console.Error.WriteLine(string.Concat(new object[]
						{
							"max[",
							num,
							"]=",
							this.max[num]
						}));
						global::System.Console.Error.WriteLine(string.Concat(new object[]
						{
							"eot[",
							num,
							"]=",
							this.eot[num]
						}));
						global::System.Console.Error.WriteLine(string.Concat(new object[]
						{
							"eof[",
							num,
							"]=",
							this.eof[num]
						}));
						for (int i = 0; i < this.transition[num].Length; i++)
						{
							global::System.Console.Error.Write(this.transition[num][i] + " ");
						}
						global::System.Console.Error.WriteLine();
					}
					this.NoViableAlt(num, input);
					result = 0;
				}
			}
			finally
			{
				input.Rewind(marker);
			}
			return result;
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x0002E510 File Offset: 0x0002C710
		protected virtual void NoViableAlt(int s, global::Antlr.Runtime.IIntStream input)
		{
			if (this.recognizer.state.backtracking > 0)
			{
				this.recognizer.state.failed = true;
				return;
			}
			global::Antlr.Runtime.NoViableAltException ex = new global::Antlr.Runtime.NoViableAltException(this.Description, this.decisionNumber, s, input);
			this.Error(ex);
			throw ex;
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x0002E568 File Offset: 0x0002C768
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Error(global::Antlr.Runtime.NoViableAltException nvae)
		{
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000751 RID: 1873 RVA: 0x0002E56C File Offset: 0x0002C76C
		// (set) Token: 0x06000752 RID: 1874 RVA: 0x0002E574 File Offset: 0x0002C774
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.SpecialStateTransitionHandler SpecialStateTransition
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.<SpecialStateTransition>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<SpecialStateTransition>k__BackingField = value;
			}
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x0002E580 File Offset: 0x0002C780
		private static int SpecialStateTransitionDefault(global::Antlr.Runtime.DFA dfa, int s, global::Antlr.Runtime.IIntStream input)
		{
			return -1;
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x0002E584 File Offset: 0x0002C784
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public static short[] UnpackEncodedString(string encodedString)
		{
			int num = 0;
			for (int i = 0; i < encodedString.Length; i += 2)
			{
				num += (int)encodedString[i];
			}
			short[] array = new short[num];
			int num2 = 0;
			for (int j = 0; j < encodedString.Length; j += 2)
			{
				char c = encodedString[j];
				char c2 = encodedString[j + 1];
				for (int k = 1; k <= (int)c; k++)
				{
					array[num2++] = (short)c2;
				}
			}
			return array;
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x0002E60C File Offset: 0x0002C80C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public static char[] UnpackEncodedStringToUnsignedChars(string encodedString)
		{
			int num = 0;
			for (int i = 0; i < encodedString.Length; i += 2)
			{
				num += (int)encodedString[i];
			}
			char[] array = new char[num];
			int num2 = 0;
			for (int j = 0; j < encodedString.Length; j += 2)
			{
				char c = encodedString[j];
				char c2 = encodedString[j + 1];
				for (int k = 1; k <= (int)c; k++)
				{
					array[num2++] = c2;
				}
			}
			return array;
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x0002E694 File Offset: 0x0002C894
		[global::System.Diagnostics.Conditional("ANTLR_DEBUG")]
		protected virtual void DebugRecognitionException(global::Antlr.Runtime.RecognitionException ex)
		{
			global::Antlr.Runtime.Debug.IDebugEventListener debugListener = this.recognizer.DebugListener;
			if (debugListener != null)
			{
				debugListener.RecognitionException(ex);
			}
		}

		// Token: 0x04000373 RID: 883
		protected short[] eot;

		// Token: 0x04000374 RID: 884
		protected short[] eof;

		// Token: 0x04000375 RID: 885
		protected char[] min;

		// Token: 0x04000376 RID: 886
		protected char[] max;

		// Token: 0x04000377 RID: 887
		protected short[] accept;

		// Token: 0x04000378 RID: 888
		protected short[] special;

		// Token: 0x04000379 RID: 889
		protected short[][] transition;

		// Token: 0x0400037A RID: 890
		protected int decisionNumber;

		// Token: 0x0400037B RID: 891
		protected global::Antlr.Runtime.BaseRecognizer recognizer;

		// Token: 0x0400037C RID: 892
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public readonly bool debug;

		// Token: 0x0400037D RID: 893
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Antlr.Runtime.SpecialStateTransitionHandler <SpecialStateTransition>k__BackingField;
	}
}
