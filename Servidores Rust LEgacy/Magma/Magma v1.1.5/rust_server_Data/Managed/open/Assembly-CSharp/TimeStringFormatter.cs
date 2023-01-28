using System;

// Token: 0x02000206 RID: 518
public struct TimeStringFormatter
{
	// Token: 0x06000E56 RID: 3670 RVA: 0x00036EB4 File Offset: 0x000350B4
	private TimeStringFormatter(string aDay, string days, string aHour, string hours, string aMinute, string minutes, string aSecond, string seconds, string lessThanASecond)
	{
		this.aDay = aDay;
		this.days = days;
		this.aHour = aHour;
		this.hours = hours;
		this.aMinute = aMinute;
		this.minutes = minutes;
		this.aSecond = aSecond;
		this.seconds = seconds;
		this.lessThanASecond = lessThanASecond;
	}

	// Token: 0x06000E57 RID: 3671 RVA: 0x00036F08 File Offset: 0x00035108
	private static string DoMerge(string value)
	{
		return value.Replace("{", "{{").Replace("}", "}}").Replace("<ꪻ뮪>", "{0}");
	}

	// Token: 0x06000E58 RID: 3672 RVA: 0x00036F44 File Offset: 0x00035144
	private static string Merge(string prefix)
	{
		return global::TimeStringFormatter.DoMerge(prefix ?? string.Empty);
	}

	// Token: 0x06000E59 RID: 3673 RVA: 0x00036F58 File Offset: 0x00035158
	private static string Merge(string prefix, string qualifier)
	{
		return global::TimeStringFormatter.DoMerge((prefix ?? string.Empty) + (qualifier ?? string.Empty));
	}

	// Token: 0x06000E5A RID: 3674 RVA: 0x00036F8C File Offset: 0x0003518C
	private static string Merge(string prefix, string qualifier, string suffix)
	{
		return global::TimeStringFormatter.DoMerge((prefix ?? string.Empty) + (qualifier ?? string.Empty) + (suffix ?? string.Empty));
	}

	// Token: 0x06000E5B RID: 3675 RVA: 0x00036FC0 File Offset: 0x000351C0
	public static global::TimeStringFormatter Define(global::TimeStringFormatter.Qualifier qualifier)
	{
		return new global::TimeStringFormatter(global::TimeStringFormatter.Merge(qualifier.aDay), global::TimeStringFormatter.Merge(qualifier.days), global::TimeStringFormatter.Merge(qualifier.aHour), global::TimeStringFormatter.Merge(qualifier.hours), global::TimeStringFormatter.Merge(qualifier.aMinute), global::TimeStringFormatter.Merge(qualifier.minutes), global::TimeStringFormatter.Merge(qualifier.aSecond), global::TimeStringFormatter.Merge(qualifier.seconds), global::TimeStringFormatter.Merge(qualifier.lessThanASecond));
	}

	// Token: 0x06000E5C RID: 3676 RVA: 0x00037040 File Offset: 0x00035240
	public static global::TimeStringFormatter Define(string prefix, global::TimeStringFormatter.Qualifier qualifier)
	{
		if (string.IsNullOrEmpty(prefix))
		{
			return global::TimeStringFormatter.Define(qualifier);
		}
		return new global::TimeStringFormatter(global::TimeStringFormatter.Merge(prefix, qualifier.aDay), global::TimeStringFormatter.Merge(prefix, qualifier.days), global::TimeStringFormatter.Merge(prefix, qualifier.aHour), global::TimeStringFormatter.Merge(prefix, qualifier.hours), global::TimeStringFormatter.Merge(prefix, qualifier.aMinute), global::TimeStringFormatter.Merge(prefix, qualifier.minutes), global::TimeStringFormatter.Merge(prefix, qualifier.aSecond), global::TimeStringFormatter.Merge(prefix, qualifier.seconds), global::TimeStringFormatter.Merge(prefix, qualifier.lessThanASecond));
	}

