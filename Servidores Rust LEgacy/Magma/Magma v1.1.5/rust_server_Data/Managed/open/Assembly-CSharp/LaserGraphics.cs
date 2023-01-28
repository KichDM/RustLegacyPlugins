using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200072B RID: 1835
[global::UnityEngine.AddComponentMenu("")]
[global::UnityEngine.ExecuteInEditMode]
public sealed class LaserGraphics : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003E0A RID: 15882 RVA: 0x000D9448 File Offset: 0x000D7648
	public LaserGraphics()
	{
	}

	// Token: 0x06003E0B RID: 15883 RVA: 0x000D9450 File Offset: 0x000D7650
	// Note: this type is marked as 'beforefieldinit'.
	static LaserGraphics()
	{
	}

	// Token: 0x06003E0C RID: 15884 RVA: 0x000D94D4 File Offset: 0x000D76D4
	private static void UpdateBeam(ref global::LaserBeam.FrameData frame, global::LaserBeam beam)
	{
		global::UnityEngine.Transform transform = beam.transform;
		frame.origin = transform.position;
		frame.direction = transform.forward;
		frame.direction.Normalize();
		int num = beam.beamLayers;
		global::UnityEngine.RaycastHit raycastHit2;
		if (num == 0)
		{
			frame.hit = false;
		}
		else if (beam.isViewModel)
		{
			global::RaycastHit2 raycastHit;
			if (frame.hit = global::Physics2.Raycast2(frame.origin, frame.direction, ref raycastHit, beam.beamMaxDistance, num))
			{
				frame.hitPoint = raycastHit.point;
				frame.hitNormal = raycastHit.normal;
			}
		}
		else if (frame.hit = global::UnityEngine.Physics.Raycast(frame.origin, frame.direction, ref raycastHit2, beam.beamMaxDistance, num))
		{
			frame.hitPoint = raycastHit2.point;
			frame.hitNormal = raycastHit2.normal;
		}
		if (!frame.hit)
		{
			frame.didHit = false;
			frame.point.x = frame.origin.x + frame.direction.x * beam.beamMaxDistance;
			frame.point.y = frame.origin.y + frame.direction.y * beam.beamMaxDistance;
			frame.point.z = frame.origin.z + frame.direction.z * beam.beamMaxDistance;
			frame.distance = beam.beamMaxDistance;
			frame.distanceFraction = 1f;
			frame.pointWidth = beam.beamWidthEnd;
		}
		else
		{
			frame.point = frame.hitPoint;
			frame.didHit = true;
			frame.distance = frame.direction.x * frame.point.x + frame.direction.y * frame.point.y + frame.direction.z * frame.point.z - (frame.direction.x * frame.origin.x + frame.direction.y * frame.origin.y + frame.direction.z * frame.origin.z);
			frame.distanceFraction = frame.distance / beam.beamMaxDistance;
			frame.pointWidth = global::UnityEngine.Mathf.Lerp(beam.beamWidthStart, beam.beamWidthEnd, frame.distanceFraction);
			frame.dotRadius = global::UnityEngine.Mathf.Lerp(beam.dotRadiusStart, beam.dotRadiusEnd, frame.distanceFraction);
		}
		frame.originWidth = beam.beamWidthStart;
		global::UnityEngine.Vector3 vector;
		vector.x = (vector.y = (vector.z = frame.originWidth));
		frame.bounds = new global::UnityEngine.Bounds(frame.origin, vector);
		vector.x = (vector.y = (vector.z = frame.pointWidth));
		frame.bounds.Encapsulate(new global::UnityEngine.Bounds(frame.point, vector));
		frame.beamsLayer = 1 << beam.gameObject.layer;
		global::LaserGraphics.allBeamsMask |= frame.beamsLayer;
	}

	// Token: 0x06003E0D RID: 15885 RVA: 0x000D9814 File Offset: 0x000D7A14
	public static void EnsureGraphicsExist()
	{
		if (!global::LaserGraphics.singleton)
		{
			global::UnityEngine.GameObject gameObject = global::UnityEngine.GameObject.Find("__LASER_GRAPHICS__");
			if (!gameObject)
			{
				gameObject = new global::UnityEngine.GameObject
				{
					hideFlags = 0xC,
					name = "__LASER_GRAPHICS__"
				};
				global::LaserGraphics.singleton = gameObject.AddComponent<global::LaserGraphics>();
				global::LaserGraphics.singleton.hideFlags = 0xC;
			}
			else
			{
				global::LaserGraphics.singleton = gameObject.GetComponent<global::LaserGraphics>();
				if (!global::LaserGraphics.singleton)
				{
					global::LaserGraphics.singleton = gameObject.AddComponent<global::LaserGraphics>();
					global::LaserGraphics.singleton.hideFlags = 0xC;
				}
			}
		}
	}

	// Token: 0x06003E0E RID: 15886 RVA: 0x000D98B0 File Offset: 0x000D7AB0
	private void RenderLasers(global::UnityEngine.Camera camera)
	{
		if (!this.madeLists)
		{
			this.beams = new global::System.Collections.Generic.List<global::LaserBeam>();
			this.willRender = new global::System.Collections.Generic.List<global::LaserBeam>();
			this.madeLists = true;
		}
		int cullingMask = camera.cullingMask;
		if (this.beams == null)
		{
			this.beams = new global::System.Collections.Generic.List<global::LaserBeam>(global::LaserBeam.Collect());
		}
		else
		{
			this.beams.Clear();
			this.beams.AddRange(global::LaserBeam.Collect());
		}
		global::LaserGraphics.allBeamsMask = 0;
		foreach (global::LaserBeam laserBeam in this.beams)
		{
			global::LaserGraphics.UpdateBeam(ref laserBeam.frame, laserBeam);
		}
		if ((cullingMask & global::LaserGraphics.allBeamsMask) != 0 && this.beams.Count > 0)
		{
			global::UnityEngine.Plane[] array = global::UnityEngine.GeometryUtility.CalculateFrustumPlanes(camera);
			foreach (global::LaserBeam laserBeam2 in this.beams)
			{
				if (laserBeam2.isViewModel || ((cullingMask & laserBeam2.frame.beamsLayer) == laserBeam2.frame.beamsLayer && global::UnityEngine.GeometryUtility.TestPlanesAABB(array, laserBeam2.frame.bounds)))
				{
					this.willRender.Add(laserBeam2);
				}
			}
			if (this.willRender.Count > 0)
			{
				global::LaserGraphics.world2Cam = camera.worldToCameraMatrix;
				global::LaserGraphics.cam2World = camera.cameraToWorldMatrix;
				global::LaserGraphics.camProj = camera.projectionMatrix;
				try
				{
					foreach (global::LaserBeam laserBeam3 in this.willRender)
					{
						global::LaserGraphics.RenderBeam(array, camera, laserBeam3, ref laserBeam3.frame);
					}
					foreach (global::LaserGraphics.MeshBuffer meshBuffer in global::LaserGraphics.Computation.beams)
					{
						bool rebindVertexLayout = meshBuffer.Resize();
						int num = 0;
						global::LaserGraphics.VertexBuffer buffer = meshBuffer.buffer;
						global::UnityEngine.Vector3 min;
						min.x = (min.y = (min.z = float.PositiveInfinity));
						global::UnityEngine.Vector3 max;
						max.x = (max.y = (max.z = float.NegativeInfinity));
						foreach (global::LaserBeam laserBeam4 in meshBuffer.beams)
						{
							int num2 = num++;
							int num3 = num++;
							int num4 = num++;
							int num5 = num++;
							buffer.v[num2] = laserBeam4.frame.beamVertices.m0;
							buffer.v[num3] = laserBeam4.frame.beamVertices.m1;
							buffer.v[num5] = laserBeam4.frame.beamVertices.m2;
							buffer.v[num4] = laserBeam4.frame.beamVertices.m3;
							buffer.n[num2] = laserBeam4.frame.beamNormals.m0;
							buffer.n[num3] = laserBeam4.frame.beamNormals.m1;
							buffer.n[num5] = laserBeam4.frame.beamNormals.m2;
							buffer.n[num4] = laserBeam4.frame.beamNormals.m3;
							buffer.c[num2] = laserBeam4.frame.beamColor.m0;
							buffer.c[num3] = laserBeam4.frame.beamColor.m1;
							buffer.c[num5] = laserBeam4.frame.beamColor.m2;
							buffer.c[num4] = laserBeam4.frame.beamColor.m3;
							buffer.t[num2] = laserBeam4.frame.beamUVs.m0;
							buffer.t[num3] = laserBeam4.frame.beamUVs.m1;
							buffer.t[num5] = laserBeam4.frame.beamUVs.m2;
							buffer.t[num4] = laserBeam4.frame.beamUVs.m3;
							for (int i = num2; i <= num4; i++)
							{
								if (buffer.v[i].x < min.x)
								{
									min.x = buffer.v[i].x;
								}
								if (buffer.v[i].x > max.x)
								{
									max.x = buffer.v[i].x;
								}
								if (buffer.v[i].y < min.y)
								{
									min.y = buffer.v[i].y;
								}
								if (buffer.v[i].y > max.y)
								{
									max.y = buffer.v[i].y;
								}
								if (buffer.v[i].z < min.z)
								{
									min.z = buffer.v[i].z;
								}
								if (buffer.v[i].z > max.z)
								{
									max.z = buffer.v[i].z;
								}
							}
							laserBeam4.frame.bufBeam = null;
						}
						meshBuffer.beams.Clear();
						meshBuffer.BindMesh(rebindVertexLayout, min, max);
						global::UnityEngine.Graphics.DrawMesh(meshBuffer.mesh, global::UnityEngine.Matrix4x4.identity, meshBuffer.material, 1, camera, 0, null, false, false);
					}
					foreach (global::LaserGraphics.MeshBuffer meshBuffer2 in global::LaserGraphics.Computation.dots)
					{
						bool flag = meshBuffer2.Resize();
						int num6 = 0;
						global::LaserGraphics.VertexBuffer buffer2 = meshBuffer2.buffer;
						global::UnityEngine.Vector3 min2;
						min2.x = (min2.y = (min2.z = float.PositiveInfinity));
						global::UnityEngine.Vector3 max2;
						max2.x = (max2.y = (max2.z = float.NegativeInfinity));
						foreach (global::LaserBeam laserBeam5 in meshBuffer2.beams)
						{
							int num7 = num6++;
							int num8 = num6++;
							int num9 = num6++;
							int num10 = num6++;
							buffer2.v[num7] = laserBeam5.frame.dotVertices1.m0;
							buffer2.v[num8] = laserBeam5.frame.dotVertices1.m1;
							buffer2.v[num10] = laserBeam5.frame.dotVertices1.m2;
							buffer2.v[num9] = laserBeam5.frame.dotVertices1.m3;
							buffer2.n[num7] = laserBeam5.frame.beamNormals.m0;
							buffer2.n[num8] = laserBeam5.frame.beamNormals.m1;
							buffer2.n[num10] = laserBeam5.frame.beamNormals.m2;
							buffer2.n[num9] = laserBeam5.frame.beamNormals.m3;
							buffer2.c[num7] = laserBeam5.frame.dotColor1.m0;
							buffer2.c[num8] = laserBeam5.frame.dotColor1.m1;
							buffer2.c[num10] = laserBeam5.frame.dotColor1.m2;
							buffer2.c[num9] = laserBeam5.frame.dotColor1.m3;
							buffer2.t[num7] = global::LaserGraphics.uv[0];
							buffer2.t[num8] = global::LaserGraphics.uv[1];
							buffer2.t[num10] = global::LaserGraphics.uv[2];
							buffer2.t[num9] = global::LaserGraphics.uv[3];
							for (int j = num7; j <= num9; j++)
							{
								if (buffer2.v[j].x < min2.x)
								{
									min2.x = buffer2.v[j].x;
								}
								if (buffer2.v[j].x > max2.x)
								{
									max2.x = buffer2.v[j].x;
								}
								if (buffer2.v[j].y < min2.y)
								{
									min2.y = buffer2.v[j].y;
								}
								if (buffer2.v[j].y > max2.y)
								{
									max2.y = buffer2.v[j].y;
								}
								if (buffer2.v[j].z < min2.z)
								{
									min2.z = buffer2.v[j].z;
								}
								if (buffer2.v[j].z > max2.z)
								{
									max2.z = buffer2.v[j].z;
								}
							}
							num7 = num6++;
							num8 = num6++;
							num9 = num6++;
							num10 = num6++;
							buffer2.v[num7] = laserBeam5.frame.dotVertices2.m0;
							buffer2.v[num8] = laserBeam5.frame.dotVertices2.m1;
							buffer2.v[num10] = laserBeam5.frame.dotVertices2.m2;
							buffer2.v[num9] = laserBeam5.frame.dotVertices2.m3;
							buffer2.n[num7] = laserBeam5.frame.beamNormals.m0;
							buffer2.n[num8] = laserBeam5.frame.beamNormals.m1;
							buffer2.n[num10] = laserBeam5.frame.beamNormals.m2;
							buffer2.n[num9] = laserBeam5.frame.beamNormals.m3;
							buffer2.c[num7] = laserBeam5.frame.dotColor2.m0;
							buffer2.c[num8] = laserBeam5.frame.dotColor2.m1;
							buffer2.c[num10] = laserBeam5.frame.dotColor2.m2;
							buffer2.c[num9] = laserBeam5.frame.dotColor2.m3;
							buffer2.t[num7] = global::LaserGraphics.uv[0];
							buffer2.t[num8] = global::LaserGraphics.uv[1];
							buffer2.t[num10] = global::LaserGraphics.uv[2];
							buffer2.t[num9] = global::LaserGraphics.uv[3];
							for (int k = num7; k <= num9; k++)
							{
								if (buffer2.v[k].x < min2.x)
								{
									min2.x = buffer2.v[k].x;
								}
								if (buffer2.v[k].x > max2.x)
								{
									max2.x = buffer2.v[k].x;
								}
								if (buffer2.v[k].y < min2.y)
								{
									min2.y = buffer2.v[k].y;
								}
								if (buffer2.v[k].y > max2.y)
								{
									max2.y = buffer2.v[k].y;
								}
								if (buffer2.v[k].z < min2.z)
								{
									min2.z = buffer2.v[k].z;
								}
								if (buffer2.v[k].z > max2.z)
								{
									max2.z = buffer2.v[k].z;
								}
							}
							laserBeam5.frame.bufDot = null;
						}
						meshBuffer2.beams.Clear();
						if (flag)
						{
							meshBuffer2.mesh.Clear(false);
							meshBuffer2.mesh.vertices = buffer2.v;
							meshBuffer2.mesh.normals = buffer2.n;
							meshBuffer2.mesh.colors = buffer2.c;
							meshBuffer2.mesh.uv = buffer2.t;
							meshBuffer2.mesh.SetIndices(buffer2.i, 2, 0);
						}
						else
						{
							meshBuffer2.mesh.vertices = buffer2.v;
							meshBuffer2.mesh.normals = buffer2.n;
							meshBuffer2.mesh.colors = buffer2.c;
							meshBuffer2.mesh.uv = buffer2.t;
						}
						meshBuffer2.BindMesh(flag, min2, max2);
						global::UnityEngine.Graphics.DrawMesh(meshBuffer2.mesh, global::UnityEngine.Matrix4x4.identity, meshBuffer2.material, 1, camera, 0, null, false, false);
					}
				}
				finally
				{
					this.willRender.Clear();
					global::LaserGraphics.Computation.beams.Clear();
					global::LaserGraphics.Computation.dots.Clear();
					global::LaserGraphics.MeshBuffer.Reset();
				}
			}
		}
	}

	// Token: 0x06003E0F RID: 15887 RVA: 0x000DA9E0 File Offset: 0x000D8BE0
	private static global::UnityEngine.Color RangeBeamColor(global::UnityEngine.Color input)
	{
		float num;
		if (input.r > input.g)
		{
			if (input.b > input.r)
			{
				num = input.b;
			}
			else
			{
				num = input.r;
			}
		}
		else if (input.b > input.g)
		{
			num = input.b;
		}
		else
		{
			num = input.g;
		}
		if (num != 0f)
		{
			input.r /= num;
			input.g /= num;
			input.b /= num;
			input.a = num / 1f;
		}
		else
		{
			input.a = 1f;
		}
		return input;
	}

	// Token: 0x06003E10 RID: 15888 RVA: 0x000DAAB0 File Offset: 0x000D8CB0
	private static global::UnityEngine.Color RangeDotColor(global::UnityEngine.Color input)
	{
		float num;
		if (input.r > input.g)
		{
			if (input.b > input.r)
			{
				num = input.b;
			}
			else
			{
				num = input.r;
			}
		}
		else if (input.b > input.g)
		{
			num = input.b;
		}
		else
		{
			num = input.g;
		}
		if (num != 0f)
		{
			input.r /= num;
			input.g /= num;
			input.b /= num;
			input.a = num / 12f;
		}
		else
		{
			input.a = 0.083333336f;
		}
		return input;
	}

	// Token: 0x06003E11 RID: 15889 RVA: 0x000DAB80 File Offset: 0x000D8D80
	private static void RenderBeam(global::UnityEngine.Plane[] frustum, global::UnityEngine.Camera camera, global::LaserBeam beam, ref global::LaserBeam.FrameData frame)
	{
		global::UnityEngine.Vector3 vector = global::LaserGraphics.world2Cam.MultiplyPoint(frame.origin);
		global::UnityEngine.Vector3 vector2 = global::LaserGraphics.world2Cam.MultiplyPoint(frame.point);
		global::UnityEngine.Vector3 vector3 = vector2 - vector;
		vector3.Normalize();
		float num = 1f - (1f - global::UnityEngine.Mathf.Abs(vector3.z)) * beam.beamOutput;
		global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.LookRotation(vector3, vector2);
		global::UnityEngine.Quaternion quaternion2 = global::UnityEngine.Quaternion.LookRotation(vector3, vector);
		global::UnityEngine.Vector3 vector4 = quaternion2 * new global::UnityEngine.Vector3(frame.originWidth, 0f, 0f);
		global::UnityEngine.Vector3 vector5 = quaternion * new global::UnityEngine.Vector3(frame.pointWidth, 0f, 0f);
		frame.beamVertices.m0 = global::LaserGraphics.cam2World.MultiplyPoint(vector4 * 0.5f + vector);
		frame.beamVertices.m2 = global::LaserGraphics.cam2World.MultiplyPoint(vector5 * 0.5f + vector2);
		frame.beamVertices.m1 = global::LaserGraphics.cam2World.MultiplyPoint(vector4 * -0.5f + vector);
		frame.beamVertices.m3 = global::LaserGraphics.cam2World.MultiplyPoint(vector5 * -0.5f + vector2);
		frame.beamNormals.m0.x = frame.originWidth;
		frame.beamNormals.m2.x = frame.pointWidth;
		frame.beamNormals.m1.x = -frame.originWidth;
		frame.beamNormals.m3.x = -frame.pointWidth;
		frame.beamNormals.m0.y = -frame.distance;
		frame.beamNormals.m1.y = -frame.distance;
		frame.beamNormals.m2.y = -frame.distance;
		frame.beamNormals.m3.y = -frame.distance;
		frame.beamNormals.m0.z = (frame.beamNormals.m1.z = 0f);
		frame.beamNormals.m2.z = (frame.beamNormals.m3.z = frame.distanceFraction);
		frame.beamColor.m0 = (frame.beamColor.m1 = (frame.beamColor.m2 = (frame.beamColor.m3 = global::LaserGraphics.RangeBeamColor(beam.beamColor * num))));
		frame.beamUVs.m0 = global::LaserGraphics.uv[0];
		frame.beamUVs.m0.x = frame.beamUVs.m0.x * frame.distanceFraction;
		frame.beamUVs.m1 = global::LaserGraphics.uv[1];
		frame.beamUVs.m1.x = frame.beamUVs.m1.x * frame.distanceFraction;
		frame.beamUVs.m2 = global::LaserGraphics.uv[2];
		frame.beamUVs.m2.x = frame.beamUVs.m2.x * frame.distanceFraction;
		frame.beamUVs.m3 = global::LaserGraphics.uv[3];
		frame.beamUVs.m3.x = frame.beamUVs.m3.x * frame.distanceFraction;
		frame.bufBeam = global::LaserGraphics.MeshBuffer.ForBeamMaterial(beam.beamMaterial);
		if (global::LaserGraphics.Computation.beams.Add(frame.bufBeam))
		{
			frame.bufBeam.measureSize = 1;
		}
		else
		{
			frame.bufBeam.measureSize++;
		}
		frame.bufBeam.beams.Add(beam);
		if (frame.didHit)
		{
			global::UnityEngine.Vector3 vector6 = global::LaserGraphics.world2Cam.MultiplyVector(-frame.hitNormal);
			if (vector6.z < 0f)
			{
				global::UnityEngine.Vector3 vector7 = global::LaserGraphics.cam2World.MultiplyPoint(global::UnityEngine.Vector3.zero);
				if (!global::UnityEngine.Physics.Linecast(vector7, global::UnityEngine.Vector3.Lerp(vector7, frame.point, 0.95f), beam.cullLayers))
				{
					global::UnityEngine.Vector3 vector8 = global::LaserGraphics.world2Cam.MultiplyPoint(frame.point);
					global::UnityEngine.Quaternion quaternion3 = global::UnityEngine.Quaternion.LookRotation(vector8, global::UnityEngine.Vector3.up);
					frame.dotVertices1.m0 = global::LaserGraphics.cam2World.MultiplyPoint(vector8 + quaternion3 * new global::UnityEngine.Vector3(frame.dotRadius, -frame.dotRadius, 0f));
					frame.dotVertices1.m1 = global::LaserGraphics.cam2World.MultiplyPoint(vector8 + quaternion3 * new global::UnityEngine.Vector3(frame.dotRadius, frame.dotRadius, 0f));
					frame.dotVertices1.m2 = global::LaserGraphics.cam2World.MultiplyPoint(vector8 + quaternion3 * new global::UnityEngine.Vector3(-frame.dotRadius, -frame.dotRadius, 0f));
					frame.dotVertices1.m3 = global::LaserGraphics.cam2World.MultiplyPoint(vector8 + quaternion3 * new global::UnityEngine.Vector3(-frame.dotRadius, frame.dotRadius, 0f));
					quaternion3 = global::UnityEngine.Quaternion.LookRotation(vector6, global::UnityEngine.Vector3.up);
					frame.dotVertices2.m0 = global::LaserGraphics.cam2World.MultiplyPoint(vector8 + quaternion3 * new global::UnityEngine.Vector3(frame.dotRadius, -frame.dotRadius, -0.01f));
					frame.dotVertices2.m1 = global::LaserGraphics.cam2World.MultiplyPoint(vector8 + quaternion3 * new global::UnityEngine.Vector3(frame.dotRadius, frame.dotRadius, -0.01f));
					frame.dotVertices2.m2 = global::LaserGraphics.cam2World.MultiplyPoint(vector8 + quaternion3 * new global::UnityEngine.Vector3(-frame.dotRadius, -frame.dotRadius, -0.01f));
					frame.dotVertices2.m3 = global::LaserGraphics.cam2World.MultiplyPoint(vector8 + quaternion3 * new global::UnityEngine.Vector3(-frame.dotRadius, frame.dotRadius, -0.01f));
					frame.dotColor1.m0 = (frame.dotColor1.m1 = (frame.dotColor1.m2 = (frame.dotColor1.m3 = (frame.dotColor2.m0 = (frame.dotColor2.m1 = (frame.dotColor2.m2 = (frame.dotColor2.m3 = global::LaserGraphics.RangeDotColor(beam.dotColor))))))));
					frame.bufDot = global::LaserGraphics.MeshBuffer.ForDotMaterial(beam.dotMaterial);
					if (global::LaserGraphics.Computation.dots.Add(frame.bufDot))
					{
						frame.bufDot.measureSize = 2;
					}
					else
					{
						frame.bufDot.measureSize += 2;
					}
					frame.bufDot.beams.Add(beam);
					frame.drawDot = true;
				}
				else
				{
					frame.bufDot = null;
					frame.drawDot = false;
				}
			}
			else
			{
				frame.bufDot = null;
				frame.drawDot = false;
			}
		}
		else
		{
			frame.bufDot = null;
			frame.drawDot = false;
		}
	}

	// Token: 0x06003E12 RID: 15890 RVA: 0x000DB2F0 File Offset: 0x000D94F0
	internal static void RenderLasersOnCamera(global::UnityEngine.Camera camera)
	{
		if (global::LaserGraphics.singleton)
		{
			global::LaserGraphics.singleton.RenderLasers(camera);
		}
	}

	// Token: 0x04001F82 RID: 8066
	private const float kNormalPushBack = -0.01f;

	// Token: 0x04001F83 RID: 8067
	private const float kDotMaxAlpha = 12f;

	// Token: 0x04001F84 RID: 8068
	private const float kBeamMaxAlpha = 1f;

	// Token: 0x04001F85 RID: 8069
	private const string singletonName = "__LASER_GRAPHICS__";

	// Token: 0x04001F86 RID: 8070
	[global::System.NonSerialized]
	private global::System.Collections.Generic.List<global::LaserBeam> beams;

	// Token: 0x04001F87 RID: 8071
	[global::System.NonSerialized]
	private global::System.Collections.Generic.List<global::LaserBeam> willRender;

	// Token: 0x04001F88 RID: 8072
	private static int allBeamsMask;

	// Token: 0x04001F89 RID: 8073
	private static global::UnityEngine.Matrix4x4 world2Cam;

	// Token: 0x04001F8A RID: 8074
	private static global::UnityEngine.Matrix4x4 cam2World;

	// Token: 0x04001F8B RID: 8075
	private static global::UnityEngine.Matrix4x4 camProj;

	// Token: 0x04001F8C RID: 8076
	private static readonly global::UnityEngine.Vector2[] uv = new global::UnityEngine.Vector2[]
	{
		new global::UnityEngine.Vector2(0f, 0f),
		new global::UnityEngine.Vector2(0f, 1f),
		new global::UnityEngine.Vector2(1f, 0f),
		new global::UnityEngine.Vector2(1f, 1f)
	};

	// Token: 0x04001F8D RID: 8077
	[global::System.NonSerialized]
	private bool madeLists;

	// Token: 0x04001F8E RID: 8078
	private static global::LaserGraphics singleton;

	// Token: 0x0200072C RID: 1836
	internal class VertexBuffer
	{
		// Token: 0x06003E13 RID: 15891 RVA: 0x000DB30C File Offset: 0x000D950C
		private VertexBuffer(int quadCount)
		{
			this.quadCount = quadCount;
			this.vertexCount = quadCount * 4;
			if (this.vertexCount > 0)
			{
				this.v = new global::UnityEngine.Vector3[this.vertexCount];
				this.t = new global::UnityEngine.Vector2[this.vertexCount];
				this.n = new global::UnityEngine.Vector3[this.vertexCount];
				this.c = new global::UnityEngine.Color[this.vertexCount];
				this.i = new int[this.vertexCount];
			}
			for (int i = 0; i < this.vertexCount; i++)
			{
				this.i[i] = i;
			}
		}

		// Token: 0x06003E14 RID: 15892 RVA: 0x000DB3B0 File Offset: 0x000D95B0
		public static global::LaserGraphics.VertexBuffer Size(int i)
		{
			global::LaserGraphics.VertexBuffer result;
			if (!global::LaserGraphics.VertexBuffer.Register.all.TryGetValue(i, out result))
			{
				global::LaserGraphics.VertexBuffer.Register.all.Add(i, result = new global::LaserGraphics.VertexBuffer(i));
			}
			return result;
		}

		// Token: 0x04001F8F RID: 8079
		public readonly int quadCount;

		// Token: 0x04001F90 RID: 8080
		public readonly int vertexCount;

		// Token: 0x04001F91 RID: 8081
		public readonly global::UnityEngine.Vector3[] v;

		// Token: 0x04001F92 RID: 8082
		public readonly global::UnityEngine.Vector2[] t;

		// Token: 0x04001F93 RID: 8083
		public readonly global::UnityEngine.Vector3[] n;

		// Token: 0x04001F94 RID: 8084
		public readonly global::UnityEngine.Color[] c;

		// Token: 0x04001F95 RID: 8085
		public readonly int[] i;

		// Token: 0x0200072D RID: 1837
		private static class Register
		{
			// Token: 0x06003E15 RID: 15893 RVA: 0x000DB3E4 File Offset: 0x000D95E4
			// Note: this type is marked as 'beforefieldinit'.
			static Register()
			{
			}

			// Token: 0x04001F96 RID: 8086
			public static readonly global::System.Collections.Generic.Dictionary<int, global::LaserGraphics.VertexBuffer> all = new global::System.Collections.Generic.Dictionary<int, global::LaserGraphics.VertexBuffer>();
		}
	}

	// Token: 0x0200072E RID: 1838
	internal sealed class MeshBuffer : global::System.IDisposable, global::System.IEquatable<global::LaserGraphics.MeshBuffer>
	{
		// Token: 0x06003E16 RID: 15894 RVA: 0x000DB3F0 File Offset: 0x000D95F0
		private MeshBuffer(global::UnityEngine.Material material)
		{
			this.instanceID = material.GetInstanceID();
			this.mesh = new global::UnityEngine.Mesh
			{
				hideFlags = 4
			};
			this.mesh.MarkDynamic();
			this.material = material;
		}

		// Token: 0x06003E17 RID: 15895 RVA: 0x000DB440 File Offset: 0x000D9640
		public bool Resize()
		{
			return this.SetSize(this.measureSize);
		}

		// Token: 0x06003E18 RID: 15896 RVA: 0x000DB450 File Offset: 0x000D9650
		private bool SetSize(int size)
		{
			if (this.quadCount == size)
			{
				return false;
			}
			if (size == 0)
			{
				this.buffer = null;
			}
			else
			{
				this.buffer = global::LaserGraphics.VertexBuffer.Size(size);
			}
			this.quadCount = size;
			return true;
		}

		// Token: 0x06003E19 RID: 15897 RVA: 0x000DB494 File Offset: 0x000D9694
		public void Dispose()
		{
			if (this.mesh)
			{
				global::UnityEngine.Object.DestroyImmediate(this.mesh);
			}
		}

		// Token: 0x06003E1A RID: 15898 RVA: 0x000DB4B4 File Offset: 0x000D96B4
		public override int GetHashCode()
		{
			return this.instanceID;
		}

		// Token: 0x06003E1B RID: 15899 RVA: 0x000DB4BC File Offset: 0x000D96BC
		public override bool Equals(object obj)
		{
			return obj is global::LaserGraphics.MeshBuffer && this.instanceID == ((global::LaserGraphics.MeshBuffer)obj).instanceID;
		}

		// Token: 0x06003E1C RID: 15900 RVA: 0x000DB4E0 File Offset: 0x000D96E0
		public bool Equals(global::LaserGraphics.MeshBuffer buf)
		{
			return !object.ReferenceEquals(buf, null) && this.instanceID == buf.instanceID;
		}

		// Token: 0x06003E1D RID: 15901 RVA: 0x000DB500 File Offset: 0x000D9700
		private static global::LaserGraphics.MeshBuffer ForMaterial(global::System.Collections.Generic.Dictionary<global::UnityEngine.Material, global::LaserGraphics.MeshBuffer> all, global::UnityEngine.Material material)
		{
			global::LaserGraphics.MeshBuffer meshBuffer;
			if (!all.TryGetValue(material, out meshBuffer))
			{
				meshBuffer = new global::LaserGraphics.MeshBuffer(material);
				all.Add(material, meshBuffer);
			}
			return meshBuffer;
		}

		// Token: 0x06003E1E RID: 15902 RVA: 0x000DB52C File Offset: 0x000D972C
		public static global::LaserGraphics.MeshBuffer ForBeamMaterial(global::UnityEngine.Material material)
		{
			if (!global::LaserGraphics.MeshBuffer.Register.hasBeam || global::LaserGraphics.MeshBuffer.Register.lastBeam.material != material)
			{
				global::LaserGraphics.MeshBuffer.Register.lastBeam = global::LaserGraphics.MeshBuffer.ForMaterial(global::LaserGraphics.MeshBuffer.Register.beams, material);
				global::LaserGraphics.MeshBuffer.Register.hasBeam = true;
			}
			return global::LaserGraphics.MeshBuffer.Register.lastBeam;
		}

		// Token: 0x06003E1F RID: 15903 RVA: 0x000DB574 File Offset: 0x000D9774
		public static global::LaserGraphics.MeshBuffer ForDotMaterial(global::UnityEngine.Material material)
		{
			if (!global::LaserGraphics.MeshBuffer.Register.hasDot || global::LaserGraphics.MeshBuffer.Register.lastDot.material != material)
			{
				global::LaserGraphics.MeshBuffer.Register.lastDot = global::LaserGraphics.MeshBuffer.ForMaterial(global::LaserGraphics.MeshBuffer.Register.dots, material);
				global::LaserGraphics.MeshBuffer.Register.hasDot = true;
			}
			return global::LaserGraphics.MeshBuffer.Register.lastDot;
		}

		// Token: 0x06003E20 RID: 15904 RVA: 0x000DB5BC File Offset: 0x000D97BC
		public static void Reset()
		{
			global::LaserGraphics.MeshBuffer.Register.lastDot = (global::LaserGraphics.MeshBuffer.Register.lastBeam = null);
			global::LaserGraphics.MeshBuffer.Register.hasDot = (global::LaserGraphics.MeshBuffer.Register.hasBeam = false);
		}

		// Token: 0x06003E21 RID: 15905 RVA: 0x000DB5D8 File Offset: 0x000D97D8
		public void BindMesh(bool rebindVertexLayout, global::UnityEngine.Vector3 min, global::UnityEngine.Vector3 max)
		{
			if (rebindVertexLayout)
			{
				this.mesh.Clear(false);
				this.mesh.vertices = this.buffer.v;
				this.mesh.normals = this.buffer.n;
				this.mesh.colors = this.buffer.c;
				this.mesh.uv = this.buffer.t;
				this.mesh.SetIndices(this.buffer.i, 2, 0);
			}
			else
			{
				this.mesh.vertices = this.buffer.v;
				this.mesh.normals = this.buffer.n;
				this.mesh.colors = this.buffer.c;
				this.mesh.uv = this.buffer.t;
			}
			global::UnityEngine.Bounds bounds;
			bounds..ctor(global::UnityEngine.Vector3.zero, global::UnityEngine.Vector3.zero);
			bounds.SetMinMax(min, max);
			this.mesh.bounds = bounds;
		}

		// Token: 0x04001F97 RID: 8087
		public global::UnityEngine.Mesh mesh;

		// Token: 0x04001F98 RID: 8088
		public readonly global::UnityEngine.Material material;

		// Token: 0x04001F99 RID: 8089
		private int quadCount;

		// Token: 0x04001F9A RID: 8090
		internal global::LaserGraphics.VertexBuffer buffer;

		// Token: 0x04001F9B RID: 8091
		public int measureSize;

		// Token: 0x04001F9C RID: 8092
		private readonly int instanceID;

		// Token: 0x04001F9D RID: 8093
		public readonly global::System.Collections.Generic.List<global::LaserBeam> beams = new global::System.Collections.Generic.List<global::LaserBeam>();

		// Token: 0x0200072F RID: 1839
		private static class Register
		{
			// Token: 0x06003E22 RID: 15906 RVA: 0x000DB6EC File Offset: 0x000D98EC
			// Note: this type is marked as 'beforefieldinit'.
			static Register()
			{
			}

			// Token: 0x04001F9E RID: 8094
			public static readonly global::System.Collections.Generic.Dictionary<global::UnityEngine.Material, global::LaserGraphics.MeshBuffer> beams = new global::System.Collections.Generic.Dictionary<global::UnityEngine.Material, global::LaserGraphics.MeshBuffer>();

			// Token: 0x04001F9F RID: 8095
			public static readonly global::System.Collections.Generic.Dictionary<global::UnityEngine.Material, global::LaserGraphics.MeshBuffer> dots = new global::System.Collections.Generic.Dictionary<global::UnityEngine.Material, global::LaserGraphics.MeshBuffer>();

			// Token: 0x04001FA0 RID: 8096
			public static global::LaserGraphics.MeshBuffer lastBeam;

			// Token: 0x04001FA1 RID: 8097
			public static global::LaserGraphics.MeshBuffer lastDot;

			// Token: 0x04001FA2 RID: 8098
			public static bool hasBeam;

			// Token: 0x04001FA3 RID: 8099
			public static bool hasDot;
		}
	}

	// Token: 0x02000730 RID: 1840
	private static class Computation
	{
		// Token: 0x06003E23 RID: 15907 RVA: 0x000DB704 File Offset: 0x000D9904
		// Note: this type is marked as 'beforefieldinit'.
		static Computation()
		{
		}

		// Token: 0x04001FA4 RID: 8100
		public static readonly global::System.Collections.Generic.HashSet<global::LaserGraphics.MeshBuffer> beams = new global::System.Collections.Generic.HashSet<global::LaserGraphics.MeshBuffer>();

		// Token: 0x04001FA5 RID: 8101
		public static readonly global::System.Collections.Generic.HashSet<global::LaserGraphics.MeshBuffer> dots = new global::System.Collections.Generic.HashSet<global::LaserGraphics.MeshBuffer>();
	}
}
