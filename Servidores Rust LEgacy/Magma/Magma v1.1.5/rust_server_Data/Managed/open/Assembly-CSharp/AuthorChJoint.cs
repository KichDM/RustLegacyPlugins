using System;
using UnityEngine;

// Token: 0x02000033 RID: 51
public class AuthorChJoint : global::AuthorPeice
{
	// Token: 0x060001D6 RID: 470 RVA: 0x000081EC File Offset: 0x000063EC
	public AuthorChJoint()
	{
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x00008258 File Offset: 0x00006458
	// Note: this type is marked as 'beforefieldinit'.
	static AuthorChJoint()
	{
	}

	// Token: 0x17000051 RID: 81
	// (get) Token: 0x060001D8 RID: 472 RVA: 0x000082C0 File Offset: 0x000064C0
	// (set) Token: 0x060001D9 RID: 473 RVA: 0x0000830C File Offset: 0x0000650C
	private global::UnityEngine.SoftJointLimit lowTwist
	{
		get
		{
			global::UnityEngine.SoftJointLimit result = default(global::UnityEngine.SoftJointLimit);
			result.limit = this.twistL_limit;
			result.damper = this.twistL_dampler;
			result.spring = this.twistL_spring;
			result.bounciness = this.twistL_bounce;
			return result;
		}
		set
		{
			this.twistL_limit = value.limit;
			this.twistL_dampler = value.damper;
			this.twistL_spring = value.spring;
			this.twistL_bounce = value.bounciness;
		}
	}

	// Token: 0x17000052 RID: 82
	// (get) Token: 0x060001DA RID: 474 RVA: 0x00008350 File Offset: 0x00006550
	// (set) Token: 0x060001DB RID: 475 RVA: 0x0000839C File Offset: 0x0000659C
	private global::UnityEngine.SoftJointLimit highTwist
	{
		get
		{
			global::UnityEngine.SoftJointLimit result = default(global::UnityEngine.SoftJointLimit);
			result.limit = this.twistH_limit;
			result.damper = this.twistH_dampler;
			result.spring = this.twistH_spring;
			result.bounciness = this.twistH_bounce;
			return result;
		}
		set
		{
			this.twistH_limit = value.limit;
			this.twistH_dampler = value.damper;
			this.twistH_spring = value.spring;
			this.twistH_bounce = value.bounciness;
		}
	}

	// Token: 0x17000053 RID: 83
	// (get) Token: 0x060001DC RID: 476 RVA: 0x000083E0 File Offset: 0x000065E0
	// (set) Token: 0x060001DD RID: 477 RVA: 0x0000842C File Offset: 0x0000662C
	private global::UnityEngine.SoftJointLimit swing1
	{
		get
		{
			global::UnityEngine.SoftJointLimit result = default(global::UnityEngine.SoftJointLimit);
			result.limit = this.swing1_limit;
			result.damper = this.swing1_dampler;
			result.spring = this.swing1_spring;
			result.bounciness = this.swing1_bounce;
			return result;
		}
		set
		{
			this.swing1_limit = value.limit;
			this.swing1_dampler = value.damper;
			this.swing1_spring = value.spring;
			this.swing1_bounce = value.bounciness;
		}
	}

	// Token: 0x17000054 RID: 84
	// (get) Token: 0x060001DE RID: 478 RVA: 0x00008470 File Offset: 0x00006670
	// (set) Token: 0x060001DF RID: 479 RVA: 0x000084BC File Offset: 0x000066BC
	private global::UnityEngine.SoftJointLimit swing2
	{
		get
		{
			global::UnityEngine.SoftJointLimit result = default(global::UnityEngine.SoftJointLimit);
			result.limit = this.swing2_limit;
			result.damper = this.swing2_dampler;
			result.spring = this.swing2_spring;
			result.bounciness = this.swing2_bounce;
			return result;
		}
		set
		{
			this.swing2_limit = value.limit;
			this.swing2_dampler = value.damper;
			this.swing2_spring = value.spring;
			this.swing2_bounce = value.bounciness;
		}
	}

	// Token: 0x17000055 RID: 85
	// (get) Token: 0x060001E0 RID: 480 RVA: 0x00008500 File Offset: 0x00006700
	// (set) Token: 0x060001E1 RID: 481 RVA: 0x0000854C File Offset: 0x0000674C
	private global::UnityEngine.JointLimits limit
	{
		get
		{
			global::UnityEngine.JointLimits result = default(global::UnityEngine.JointLimits);
			result.min = this.h_limit_min;
			result.max = this.h_limit_max;
			result.minBounce = this.h_limit_minb;
			result.maxBounce = this.h_limit_maxb;
			return result;
		}
		set
		{
			this.h_limit_min = value.min;
			this.h_limit_max = value.max;
			this.h_limit_minb = value.minBounce;
			this.h_limit_maxb = value.maxBounce;
		}
	}

	// Token: 0x17000056 RID: 86
	// (get) Token: 0x060001E2 RID: 482 RVA: 0x00008590 File Offset: 0x00006790
	// (set) Token: 0x060001E3 RID: 483 RVA: 0x000085D0 File Offset: 0x000067D0
	private global::UnityEngine.JointSpring spring
	{
		get
		{
			global::UnityEngine.JointSpring result = default(global::UnityEngine.JointSpring);
			result.spring = this.h_spring_s;
			result.damper = this.h_spring_d;
			result.targetPosition = this.h_spring_t;
			return result;
		}
		set
		{
			this.h_spring_s = value.spring;
			this.h_spring_d = value.damper;
			this.h_spring_t = value.targetPosition;
		}
	}

	// Token: 0x17000057 RID: 87
	// (get) Token: 0x060001E4 RID: 484 RVA: 0x000085FC File Offset: 0x000067FC
	// (set) Token: 0x060001E5 RID: 485 RVA: 0x0000863C File Offset: 0x0000683C
	private global::UnityEngine.JointMotor motor
	{
		get
		{
			global::UnityEngine.JointMotor result = default(global::UnityEngine.JointMotor);
			result.force = this.h_motor_f;
			result.targetVelocity = this.h_motor_v;
			result.freeSpin = this.h_motor_s;
			return result;
		}
		set
		{
			this.h_motor_f = value.force;
			this.h_motor_v = value.targetVelocity;
			this.h_motor_s = value.freeSpin;
		}
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x00008668 File Offset: 0x00006868
	private void ConfigureJointShared(global::UnityEngine.Joint joint, global::UnityEngine.Transform root, ref global::AuthorChHit.Rep self)
	{
		if (this.connect)
		{
			global::AuthorChHit.Rep rep;
			if (self.mirrored)
			{
				rep = this.connect.secondary;
				if (!rep.valid)
				{
					rep = this.connect.primary;
				}
			}
			else
			{
				rep = this.connect.primary;
				if (!rep.valid)
				{
					rep = this.connect.secondary;
				}
			}
			if (rep.valid)
			{
				global::UnityEngine.Transform transform = root.FindChild(rep.path);
				global::UnityEngine.Rigidbody rigidbody = transform.rigidbody;
				if (!rigidbody)
				{
					rigidbody = transform.gameObject.AddComponent<global::UnityEngine.Rigidbody>();
				}
				joint.connectedBody = rigidbody;
			}
			else
			{
				global::UnityEngine.Debug.LogWarning("No means of making/getting rigidbody", this.connect);
			}
		}
		joint.anchor = self.Flip(this.anchor);
		joint.axis = self.AxisFlip(this.axis);
		joint.breakForce = this.breakForce;
		joint.breakTorque = this.breakTorque;
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x00008770 File Offset: 0x00006970
	private TJoint ConfigJoint<TJoint>(TJoint joint, global::UnityEngine.Transform root, ref global::AuthorChHit.Rep self) where TJoint : global::UnityEngine.Joint
	{
		this.ConfigureJointShared(joint, root, ref self);
		return joint;
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x00008784 File Offset: 0x00006984
	private TJoint CreateJoint<TJoint>(global::UnityEngine.Transform root, ref global::AuthorChHit.Rep self) where TJoint : global::UnityEngine.Joint
	{
		return this.ConfigJoint<TJoint>(self.bone.gameObject.AddComponent<TJoint>(), root, ref self);
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x000087AC File Offset: 0x000069AC
	public global::UnityEngine.Joint AddJoint(global::UnityEngine.Transform root, ref global::AuthorChHit.Rep self)
	{
		global::UnityEngine.Joint result;
		switch (this.kind)
		{
		case global::AuthorChJoint.Kind.Hinge:
		{
			global::UnityEngine.HingeJoint hingeJoint = this.CreateJoint<global::UnityEngine.HingeJoint>(root, ref self);
			hingeJoint.limits = this.limit;
			hingeJoint.useLimits = this.useLimit;
			hingeJoint.motor = this.motor;
			hingeJoint.useMotor = this.useMotor;
			hingeJoint.spring = this.spring;
			hingeJoint.useSpring = this.useSpring;
			result = hingeJoint;
			break;
		}
		case global::AuthorChJoint.Kind.Character:
		{
			global::UnityEngine.CharacterJoint characterJoint = this.CreateJoint<global::UnityEngine.CharacterJoint>(root, ref self);
			characterJoint.swingAxis = self.AxisFlip(this.swingAxis);
			characterJoint.lowTwistLimit = this.lowTwist;
			characterJoint.highTwistLimit = this.highTwist;
			characterJoint.lowTwistLimit = this.lowTwist;
			characterJoint.swing1Limit = this.swing1;
			characterJoint.swing2Limit = this.swing2;
			result = characterJoint;
			break;
		}
		case global::AuthorChJoint.Kind.Fixed:
		{
			global::UnityEngine.FixedJoint fixedJoint = this.CreateJoint<global::UnityEngine.FixedJoint>(root, ref self);
			result = fixedJoint;
			break;
		}
		case global::AuthorChJoint.Kind.Spring:
		{
			global::UnityEngine.SpringJoint springJoint = this.CreateJoint<global::UnityEngine.SpringJoint>(root, ref self);
			springJoint.spring = this.spring_spring;
			springJoint.damper = this.spring_damper;
			springJoint.minDistance = this.spring_min;
			springJoint.maxDistance = this.spring_max;
			result = springJoint;
			break;
		}
		default:
			return null;
		}
		return result;
	}

	// Token: 0x060001EA RID: 490 RVA: 0x000088F0 File Offset: 0x00006AF0
	private bool DoTransformHandles(ref global::AuthorChHit.Rep self, ref global::AuthorChHit.Rep connect)
	{
		if (!self.valid)
		{
			return false;
		}
		global::UnityEngine.Vector3 v = self.Flip(this.anchor);
		global::UnityEngine.Vector3 vector = self.AxisFlip(this.axis);
		global::UnityEngine.Vector3 vector2 = self.AxisFlip(this.swingAxis);
		global::UnityEngine.Matrix4x4 matrix = global::AuthorShared.Scene.matrix;
		if (connect.valid)
		{
			global::AuthorShared.Scene.matrix = connect.bone.localToWorldMatrix;
			global::UnityEngine.Color color = global::AuthorShared.Scene.color;
			global::AuthorShared.Scene.color = color * new global::UnityEngine.Color(1f, 1f, 1f, 0.4f);
			global::UnityEngine.Vector3 vector3 = connect.bone.InverseTransformPoint(self.bone.position);
			if (vector3 != global::UnityEngine.Vector3.zero)
			{
				global::AuthorShared.Scene.DrawBone(global::UnityEngine.Vector3.zero, global::UnityEngine.Quaternion.LookRotation(vector3), vector3.magnitude, 0.02f, new global::UnityEngine.Vector3(0.05f, 0.05f, 0.5f));
			}
			global::AuthorShared.Scene.color = color;
		}
		global::AuthorShared.Scene.matrix = self.bone.localToWorldMatrix;
		bool result = false;
		if (global::AuthorShared.Scene.PivotDrag(ref v, ref vector))
		{
			result = true;
			this.anchor = self.Flip(v);
			this.axis = self.AxisFlip(vector);
		}
		global::AuthorChJoint.Kind kind = this.kind;
		if (kind != global::AuthorChJoint.Kind.Hinge)
		{
			if (kind == global::AuthorChJoint.Kind.Character)
			{
				global::UnityEngine.Color color2 = global::AuthorShared.Scene.color;
				global::AuthorShared.Scene.color = color2 * global::AuthorChJoint.twistColor;
				global::UnityEngine.SoftJointLimit softJointLimit = this.lowTwist;
				global::UnityEngine.SoftJointLimit highTwist = this.highTwist;
				if (global::AuthorShared.Scene.LimitDrag(v, vector, ref this.twistOffset, ref softJointLimit, ref highTwist))
				{
					result = true;
					this.lowTwist = softJointLimit;
					this.highTwist = highTwist;
				}
				global::AuthorShared.Scene.color = color2 * global::AuthorChJoint.swing1Color;
				softJointLimit = this.swing1;
				if (global::AuthorShared.Scene.LimitDrag(v, vector2, ref this.swingOffset1, ref softJointLimit))
				{
					result = true;
					this.swing1 = softJointLimit;
				}
				global::AuthorShared.Scene.color = color2 * global::AuthorChJoint.swing2Color;
				softJointLimit = this.swing2;
				if (global::AuthorShared.Scene.LimitDrag(v, global::UnityEngine.Vector3.Cross(vector2, vector), ref this.swingOffset2, ref softJointLimit))
				{
					result = true;
					this.swing2 = softJointLimit;
				}
				global::AuthorShared.Scene.color = color2;
			}
		}
		else if (this.useLimit)
		{
			global::UnityEngine.JointLimits limit = this.limit;
			if (global::AuthorShared.Scene.LimitDrag(v, vector, ref this.limitOffset, ref limit))
			{
				result = true;
				this.limit = limit;
			}
		}
		global::AuthorShared.Scene.matrix = matrix;
		return result;
	}

	// Token: 0x060001EB RID: 491 RVA: 0x00008B54 File Offset: 0x00006D54
	public override bool OnSceneView()
	{
		bool flag = base.OnSceneView();
		global::AuthorChHit.Rep primary = this.self.primary;
		global::AuthorChHit.Rep secondary = this.self.secondary;
		global::AuthorChHit.Rep rep = default(global::AuthorChHit.Rep);
		global::AuthorChHit.Rep rep2 = default(global::AuthorChHit.Rep);
		if (this.connect)
		{
			rep = this.connect.primary;
			rep2 = this.connect.secondary;
			if (!rep2.valid)
			{
				rep2 = rep;
			}
		}
		if (primary.valid)
		{
			flag |= this.DoTransformHandles(ref primary, ref rep);
		}
		if (secondary.valid)
		{
			flag |= this.DoTransformHandles(ref secondary, ref rep2);
		}
		return flag;
	}

	// Token: 0x060001EC RID: 492 RVA: 0x00008C04 File Offset: 0x00006E04
	private static bool Field(global::AuthorShared.Content content, ref global::UnityEngine.JointLimits limits, ref bool use, ref float offset)
	{
		global::UnityEngine.GUI.Box(global::AuthorShared.BeginVertical(new global::UnityEngine.GUILayoutOption[0]), global::UnityEngine.GUIContent.none);
		global::AuthorShared.PrefixLabel(content);
		bool flag = use;
		bool flag2 = global::AuthorShared.Change(ref use, global::UnityEngine.GUILayout.Toggle(use, "Use", new global::UnityEngine.GUILayoutOption[0]));
		if (flag)
		{
			float min = limits.min;
			float max = limits.max;
			float minBounce = limits.minBounce;
			float maxBounce = limits.maxBounce;
			flag2 |= global::AuthorShared.FloatField("Min", ref min, new global::UnityEngine.GUILayoutOption[0]);
			flag2 |= global::AuthorShared.FloatField("Max", ref max, new global::UnityEngine.GUILayoutOption[0]);
			flag2 |= global::AuthorShared.FloatField("Min bounciness", ref minBounce, new global::UnityEngine.GUILayoutOption[0]);
			flag2 |= global::AuthorShared.FloatField("Max bounciness", ref maxBounce, new global::UnityEngine.GUILayoutOption[0]);
			if (use && flag2)
			{
				limits.min = min;
				limits.max = max;
				limits.minBounce = minBounce;
				limits.maxBounce = maxBounce;
			}
			global::UnityEngine.Color contentColor = global::UnityEngine.GUI.contentColor;
			global::UnityEngine.GUI.contentColor = contentColor * new global::UnityEngine.Color(1f, 1f, 1f, 0.3f);
			flag2 |= global::AuthorShared.FloatField("Offset(visual only)", ref offset, new global::UnityEngine.GUILayoutOption[0]);
			global::UnityEngine.GUI.contentColor = contentColor;
		}
		global::AuthorShared.EndVertical();
		return flag2;
	}

	// Token: 0x060001ED RID: 493 RVA: 0x00008D54 File Offset: 0x00006F54
	private static bool Field(global::AuthorShared.Content content, ref global::UnityEngine.JointMotor motor, ref bool use)
	{
		global::UnityEngine.GUI.Box(global::AuthorShared.BeginVertical(new global::UnityEngine.GUILayoutOption[0]), global::UnityEngine.GUIContent.none);
		global::AuthorShared.PrefixLabel(content);
		bool flag = use;
		bool flag2 = global::AuthorShared.Change(ref use, global::UnityEngine.GUILayout.Toggle(use, "Use", new global::UnityEngine.GUILayoutOption[0]));
		if (flag)
		{
			float force = motor.force;
			float targetVelocity = motor.targetVelocity;
			bool freeSpin = motor.freeSpin;
			flag2 |= global::AuthorShared.FloatField("Force", ref force, new global::UnityEngine.GUILayoutOption[0]);
			flag2 |= global::AuthorShared.FloatField("Target Velocity", ref targetVelocity, new global::UnityEngine.GUILayoutOption[0]);
			flag2 |= global::AuthorShared.Change(ref freeSpin, global::UnityEngine.GUILayout.Toggle(freeSpin, "Free Spin", new global::UnityEngine.GUILayoutOption[0]));
			if (use && flag2)
			{
				motor.force = force;
				motor.targetVelocity = targetVelocity;
				motor.freeSpin = freeSpin;
			}
		}
		global::AuthorShared.EndVertical();
		return flag2;
	}

	// Token: 0x060001EE RID: 494 RVA: 0x00008E30 File Offset: 0x00007030
	private static bool Field(global::AuthorShared.Content content, ref global::UnityEngine.JointSpring spring, ref bool use)
	{
		global::UnityEngine.GUI.Box(global::AuthorShared.BeginVertical(new global::UnityEngine.GUILayoutOption[0]), global::UnityEngine.GUIContent.none);
		global::AuthorShared.PrefixLabel(content);
		bool flag = use;
		bool flag2 = global::AuthorShared.Change(ref use, global::UnityEngine.GUILayout.Toggle(use, "Use", new global::UnityEngine.GUILayoutOption[0]));
		if (flag)
		{
			float spring2 = spring.spring;
			float targetPosition = spring.targetPosition;
			float damper = spring.damper;
			flag2 |= global::AuthorShared.FloatField("Spring Force", ref spring2, new global::UnityEngine.GUILayoutOption[0]);
			flag2 |= global::AuthorShared.FloatField("Target Position", ref targetPosition, new global::UnityEngine.GUILayoutOption[0]);
			flag2 |= global::AuthorShared.FloatField("Damper", ref damper, new global::UnityEngine.GUILayoutOption[0]);
			if (use && flag2)
			{
				spring.spring = spring2;
				spring.targetPosition = targetPosition;
				spring.damper = damper;
			}
		}
		global::AuthorShared.EndVertical();
		return flag2;
	}

	// Token: 0x060001EF RID: 495 RVA: 0x00008F08 File Offset: 0x00007108
	private static bool Field(global::AuthorShared.Content content, ref global::UnityEngine.SoftJointLimit limits, ref float offset)
	{
		global::UnityEngine.GUI.Box(global::AuthorShared.BeginVertical(new global::UnityEngine.GUILayoutOption[0]), global::UnityEngine.GUIContent.none);
		global::AuthorShared.PrefixLabel(content);
		float limit = limits.limit;
		float spring = limits.spring;
		float damper = limits.damper;
		float bounciness = limits.bounciness;
		bool flag = global::AuthorShared.FloatField("Limit", ref limit, new global::UnityEngine.GUILayoutOption[0]);
		flag |= global::AuthorShared.FloatField("Spring", ref spring, new global::UnityEngine.GUILayoutOption[0]);
		flag |= global::AuthorShared.FloatField("Damper", ref damper, new global::UnityEngine.GUILayoutOption[0]);
		flag |= global::AuthorShared.FloatField("Bounciness", ref bounciness, new global::UnityEngine.GUILayoutOption[0]);
		if (flag)
		{
			limits.limit = limit;
			limits.spring = spring;
			limits.damper = damper;
			limits.bounciness = bounciness;
		}
		global::UnityEngine.Color contentColor = global::UnityEngine.GUI.contentColor;
		global::UnityEngine.GUI.contentColor = contentColor * new global::UnityEngine.Color(1f, 1f, 1f, 0.3f);
		flag |= global::AuthorShared.FloatField("Offset(visual only)", ref offset, new global::UnityEngine.GUILayoutOption[0]);
		global::UnityEngine.GUI.contentColor = contentColor;
		global::AuthorShared.EndVertical();
		return flag;
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x00009034 File Offset: 0x00007234
	protected override void OnPeiceDestroy()
	{
		try
		{
			if (this.self)
			{
				this.self.OnJointDestroy(this);
			}
		}
		finally
		{
			base.OnPeiceDestroy();
		}
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x00009088 File Offset: 0x00007288
	public override bool PeiceInspectorGUI()
	{
		bool flag = base.PeiceInspectorGUI();
		string peiceID = base.peiceID;
		if (global::AuthorShared.StringField("Title", ref peiceID, new global::UnityEngine.GUILayoutOption[0]))
		{
			base.peiceID = peiceID;
			flag = true;
		}
		global::AuthorShared.EnumField("Kind", this.kind, new global::UnityEngine.GUILayoutOption[0]);
		global::AuthorShared.PrefixLabel("Self");
		if (global::UnityEngine.GUILayout.Button(global::AuthorShared.ObjectContent<global::AuthorChHit>(this.self, typeof(global::AuthorChHit)), new global::UnityEngine.GUILayoutOption[0]))
		{
			global::AuthorShared.PingObject(this.self);
		}
		flag |= global::AuthorShared.PeiceField<global::AuthorChHit>("Connected", this, ref this.connect, typeof(global::AuthorChHit), global::UnityEngine.GUI.skin.button, new global::UnityEngine.GUILayoutOption[0]);
		flag |= global::AuthorShared.Toggle("Reverse Link", ref this.reverseLink, new global::UnityEngine.GUILayoutOption[0]);
		flag |= global::AuthorShared.Vector3Field("Anchor", ref this.anchor, new global::UnityEngine.GUILayoutOption[0]);
		flag |= global::AuthorShared.Vector3Field("Axis", ref this.axis, new global::UnityEngine.GUILayoutOption[0]);
		global::AuthorChJoint.Kind kind = this.kind;
		if (kind != global::AuthorChJoint.Kind.Hinge)
		{
			if (kind == global::AuthorChJoint.Kind.Character)
			{
				flag |= global::AuthorShared.Vector3Field("Swing Axis", ref this.swingAxis, new global::UnityEngine.GUILayoutOption[0]);
				global::UnityEngine.SoftJointLimit softJointLimit = this.lowTwist;
				if (global::AuthorChJoint.Field("Low Twist", ref softJointLimit, ref this.twistOffset))
				{
					flag = true;
					this.lowTwist = softJointLimit;
				}
				softJointLimit = this.highTwist;
				if (global::AuthorChJoint.Field("High Twist", ref softJointLimit, ref this.twistOffset))
				{
					flag = true;
					this.highTwist = softJointLimit;
				}
				softJointLimit = this.swing1;
				if (global::AuthorChJoint.Field("Swing 1", ref softJointLimit, ref this.swingOffset1))
				{
					flag = true;
					this.swing1 = softJointLimit;
				}
				softJointLimit = this.swing2;
				if (global::AuthorChJoint.Field("Swing 2", ref softJointLimit, ref this.swingOffset2))
				{
					flag = true;
					this.swing2 = softJointLimit;
				}
			}
		}
		else
		{
			global::UnityEngine.JointLimits limit = this.limit;
			if (global::AuthorChJoint.Field("Limits", ref limit, ref this.useLimit, ref this.limitOffset))
			{
				flag = true;
				this.limit = limit;
			}
		}
		flag |= global::AuthorShared.FloatField("Break Force", ref this.breakForce, new global::UnityEngine.GUILayoutOption[0]);
		return flag | global::AuthorShared.FloatField("Break Torque", ref this.breakTorque, new global::UnityEngine.GUILayoutOption[0]);
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x00009320 File Offset: 0x00007520
	internal void InitializeFromOwner(global::AuthorChHit self, global::AuthorChJoint.Kind kind)
	{
		this.self = self;
		this.kind = kind;
		global::AuthorShared.SetDirty(this);
	}

	// Token: 0x040000FC RID: 252
	[global::UnityEngine.SerializeField]
	private global::AuthorChHit self;

	// Token: 0x040000FD RID: 253
	[global::UnityEngine.SerializeField]
	private global::AuthorChHit connect;

	// Token: 0x040000FE RID: 254
	[global::UnityEngine.SerializeField]
	private global::AuthorChJoint.Kind kind;

	// Token: 0x040000FF RID: 255
	[global::UnityEngine.SerializeField]
	private bool reverseLink;

	// Token: 0x04000100 RID: 256
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector3 anchor;

	// Token: 0x04000101 RID: 257
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector3 axis = global::UnityEngine.Vector3.up;

	// Token: 0x04000102 RID: 258
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector3 swingAxis = global::UnityEngine.Vector3.forward;

	// Token: 0x04000103 RID: 259
	[global::UnityEngine.SerializeField]
	private float twistL_limit = -20f;

	// Token: 0x04000104 RID: 260
	[global::UnityEngine.SerializeField]
	private float twistL_bounce;

	// Token: 0x04000105 RID: 261
	[global::UnityEngine.SerializeField]
	private float twistL_dampler;

	// Token: 0x04000106 RID: 262
	[global::UnityEngine.SerializeField]
	private float twistL_spring;

	// Token: 0x04000107 RID: 263
	[global::UnityEngine.SerializeField]
	private float twistH_limit = 70f;

	// Token: 0x04000108 RID: 264
	[global::UnityEngine.SerializeField]
	private float twistH_bounce;

	// Token: 0x04000109 RID: 265
	[global::UnityEngine.SerializeField]
	private float twistH_dampler;

	// Token: 0x0400010A RID: 266
	[global::UnityEngine.SerializeField]
	private float twistH_spring;

	// Token: 0x0400010B RID: 267
	[global::UnityEngine.SerializeField]
	private float swing1_limit = 20f;

	// Token: 0x0400010C RID: 268
	[global::UnityEngine.SerializeField]
	private float swing1_bounce;

	// Token: 0x0400010D RID: 269
	[global::UnityEngine.SerializeField]
	private float swing1_dampler;

	// Token: 0x0400010E RID: 270
	[global::UnityEngine.SerializeField]
	private float swing1_spring;

	// Token: 0x0400010F RID: 271
	[global::UnityEngine.SerializeField]
	private float swing2_limit = 20f;

	// Token: 0x04000110 RID: 272
	[global::UnityEngine.SerializeField]
	private float swing2_bounce;

	// Token: 0x04000111 RID: 273
	[global::UnityEngine.SerializeField]
	private float swing2_dampler;

	// Token: 0x04000112 RID: 274
	[global::UnityEngine.SerializeField]
	private float swing2_spring;

	// Token: 0x04000113 RID: 275
	[global::UnityEngine.SerializeField]
	private float h_limit_min;

	// Token: 0x04000114 RID: 276
	[global::UnityEngine.SerializeField]
	private float h_limit_max;

	// Token: 0x04000115 RID: 277
	[global::UnityEngine.SerializeField]
	private float h_limit_minb;

	// Token: 0x04000116 RID: 278
	[global::UnityEngine.SerializeField]
	private float h_limit_maxb;

	// Token: 0x04000117 RID: 279
	[global::UnityEngine.SerializeField]
	private float h_spring_s;

	// Token: 0x04000118 RID: 280
	[global::UnityEngine.SerializeField]
	private float h_spring_d;

	// Token: 0x04000119 RID: 281
	[global::UnityEngine.SerializeField]
	private float h_spring_t;

	// Token: 0x0400011A RID: 282
	[global::UnityEngine.SerializeField]
	private float h_motor_f;

	// Token: 0x0400011B RID: 283
	[global::UnityEngine.SerializeField]
	private float h_motor_v;

	// Token: 0x0400011C RID: 284
	[global::UnityEngine.SerializeField]
	private bool h_motor_s;

	// Token: 0x0400011D RID: 285
	[global::UnityEngine.SerializeField]
	private float spring_spring;

	// Token: 0x0400011E RID: 286
	[global::UnityEngine.SerializeField]
	private float spring_min;

	// Token: 0x0400011F RID: 287
	[global::UnityEngine.SerializeField]
	private float spring_max;

	// Token: 0x04000120 RID: 288
	[global::UnityEngine.SerializeField]
	private float spring_damper;

	// Token: 0x04000121 RID: 289
	[global::UnityEngine.SerializeField]
	private bool useLimit;

	// Token: 0x04000122 RID: 290
	[global::UnityEngine.SerializeField]
	private bool useSpring;

	// Token: 0x04000123 RID: 291
	[global::UnityEngine.SerializeField]
	private bool useMotor;

	// Token: 0x04000124 RID: 292
	[global::UnityEngine.SerializeField]
	private float limitOffset;

	// Token: 0x04000125 RID: 293
	[global::UnityEngine.SerializeField]
	private float twistOffset;

	// Token: 0x04000126 RID: 294
	[global::UnityEngine.SerializeField]
	private float swingOffset1;

	// Token: 0x04000127 RID: 295
	[global::UnityEngine.SerializeField]
	private float swingOffset2;

	// Token: 0x04000128 RID: 296
	[global::UnityEngine.SerializeField]
	private float breakForce = float.PositiveInfinity;

	// Token: 0x04000129 RID: 297
	[global::UnityEngine.SerializeField]
	private float breakTorque = float.PositiveInfinity;

	// Token: 0x0400012A RID: 298
	private static readonly global::UnityEngine.Color twistColor = new global::UnityEngine.Color(1f, 1f, 0.4f, 0.8f);

	// Token: 0x0400012B RID: 299
	private static readonly global::UnityEngine.Color swing1Color = new global::UnityEngine.Color(1f, 0.4f, 1f, 0.8f);

	// Token: 0x0400012C RID: 300
	private static readonly global::UnityEngine.Color swing2Color = new global::UnityEngine.Color(0.4f, 1f, 1f, 0.8f);

	// Token: 0x02000034 RID: 52
	public enum Kind
	{
		// Token: 0x0400012E RID: 302
		None,
		// Token: 0x0400012F RID: 303
		Hinge,
		// Token: 0x04000130 RID: 304
		Character,
		// Token: 0x04000131 RID: 305
		Fixed,
		// Token: 0x04000132 RID: 306
		Spring
	}
}