	// Token: 0x06000E5D RID: 3677 RVA: 0x000370DC File Offset: 0x000352DC
	public static global::TimeStringFormatter Define(global::TimeStringFormatter.Qualifier qualifier, string suffix)
	{
		if (string.IsNullOrEmpty(suffix))
		{
			return global::TimeStringFormatter.Define(qualifier);
		}
		return new global::TimeStringFormatter(global::TimeStringFormatter.Merge(qualifier.aDay, suffix), global::TimeStringFormatter.Merge(qualifier.days, suffix), global::TimeStringFormatter.Merge(qualifier.aHour, suffix), global::TimeStringFormatter.Merge(qualifier.hours, suffix), global::TimeStringFormatter.Merge(qualifier.aMinute, suffix), global::TimeStringFormatter.Merge(qualifier.minutes, suffix), global::TimeStringFormatter.Merge(qualifier.aSecond, suffix), global::TimeStringFormatter.Merge(qualifier.seconds, suffix), global::TimeStringFormatter.Merge(qualifier.lessThanASecond, suffix));
	}

	// Token: 0x06000E5E RID: 3678 RVA: 0x00037178 File Offset: 0x00035378
	public static global::TimeStringFormatter Define(string prefix, global::TimeStringFormatter.Qualifier qualifier, string suffix)
	{
		if (string.IsNullOrEmpty(suffix))
		{
			if (string.IsNullOrEmpty(prefix))
			{
				return global::TimeStringFormatter.Define(qualifier);
			}
			return global::TimeStringFormatter.Define(prefix, qualifier);
		}
		else
		{
			if (string.IsNullOrEmpty(prefix))
			{
				return global::TimeStringFormatter.Define(qualifier, suffix);
			}
			return new global::TimeStringFormatter(global::TimeStringFormatter.Merge(prefix, qualifier.aDay, suffix), global::TimeStringFormatter.Merge(prefix, qualifier.days, suffix), global::TimeStringFormatter.Merge(prefix, qualifier.aHour, suffix), global::TimeStringFormatter.Merge(prefix, qualifier.hours, suffix), global::TimeStringFormatter.Merge(prefix, qualifier.aMinute, suffix), global::TimeStringFormatter.Merge(prefix, qualifier.minutes, suffix), global::TimeStringFormatter.Merge(prefix, qualifier.aSecond, suffix), global::TimeStringFormatter.Merge(prefix, qualifier.seconds, suffix), global::TimeStringFormatter.Merge(prefix, qualifier.lessThanASecond, suffix));
		}
	}

	// Token: 0x06000E5F RID: 3679 RVA: 0x00037240 File Offset: 0x00035440
	public static global::TimeStringFormatter Define(global::TimeStringFormatter formatter, string lessThanASecond)
	{
		if (!object.ReferenceEquals(lessThanASecond, null))
		{
			formatter = new global::TimeStringFormatter(formatter.aDay, formatter.days, formatter.aHour, formatter.hours, formatter.aMinute, formatter.minutes, formatter.aSecond, formatter.seconds, global::TimeStringFormatter.Merge(lessThanASecond));
		}
		return formatter;
	}

	// Token: 0x06000E60 RID: 3680 RVA: 0x000372A0 File Offset: 0x000354A0
	public static global::TimeStringFormatter Define(string prefix, global::TimeStringFormatter.Qualifier qualifier, string suffix, string lessThanASecond)
	{
		return global::TimeStringFormatter.Define(global::TimeStringFormatter.Define(prefix, qualifier, suffix), lessThanASecond);
	}

