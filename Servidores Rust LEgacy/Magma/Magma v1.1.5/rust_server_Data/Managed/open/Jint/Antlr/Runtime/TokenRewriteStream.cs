using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Antlr.Runtime
{
	// Token: 0x020000BB RID: 187
	[global::System.Diagnostics.DebuggerDisplay("TODO: TokenRewriteStream debugger display")]
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class TokenRewriteStream : global::Antlr.Runtime.CommonTokenStream
	{
		// Token: 0x0600084C RID: 2124 RVA: 0x00030DAC File Offset: 0x0002EFAC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TokenRewriteStream()
		{
			this.Init();
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x00030DBC File Offset: 0x0002EFBC
		protected void Init()
		{
			this.programs = new global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation>>();
			this.programs["default"] = new global::System.Collections.Generic.List<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation>(0x64);
			this.lastRewriteTokenIndexes = new global::System.Collections.Generic.Dictionary<string, int>();
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x00030DEC File Offset: 0x0002EFEC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TokenRewriteStream(global::Antlr.Runtime.ITokenSource tokenSource) : base(tokenSource)
		{
			this.Init();
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x00030DFC File Offset: 0x0002EFFC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TokenRewriteStream(global::Antlr.Runtime.ITokenSource tokenSource, int channel) : base(tokenSource, channel)
		{
			this.Init();
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x00030E0C File Offset: 0x0002F00C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Rollback(int instructionIndex)
		{
			this.Rollback("default", instructionIndex);
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x00030E1C File Offset: 0x0002F01C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Rollback(string programName, int instructionIndex)
		{
			global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> list;
			if (this.programs.TryGetValue(programName, out list) && list != null)
			{
				global::System.Collections.Generic.List<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> list2 = new global::System.Collections.Generic.List<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation>();
				for (int i = 0; i <= instructionIndex; i++)
				{
					list2.Add(list[i]);
				}
				this.programs[programName] = list2;
			}
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x00030E78 File Offset: 0x0002F078
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void DeleteProgram()
		{
			this.DeleteProgram("default");
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x00030E88 File Offset: 0x0002F088
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void DeleteProgram(string programName)
		{
			this.Rollback(programName, 0);
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x00030E94 File Offset: 0x0002F094
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void InsertAfter(global::Antlr.Runtime.IToken t, object text)
		{
			this.InsertAfter("default", t, text);
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x00030EA4 File Offset: 0x0002F0A4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void InsertAfter(int index, object text)
		{
			this.InsertAfter("default", index, text);
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x00030EB4 File Offset: 0x0002F0B4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void InsertAfter(string programName, global::Antlr.Runtime.IToken t, object text)
		{
			this.InsertAfter(programName, t.TokenIndex, text);
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x00030EC4 File Offset: 0x0002F0C4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void InsertAfter(string programName, int index, object text)
		{
			this.InsertBefore(programName, index + 1, text);
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x00030ED4 File Offset: 0x0002F0D4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void InsertBefore(global::Antlr.Runtime.IToken t, object text)
		{
			this.InsertBefore("default", t, text);
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x00030EE4 File Offset: 0x0002F0E4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void InsertBefore(int index, object text)
		{
			this.InsertBefore("default", index, text);
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x00030EF4 File Offset: 0x0002F0F4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void InsertBefore(string programName, global::Antlr.Runtime.IToken t, object text)
		{
			this.InsertBefore(programName, t.TokenIndex, text);
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x00030F04 File Offset: 0x0002F104
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void InsertBefore(string programName, int index, object text)
		{
			global::Antlr.Runtime.TokenRewriteStream.RewriteOperation rewriteOperation = new global::Antlr.Runtime.TokenRewriteStream.InsertBeforeOp(this, index, text);
			global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> program = this.GetProgram(programName);
			rewriteOperation.instructionIndex = program.Count;
			program.Add(rewriteOperation);
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x00030F3C File Offset: 0x0002F13C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Replace(int index, object text)
		{
			this.Replace("default", index, index, text);
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x00030F4C File Offset: 0x0002F14C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Replace(int from, int to, object text)
		{
			this.Replace("default", from, to, text);
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x00030F5C File Offset: 0x0002F15C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Replace(global::Antlr.Runtime.IToken indexT, object text)
		{
			this.Replace("default", indexT, indexT, text);
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x00030F6C File Offset: 0x0002F16C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Replace(global::Antlr.Runtime.IToken from, global::Antlr.Runtime.IToken to, object text)
		{
			this.Replace("default", from, to, text);
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x00030F7C File Offset: 0x0002F17C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Replace(string programName, int from, int to, object text)
		{
			if (from > to || from < 0 || to < 0 || to >= this._tokens.Count)
			{
				throw new global::System.ArgumentException(string.Concat(new object[]
				{
					"replace: range invalid: ",
					from,
					"..",
					to,
					"(size=",
					this._tokens.Count,
					")"
				}));
			}
			global::Antlr.Runtime.TokenRewriteStream.RewriteOperation rewriteOperation = new global::Antlr.Runtime.TokenRewriteStream.ReplaceOp(this, from, to, text);
			global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> program = this.GetProgram(programName);
			rewriteOperation.instructionIndex = program.Count;
			program.Add(rewriteOperation);
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x00031034 File Offset: 0x0002F234
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Replace(string programName, global::Antlr.Runtime.IToken from, global::Antlr.Runtime.IToken to, object text)
		{
			this.Replace(programName, from.TokenIndex, to.TokenIndex, text);
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x0003105C File Offset: 0x0002F25C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Delete(int index)
		{
			this.Delete("default", index, index);
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0003106C File Offset: 0x0002F26C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Delete(int from, int to)
		{
			this.Delete("default", from, to);
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x0003107C File Offset: 0x0002F27C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Delete(global::Antlr.Runtime.IToken indexT)
		{
			this.Delete("default", indexT, indexT);
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x0003108C File Offset: 0x0002F28C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Delete(global::Antlr.Runtime.IToken from, global::Antlr.Runtime.IToken to)
		{
			this.Delete("default", from, to);
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x0003109C File Offset: 0x0002F29C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Delete(string programName, int from, int to)
		{
			this.Replace(programName, from, to, null);
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x000310A8 File Offset: 0x0002F2A8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Delete(string programName, global::Antlr.Runtime.IToken from, global::Antlr.Runtime.IToken to)
		{
			this.Replace(programName, from, to, null);
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x000310B4 File Offset: 0x0002F2B4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int GetLastRewriteTokenIndex()
		{
			return this.GetLastRewriteTokenIndex("default");
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x000310C4 File Offset: 0x0002F2C4
		protected virtual int GetLastRewriteTokenIndex(string programName)
		{
			int result;
			if (this.lastRewriteTokenIndexes.TryGetValue(programName, out result))
			{
				return result;
			}
			return -1;
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x000310EC File Offset: 0x0002F2EC
		protected virtual void SetLastRewriteTokenIndex(string programName, int i)
		{
			this.lastRewriteTokenIndexes[programName] = i;
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x000310FC File Offset: 0x0002F2FC
		protected virtual global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> GetProgram(string name)
		{
			global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> list;
			if (!this.programs.TryGetValue(name, out list) || list == null)
			{
				list = this.InitializeProgram(name);
			}
			return list;
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x00031130 File Offset: 0x0002F330
		private global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> InitializeProgram(string name)
		{
			global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> list = new global::System.Collections.Generic.List<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation>(0x64);
			this.programs[name] = list;
			return list;
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x00031158 File Offset: 0x0002F358
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToOriginalString()
		{
			this.Fill();
			return this.ToOriginalString(0, this.Count - 1);
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x00031180 File Offset: 0x0002F380
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToOriginalString(int start, int end)
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			int num = start;
			while (num >= 0 && num <= end && num < this._tokens.Count)
			{
				if (this.Get(num).Type != -1)
				{
					stringBuilder.Append(this.Get(num).Text);
				}
				num++;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x000311EC File Offset: 0x0002F3EC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			this.Fill();
			return this.ToString(0, this.Count - 1);
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x00031214 File Offset: 0x0002F414
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToString(string programName)
		{
			this.Fill();
			return this.ToString(programName, 0, this.Count - 1);
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x0003123C File Offset: 0x0002F43C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString(int start, int end)
		{
			return this.ToString("default", start, end);
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x0003124C File Offset: 0x0002F44C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToString(string programName, int start, int end)
		{
			global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> list;
			if (!this.programs.TryGetValue(programName, out list))
			{
				list = null;
			}
			if (end > this._tokens.Count - 1)
			{
				end = this._tokens.Count - 1;
			}
			if (start < 0)
			{
				start = 0;
			}
			if (list == null || list.Count == 0)
			{
				return this.ToOriginalString(start, end);
			}
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			global::System.Collections.Generic.IDictionary<int, global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> dictionary = this.ReduceToSingleOperationPerIndex(list);
			int num = start;
			while (num <= end && num < this._tokens.Count)
			{
				global::Antlr.Runtime.TokenRewriteStream.RewriteOperation rewriteOperation;
				bool flag = dictionary.TryGetValue(num, out rewriteOperation);
				if (flag)
				{
					dictionary.Remove(num);
				}
				if (!flag || rewriteOperation == null)
				{
					global::Antlr.Runtime.IToken token = this._tokens[num];
					if (token.Type != -1)
					{
						stringBuilder.Append(token.Text);
					}
					num++;
				}
				else
				{
					num = rewriteOperation.Execute(stringBuilder);
				}
			}
			if (end == this._tokens.Count - 1)
			{
				foreach (global::Antlr.Runtime.TokenRewriteStream.RewriteOperation rewriteOperation2 in dictionary.Values)
				{
					if (rewriteOperation2.index >= this._tokens.Count - 1)
					{
						stringBuilder.Append(rewriteOperation2.text);
					}
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x000313CC File Offset: 0x0002F5CC
		protected virtual global::System.Collections.Generic.IDictionary<int, global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> ReduceToSingleOperationPerIndex(global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> rewrites)
		{
			for (int i = 0; i < rewrites.Count; i++)
			{
				global::Antlr.Runtime.TokenRewriteStream.RewriteOperation rewriteOperation = rewrites[i];
				if (rewriteOperation != null && rewriteOperation is global::Antlr.Runtime.TokenRewriteStream.ReplaceOp)
				{
					global::Antlr.Runtime.TokenRewriteStream.ReplaceOp replaceOp = (global::Antlr.Runtime.TokenRewriteStream.ReplaceOp)rewrites[i];
					global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> kindOfOps = this.GetKindOfOps(rewrites, typeof(global::Antlr.Runtime.TokenRewriteStream.InsertBeforeOp), i);
					for (int j = 0; j < kindOfOps.Count; j++)
					{
						global::Antlr.Runtime.TokenRewriteStream.InsertBeforeOp insertBeforeOp = (global::Antlr.Runtime.TokenRewriteStream.InsertBeforeOp)kindOfOps[j];
						if (insertBeforeOp.index == replaceOp.index)
						{
							rewrites[insertBeforeOp.instructionIndex] = null;
							replaceOp.text = insertBeforeOp.text.ToString() + ((replaceOp.text != null) ? replaceOp.text.ToString() : string.Empty);
						}
						else if (insertBeforeOp.index > replaceOp.index && insertBeforeOp.index <= replaceOp.lastIndex)
						{
							rewrites[insertBeforeOp.instructionIndex] = null;
						}
					}
					global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> kindOfOps2 = this.GetKindOfOps(rewrites, typeof(global::Antlr.Runtime.TokenRewriteStream.ReplaceOp), i);
					for (int k = 0; k < kindOfOps2.Count; k++)
					{
						global::Antlr.Runtime.TokenRewriteStream.ReplaceOp replaceOp2 = (global::Antlr.Runtime.TokenRewriteStream.ReplaceOp)kindOfOps2[k];
						if (replaceOp2.index >= replaceOp.index && replaceOp2.lastIndex <= replaceOp.lastIndex)
						{
							rewrites[replaceOp2.instructionIndex] = null;
						}
						else
						{
							bool flag = replaceOp2.lastIndex < replaceOp.index || replaceOp2.index > replaceOp.lastIndex;
							bool flag2 = replaceOp2.index == replaceOp.index && replaceOp2.lastIndex == replaceOp.lastIndex;
							if (replaceOp2.text == null && replaceOp.text == null && !flag)
							{
								rewrites[replaceOp2.instructionIndex] = null;
								replaceOp.index = global::System.Math.Min(replaceOp2.index, replaceOp.index);
								replaceOp.lastIndex = global::System.Math.Max(replaceOp2.lastIndex, replaceOp.lastIndex);
								global::System.Console.WriteLine("new rop " + replaceOp);
							}
							else if (!flag && !flag2)
							{
								throw new global::System.ArgumentException(string.Concat(new object[]
								{
									"replace op boundaries of ",
									replaceOp,
									" overlap with previous ",
									replaceOp2
								}));
							}
						}
					}
				}
			}
			for (int l = 0; l < rewrites.Count; l++)
			{
				global::Antlr.Runtime.TokenRewriteStream.RewriteOperation rewriteOperation2 = rewrites[l];
				if (rewriteOperation2 != null && rewriteOperation2 is global::Antlr.Runtime.TokenRewriteStream.InsertBeforeOp)
				{
					global::Antlr.Runtime.TokenRewriteStream.InsertBeforeOp insertBeforeOp2 = (global::Antlr.Runtime.TokenRewriteStream.InsertBeforeOp)rewrites[l];
					global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> kindOfOps3 = this.GetKindOfOps(rewrites, typeof(global::Antlr.Runtime.TokenRewriteStream.InsertBeforeOp), l);
					for (int m = 0; m < kindOfOps3.Count; m++)
					{
						global::Antlr.Runtime.TokenRewriteStream.InsertBeforeOp insertBeforeOp3 = (global::Antlr.Runtime.TokenRewriteStream.InsertBeforeOp)kindOfOps3[m];
						if (insertBeforeOp3.index == insertBeforeOp2.index)
						{
							insertBeforeOp2.text = this.CatOpText(insertBeforeOp2.text, insertBeforeOp3.text);
							rewrites[insertBeforeOp3.instructionIndex] = null;
						}
					}
					global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> kindOfOps4 = this.GetKindOfOps(rewrites, typeof(global::Antlr.Runtime.TokenRewriteStream.ReplaceOp), l);
					for (int n = 0; n < kindOfOps4.Count; n++)
					{
						global::Antlr.Runtime.TokenRewriteStream.ReplaceOp replaceOp3 = (global::Antlr.Runtime.TokenRewriteStream.ReplaceOp)kindOfOps4[n];
						if (insertBeforeOp2.index == replaceOp3.index)
						{
							replaceOp3.text = this.CatOpText(insertBeforeOp2.text, replaceOp3.text);
							rewrites[l] = null;
						}
						else if (insertBeforeOp2.index >= replaceOp3.index && insertBeforeOp2.index <= replaceOp3.lastIndex)
						{
							throw new global::System.ArgumentException(string.Concat(new object[]
							{
								"insert op ",
								insertBeforeOp2,
								" within boundaries of previous ",
								replaceOp3
							}));
						}
					}
				}
			}
			global::System.Collections.Generic.IDictionary<int, global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> dictionary = new global::System.Collections.Generic.Dictionary<int, global::Antlr.Runtime.TokenRewriteStream.RewriteOperation>();
			for (int num = 0; num < rewrites.Count; num++)
			{
				global::Antlr.Runtime.TokenRewriteStream.RewriteOperation rewriteOperation3 = rewrites[num];
				if (rewriteOperation3 != null)
				{
					global::Antlr.Runtime.TokenRewriteStream.RewriteOperation rewriteOperation4;
					if (dictionary.TryGetValue(rewriteOperation3.index, out rewriteOperation4) && rewriteOperation4 != null)
					{
						throw new global::System.Exception("should only be one op per index");
					}
					dictionary[rewriteOperation3.index] = rewriteOperation3;
				}
			}
			return dictionary;
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x00031860 File Offset: 0x0002FA60
		protected virtual string CatOpText(object a, object b)
		{
			return a + b;
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x0003186C File Offset: 0x0002FA6C
		protected virtual global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> GetKindOfOps(global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> rewrites, global::System.Type kind)
		{
			return this.GetKindOfOps(rewrites, kind, rewrites.Count);
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x0003187C File Offset: 0x0002FA7C
		protected virtual global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> GetKindOfOps(global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> rewrites, global::System.Type kind, int before)
		{
			global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation> list = new global::System.Collections.Generic.List<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation>();
			int num = 0;
			while (num < before && num < rewrites.Count)
			{
				global::Antlr.Runtime.TokenRewriteStream.RewriteOperation rewriteOperation = rewrites[num];
				if (rewriteOperation != null && rewriteOperation.GetType() == kind)
				{
					list.Add(rewriteOperation);
				}
				num++;
			}
			return list;
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x000318D0 File Offset: 0x0002FAD0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToDebugString()
		{
			return this.ToDebugString(0, this.Count - 1);
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x000318E4 File Offset: 0x0002FAE4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string ToDebugString(int start, int end)
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			int num = start;
			while (num >= 0 && num <= end && num < this._tokens.Count)
			{
				stringBuilder.Append(this.Get(num));
				num++;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x040003C6 RID: 966
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const string DEFAULT_PROGRAM_NAME = "default";

		// Token: 0x040003C7 RID: 967
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int PROGRAM_INIT_SIZE = 0x64;

		// Token: 0x040003C8 RID: 968
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public const int MIN_TOKEN_INDEX = 0;

		// Token: 0x040003C9 RID: 969
		protected global::System.Collections.Generic.IDictionary<string, global::System.Collections.Generic.IList<global::Antlr.Runtime.TokenRewriteStream.RewriteOperation>> programs;

		// Token: 0x040003CA RID: 970
		protected global::System.Collections.Generic.IDictionary<string, int> lastRewriteTokenIndexes;

		// Token: 0x02000159 RID: 345
		protected class RewriteOperation
		{
			// Token: 0x06000C10 RID: 3088 RVA: 0x0003CA20 File Offset: 0x0003AC20
			protected RewriteOperation(global::Antlr.Runtime.TokenRewriteStream stream, int index)
			{
				this.stream = stream;
				this.index = index;
			}

			// Token: 0x06000C11 RID: 3089 RVA: 0x0003CA38 File Offset: 0x0003AC38
			protected RewriteOperation(global::Antlr.Runtime.TokenRewriteStream stream, int index, object text)
			{
				this.index = index;
				this.text = text;
				this.stream = stream;
			}

			// Token: 0x06000C12 RID: 3090 RVA: 0x0003CA58 File Offset: 0x0003AC58
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public virtual int Execute(global::System.Text.StringBuilder buf)
			{
				return this.index;
			}

			// Token: 0x06000C13 RID: 3091 RVA: 0x0003CA60 File Offset: 0x0003AC60
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public override string ToString()
			{
				string text = base.GetType().Name;
				int num = text.IndexOf('$');
				text = text.Substring(num + 1);
				return string.Format("<{0}@{1}:\"{2}\">", text, this.stream._tokens[this.index], this.text);
			}

			// Token: 0x040006E4 RID: 1764
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public int instructionIndex;

			// Token: 0x040006E5 RID: 1765
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public int index;

			// Token: 0x040006E6 RID: 1766
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public object text;

			// Token: 0x040006E7 RID: 1767
			protected global::Antlr.Runtime.TokenRewriteStream stream;
		}

		// Token: 0x0200015A RID: 346
		private class InsertBeforeOp : global::Antlr.Runtime.TokenRewriteStream.RewriteOperation
		{
			// Token: 0x06000C14 RID: 3092 RVA: 0x0003CAB8 File Offset: 0x0003ACB8
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public InsertBeforeOp(global::Antlr.Runtime.TokenRewriteStream stream, int index, object text) : base(stream, index, text)
			{
			}

			// Token: 0x06000C15 RID: 3093 RVA: 0x0003CAC4 File Offset: 0x0003ACC4
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public override int Execute(global::System.Text.StringBuilder buf)
			{
				buf.Append(this.text);
				if (this.stream._tokens[this.index].Type != -1)
				{
					buf.Append(this.stream._tokens[this.index].Text);
				}
				return this.index + 1;
			}
		}

		// Token: 0x0200015B RID: 347
		private class ReplaceOp : global::Antlr.Runtime.TokenRewriteStream.RewriteOperation
		{
			// Token: 0x06000C16 RID: 3094 RVA: 0x0003CB30 File Offset: 0x0003AD30
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public ReplaceOp(global::Antlr.Runtime.TokenRewriteStream stream, int from, int to, object text) : base(stream, from, text)
			{
				this.lastIndex = to;
			}

			// Token: 0x06000C17 RID: 3095 RVA: 0x0003CB44 File Offset: 0x0003AD44
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public override int Execute(global::System.Text.StringBuilder buf)
			{
				if (this.text != null)
				{
					buf.Append(this.text);
				}
				return this.lastIndex + 1;
			}

			// Token: 0x06000C18 RID: 3096 RVA: 0x0003CB68 File Offset: 0x0003AD68
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public override string ToString()
			{
				if (this.text == null)
				{
					return string.Format("<DeleteOp@{0}..{1}>", this.stream._tokens[this.index], this.stream._tokens[this.lastIndex]);
				}
				return string.Format("<ReplaceOp@{0}..{1}:\"{2}\">", this.stream._tokens[this.index], this.stream._tokens[this.lastIndex], this.text);
			}

			// Token: 0x040006E8 RID: 1768
			[global::System.Runtime.InteropServices.ComVisible(false)]
			public int lastIndex;
		}
	}
}