	// Token: 0x06000E61 RID: 3681 RVA: 0x000372B0 File Offset: 0x000354B0
	private static double Round(double total, global::TimeStringFormatter.Rounding rounding, int decimalPlaces, double fancyUnits)
	{
		if (total <= 0.0)
		{
			return 0.0;
		}
		switch (rounding)
		{
		case global::TimeStringFormatter.Rounding.Floor:
			return global::System.Math.Floor(total);
		case global::TimeStringFormatter.Rounding.Ceiling:
			return global::System.Math.Ceiling(total);
		case global::TimeStringFormatter.Rounding.Round:
			return global::System.Math.Round(total);
		case global::TimeStringFormatter.Rounding.Decimal:
			fancyUnits = 1.0;
			decimalPlaces = 0;
			break;
		case global::TimeStringFormatter.Rounding.RoundedDecimal:
			fancyUnits = 1.0;
			break;
		case global::TimeStringFormatter.Rounding.FancyDecimal:
			decimalPlaces = 0;
			break;
		}
		if (decimalPlaces == 0)
		{
			return total;
		}
		double num = global::System.Math.Floor(total);
		return num + global::System.Math.Floor((total - num) * fancyUnits * ((double)decimalPlaces * 10.0)) / (10.0 * (double)decimalPlaces);
	}

	// Token: 0x06000E62 RID: 3682 RVA: 0x0003737C File Offset: 0x0003557C
	public string GetFormattingString(global::System.TimeSpan timePassed)
	{
		return this.GetFormattingString(timePassed, global::TimeStringFormatter.Rounding.Floor);
	}

	// Token: 0x06000E63 RID: 3683 RVA: 0x00037388 File Offset: 0x00035588
	public string GetFormattingString(global::System.TimeSpan timePassed, global::TimeStringFormatter.Rounding rounding)
	{
		int num2;
		double num = global::TimeStringFormatter.Round(timePassed.TotalSeconds, rounding, num2 = 2, 1.0);
		string format;
		if (num <= 0.0)
		{
			format = this.lessThanASecond;
		}
		else if (num == 1.0)
		{
			format = this.aSecond;
		}
		else if (num < 60.0)
		{
			format = this.seconds;
		}
		else if ((num = global::TimeStringFormatter.Round(timePassed.TotalMinutes, rounding, num2 = 2, 0.6)) == 1.0)
		{
			format = this.aMinute;
		}
		else if (num < 60.0)
		{
			format = this.minutes;
		}
		else if ((num = global::TimeStringFormatter.Round(timePassed.TotalHours, rounding, num2 = 2, 1.0)) == 1.0)
		{
			format = this.aHour;
		}
		else if (num < 24.0)
		{
			format = this.hours;
		}
		else if ((num = global::TimeStringFormatter.Round(timePassed.TotalDays, rounding, num2 = 2, 0.24)) == 1.0)
		{
			format = this.aDay;
		}
		else
		{
			format = this.days;
		}
		object arg;
		if (rounding == global::TimeStringFormatter.Rounding.RoundedDecimal || rounding == global::TimeStringFormatter.Rounding.FancyDecimal || rounding == global::TimeStringFormatter.Rounding.RoundedFancyDecimal)
		{
			string text;
			if (rounding == global::TimeStringFormatter.Rounding.RoundedDecimal || rounding == global::TimeStringFormatter.Rounding.RoundedFancyDecimal)
			{
				if (num2 != 2)
				{
					throw new global::System.NotSupportedException("We gotta add support for that");
				}
				text = num.ToString("0.00");
			}
			else
			{
				text = num.ToString();
			}
			if (rounding == global::TimeStringFormatter.Rounding.FancyDecimal || rounding == global::TimeStringFormatter.Rounding.RoundedFancyDecimal)
			{
				arg = text.Replace('.', ':');
			}
			else
			{
				arg = text;
			}
		}
		else if (rounding != global::TimeStringFormatter.Rounding.Decimal && !double.IsNaN(num) && !double.IsInfinity(num))
		{
			arg = (int)num;
		}
		else
		{
			arg = num;
		}
		return string.Format(format, arg);
	}

	// Token: 0x040008D4 RID: 2260
	public const string kArgumentTime = "<ꪻ뮪>";

	// Token: 0x040008D5 RID: 2261
	private const string kArgumentTimeReplacement = "{0}";

	// Token: 0x040008D6 RID: 2262
	public const string kPeriod = ".";

	// Token: 0x040008D7 RID: 2263
	public readonly string aDay;

	// Token: 0x040008D8 RID: 2264
	public readonly string days;

	// Token: 0x040008D9 RID: 2265
	public readonly string aHour;

	// Token: 0x040008DA RID: 2266
	public readonly string hours;

	// Token: 0x040008DB RID: 2267
	public readonly string aMinute;

	// Token: 0x040008DC RID: 2268
	public readonly string minutes;

	// Token: 0x040008DD RID: 2269
	public readonly string aSecond;

	// Token: 0x040008DE RID: 2270
	public readonly string seconds;

	// Token: 0x040008DF RID: 2271
	public readonly string lessThanASecond;

	// Token: 0x02000207 RID: 519
	public static class Quantity
	{
		// Token: 0x06000E64 RID: 3684 RVA: 0x0003759C File Offset: 0x0003579C
		// Note: this type is marked as 'beforefieldinit'.
		static Quantity()
		{
		}

		// Token: 0x040008E0 RID: 2272
		public const string kPrefix = " ";

		// Token: 0x040008E1 RID: 2273
		public const string aDay = " a day";

		// Token: 0x040008E2 RID: 2274
		public const string days = " <ꪻ뮪> days";

		// Token: 0x040008E3 RID: 2275
		public const string aHour = " an hour";

		// Token: 0x040008E4 RID: 2276
		public const string hours = " <ꪻ뮪> hours";

		// Token: 0x040008E5 RID: 2277
		public const string aMinute = " a minute";

		// Token: 0x040008E6 RID: 2278
		public const string minutes = " <ꪻ뮪> minutes";

		// Token: 0x040008E7 RID: 2279
		public const string aSecond = " a second";

		// Token: 0x040008E8 RID: 2280
		public const string seconds = " <ꪻ뮪> seconds";

		// Token: 0x040008E9 RID: 2281
		public const string lessThanASecond = "";

		// Token: 0x040008EA RID: 2282
		public static readonly global::TimeStringFormatter.Qualifier Qualifier = new global::TimeStringFormatter.Qualifier(" a day", " <ꪻ뮪> days", " an hour", " <ꪻ뮪> hours", " a minute", " <ꪻ뮪> minutes", " a second", " <ꪻ뮪> seconds", string.Empty);

		// Token: 0x02000208 RID: 520
		public static class Period
		{
			// Token: 0x06000E65 RID: 3685 RVA: 0x000375E0 File Offset: 0x000357E0
			// Note: this type is marked as 'beforefieldinit'.
			static Period()
			{
			}

			// Token: 0x040008EB RID: 2283
			public const string kSuffix = ".";

			// Token: 0x040008EC RID: 2284
			public const string aDay = " a day.";

			// Token: 0x040008ED RID: 2285
			public const string days = " <ꪻ뮪> days.";

			// Token: 0x040008EE RID: 2286
			public const string aHour = " an hour.";

			// Token: 0x040008EF RID: 2287
			public const string hours = " <ꪻ뮪> hours.";

			// Token: 0x040008F0 RID: 2288
			public const string aMinute = " a minute.";

			// Token: 0x040008F1 RID: 2289
			public const string minutes = " <ꪻ뮪> minutes.";

			// Token: 0x040008F2 RID: 2290
			public const string aSecond = " a second.";

			// Token: 0x040008F3 RID: 2291
			public const string seconds = " <ꪻ뮪> seconds.";

			// Token: 0x040008F4 RID: 2292
			public const string lessThanASecond = ".";

			// Token: 0x040008F5 RID: 2293
			public static readonly global::TimeStringFormatter.Qualifier Qualifier = new global::TimeStringFormatter.Qualifier(" a day.", " <ꪻ뮪> days.", " an hour.", " <ꪻ뮪> hours.", " a minute.", " <ꪻ뮪> minutes.", " a second.", " <ꪻ뮪> seconds.", ".");
		}
	}

	// Token: 0x02000209 RID: 521
	public static class For
	{
		// Token: 0x06000E66 RID: 3686 RVA: 0x00037624 File Offset: 0x00035824
		// Note: this type is marked as 'beforefieldinit'.
		static For()
		{
		}

		// Token: 0x040008F6 RID: 2294
		public const string kPrefix = " for";

		// Token: 0x040008F7 RID: 2295
		public const string aDay = " for a day";

		// Token: 0x040008F8 RID: 2296
		public const string days = " for <ꪻ뮪> days";

		// Token: 0x040008F9 RID: 2297
		public const string aHour = " for an hour";

		// Token: 0x040008FA RID: 2298
		public const string hours = " for <ꪻ뮪> hours";

		// Token: 0x040008FB RID: 2299
		public const string aMinute = " for a minute";

		// Token: 0x040008FC RID: 2300
		public const string minutes = " for <ꪻ뮪> minutes";

		// Token: 0x040008FD RID: 2301
		public const string aSecond = " for a second";

		// Token: 0x040008FE RID: 2302
		public const string seconds = " for <ꪻ뮪> seconds";

		// Token: 0x040008FF RID: 2303
		public const string lessThanASecond = "";

		// Token: 0x04000900 RID: 2304
		public static readonly global::TimeStringFormatter.Qualifier Qualifier = new global::TimeStringFormatter.Qualifier(" for a day", " for <ꪻ뮪> days", " for an hour", " for <ꪻ뮪> hours", " for a minute", " for <ꪻ뮪> minutes", " for a second", " for <ꪻ뮪> seconds", string.Empty);

		// Token: 0x0200020A RID: 522
		public static class Period
		{
			// Token: 0x06000E67 RID: 3687 RVA: 0x00037668 File Offset: 0x00035868
			// Note: this type is marked as 'beforefieldinit'.
			static Period()
			{
			}

			// Token: 0x04000901 RID: 2305
			public const string kSuffix = ".";

			// Token: 0x04000902 RID: 2306
			public const string aDay = " for a day.";

			// Token: 0x04000903 RID: 2307
			public const string days = " for <ꪻ뮪> days.";

			// Token: 0x04000904 RID: 2308
			public const string aHour = " for an hour.";

			// Token: 0x04000905 RID: 2309
			public const string hours = " for <ꪻ뮪> hours.";

			// Token: 0x04000906 RID: 2310
			public const string aMinute = " for a minute.";

			// Token: 0x04000907 RID: 2311
			public const string minutes = " for <ꪻ뮪> minutes.";

			// Token: 0x04000908 RID: 2312
			public const string aSecond = " for a second.";

			// Token: 0x04000909 RID: 2313
			public const string seconds = " for <ꪻ뮪> seconds.";

			// Token: 0x0400090A RID: 2314
			public const string lessThanASecond = ".";

			// Token: 0x0400090B RID: 2315
			public static readonly global::TimeStringFormatter.Qualifier Qualifier = new global::TimeStringFormatter.Qualifier(" for a day.", " for <ꪻ뮪> days.", " for an hour.", " for <ꪻ뮪> hours.", " for a minute.", " for <ꪻ뮪> minutes.", " for a second.", " for <ꪻ뮪> seconds.", ".");
		}
	}

	// Token: 0x0200020B RID: 523
	public static class Ago
	{
		// Token: 0x06000E68 RID: 3688 RVA: 0x000376AC File Offset: 0x000358AC
		// Note: this type is marked as 'beforefieldinit'.
		static Ago()
		{
		}

		// Token: 0x0400090C RID: 2316
		public const string kSuffix = " ago";

		// Token: 0x0400090D RID: 2317
		public const string aDay = " a day ago";

		// Token: 0x0400090E RID: 2318
		public const string days = " <ꪻ뮪> days ago";

		// Token: 0x0400090F RID: 2319
		public const string aHour = " an hour ago";

		// Token: 0x04000910 RID: 2320
		public const string hours = " <ꪻ뮪> hours ago";

		// Token: 0x04000911 RID: 2321
		public const string aMinute = " a minute ago";

		// Token: 0x04000912 RID: 2322
		public const string minutes = " <ꪻ뮪> minutes ago";

		// Token: 0x04000913 RID: 2323
		public const string aSecond = " a second ago";

		// Token: 0x04000914 RID: 2324
		public const string seconds = " <ꪻ뮪> seconds ago";

		// Token: 0x04000915 RID: 2325
		public const string lessThanASecond = "";

		// Token: 0x04000916 RID: 2326
		public static readonly global::TimeStringFormatter.Qualifier Qualifier = new global::TimeStringFormatter.Qualifier(" a day ago", " <ꪻ뮪> days ago", " an hour ago", " <ꪻ뮪> hours ago", " a minute ago", " <ꪻ뮪> minutes ago", " a second ago", " <ꪻ뮪> seconds ago", string.Empty);

		// Token: 0x0200020C RID: 524
		public static class Period
		{
			// Token: 0x06000E69 RID: 3689 RVA: 0x000376F0 File Offset: 0x000358F0
			// Note: this type is marked as 'beforefieldinit'.
			static Period()
			{
			}

			// Token: 0x04000917 RID: 2327
			public const string kSuffix = ".";

			// Token: 0x04000918 RID: 2328
			public const string aDay = " a day ago.";

			// Token: 0x04000919 RID: 2329
			public const string days = " <ꪻ뮪> days ago.";

			// Token: 0x0400091A RID: 2330
			public const string aHour = " an hour ago.";

			// Token: 0x0400091B RID: 2331
			public const string hours = " <ꪻ뮪> hours ago.";

			// Token: 0x0400091C RID: 2332
			public const string aMinute = " a minute ago.";

			// Token: 0x0400091D RID: 2333
			public const string minutes = " <ꪻ뮪> minutes ago.";

			// Token: 0x0400091E RID: 2334
			public const string aSecond = " a second ago.";

			// Token: 0x0400091F RID: 2335
			public const string seconds = " <ꪻ뮪> seconds ago.";

			// Token: 0x04000920 RID: 2336
			public const string lessThanASecond = ".";

			// Token: 0x04000921 RID: 2337
			public static readonly global::TimeStringFormatter.Qualifier Qualifier = new global::TimeStringFormatter.Qualifier(" a day ago.", " <ꪻ뮪> days ago.", " an hour ago.", " <ꪻ뮪> hours ago.", " a minute ago.", " <ꪻ뮪> minutes ago.", " a second ago.", " <ꪻ뮪> seconds ago.", ".");
		}
	}

	// Token: 0x0200020D RID: 525
	public static class SinceAgo
	{
		// Token: 0x06000E6A RID: 3690 RVA: 0x00037734 File Offset: 0x00035934
		// Note: this type is marked as 'beforefieldinit'.
		static SinceAgo()
		{
		}

		// Token: 0x04000922 RID: 2338
		public const string kPrefix = " since";

		// Token: 0x04000923 RID: 2339
		public const string aDay = " since a day ago";

		// Token: 0x04000924 RID: 2340
		public const string days = " since <ꪻ뮪> days ago";

		// Token: 0x04000925 RID: 2341
		public const string aHour = " since an hour ago";

		// Token: 0x04000926 RID: 2342
		public const string hours = " since <ꪻ뮪> hours ago";

		// Token: 0x04000927 RID: 2343
		public const string aMinute = " since a minute ago";

		// Token: 0x04000928 RID: 2344
		public const string minutes = " since <ꪻ뮪> minutes ago";

		// Token: 0x04000929 RID: 2345
		public const string aSecond = " since a second ago";

		// Token: 0x0400092A RID: 2346
		public const string seconds = " since <ꪻ뮪> seconds ago";

		// Token: 0x0400092B RID: 2347
		public const string lessThanASecond = "";

		// Token: 0x0400092C RID: 2348
		public static readonly global::TimeStringFormatter.Qualifier Qualifier = new global::TimeStringFormatter.Qualifier(" since a day ago", " since <ꪻ뮪> days ago", " since an hour ago", " since <ꪻ뮪> hours ago", " since a minute ago", " since <ꪻ뮪> minutes ago", " since a second ago", " since <ꪻ뮪> seconds ago", string.Empty);

		// Token: 0x0200020E RID: 526
		public static class Period
		{
			// Token: 0x06000E6B RID: 3691 RVA: 0x00037778 File Offset: 0x00035978
			// Note: this type is marked as 'beforefieldinit'.
			static Period()
			{
			}

			// Token: 0x0400092D RID: 2349
			public const string kSuffix = ".";

			// Token: 0x0400092E RID: 2350
			public const string aDay = " since a day ago.";

			// Token: 0x0400092F RID: 2351
			public const string days = " since <ꪻ뮪> days ago.";

			// Token: 0x04000930 RID: 2352
			public const string aHour = " since an hour ago.";

			// Token: 0x04000931 RID: 2353
			public const string hours = " since <ꪻ뮪> hours ago.";

			// Token: 0x04000932 RID: 2354
			public const string aMinute = " since a minute ago.";

			// Token: 0x04000933 RID: 2355
			public const string minutes = " since <ꪻ뮪> minutes ago.";

			// Token: 0x04000934 RID: 2356
			public const string aSecond = " since a second ago.";

			// Token: 0x04000935 RID: 2357
			public const string seconds = " since <ꪻ뮪> seconds ago.";

			// Token: 0x04000936 RID: 2358
			public const string lessThanASecond = ".";

			// Token: 0x04000937 RID: 2359
			public static readonly global::TimeStringFormatter.Qualifier Qualifier = new global::TimeStringFormatter.Qualifier(" since a day ago.", " since <ꪻ뮪> days ago.", " since an hour ago.", " since <ꪻ뮪> hours ago.", " since a minute ago.", " since <ꪻ뮪> minutes ago.", " since a second ago.", " since <ꪻ뮪> seconds ago.", ".");
		}
	}

	// Token: 0x0200020F RID: 527
	public struct Qualifier
	{
		// Token: 0x06000E6C RID: 3692 RVA: 0x000377BC File Offset: 0x000359BC
		public Qualifier(string aDay, string days, string aHour, string hours, string aMinute, string minutes, string aSecond, string seconds, string lessThanASecond)
		{
			this.aDay = aDay;
			this.days = days;
			this.aHour = aHour;
			this.hours = hours;
			this.aMinute = aMinute;
			this.minutes = minutes;
			this.aSecond = aSecond;
			this.seconds = seconds;
			this.lessThanASecond = lessThanASecond;
		}

		// Token: 0x04000938 RID: 2360
		public readonly string aDay;

		// Token: 0x04000939 RID: 2361
		public readonly string days;

		// Token: 0x0400093A RID: 2362
		public readonly string aHour;

		// Token: 0x0400093B RID: 2363
		public readonly string hours;

		// Token: 0x0400093C RID: 2364
		public readonly string aMinute;

		// Token: 0x0400093D RID: 2365
		public readonly string minutes;

		// Token: 0x0400093E RID: 2366
		public readonly string aSecond;

		// Token: 0x0400093F RID: 2367
		public readonly string seconds;

		// Token: 0x04000940 RID: 2368
		public readonly string lessThanASecond;
	}

	// Token: 0x02000210 RID: 528
	public enum Rounding
	{
		// Token: 0x04000942 RID: 2370
		Floor,
		// Token: 0x04000943 RID: 2371
		Ceiling,
		// Token: 0x04000944 RID: 2372
		Round,
		// Token: 0x04000945 RID: 2373
		Decimal,
		// Token: 0x04000946 RID: 2374
		RoundedDecimal,
		// Token: 0x04000947 RID: 2375
		FancyDecimal,
		// Token: 0x04000948 RID: 2376
		RoundedFancyDecimal
	}
}
