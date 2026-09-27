using System;
using UnityEngine;

[Serializable]
public class CoinHolder : MonoBehaviour
{
	public GUISkin UISkin;

	private float iPadQuarterFlyinOffsetX = 24.5f;

	private float iPadQuarterFlyinOffsetY = 16f;

	private float iPadQuarterFlyinOffsetZ;

	public static int triggerCoinHolderIn = -1;

	public static int triggerCoinHolderOut = -1;

	public static bool triggerCoin01;

	public static bool triggerCoin02;

	public static bool triggerCoin03;

	public static bool triggerCoin04;

	public static bool triggerCoinsLeftIn;

	public static bool triggerCoinHolderOutAll;

	public static bool triggerCoinsLeftAnim;

	public static bool coinTriggered;

	private int stateOffScreen = 10;

	private int stateSlidingOn = 20;

	private int stateOnScreen = 30;

	private int stateSlidingOff = 40;

	private int currentHolderState;

	private float holderOffScreenX;

	private float holderOffScreenX_iPhone = 60f;

	private float holderOffScreenX_iPad = -35f;

	private float holderOnScreenDeltaX;

	private float holderSlidingTimer;

	private float holderSlideTime = 0.3f;

	private int clStateOffScreen = 100;

	private int clStateSlidingOn = 200;

	private int clStateOnScreen = 300;

	private int clStateSlidingOff = 400;

	private int currentCoinsLeftState;

	private float coinsLeftOffScreenX = 0.3638867f;

	private float coinsLeftOnScreenDeltaX = -0.6f;

	private float coinsLeftSlidingTimer;

	private float coinsLeftSlideTime = 0.5f;

	private float coinsLeftOnScreenTime = 0.5f;

	private GameObject coinsLeftBarObject;

	private GameObject quarterFlyInObject;

	private bool quarterFlyInCheckAnim;

	private Renderer quarterFlyInRenderer;

	private string quarterFlyInAnimName;

	private float waitTime;

	public static int mainTextureWidth = 1024;

	public static int mainTextureHeight = 256;

	public static int digitTextureWidth = 64;

	public static int digitTextureHeight = 64;

	private Mesh score_01_mesh;

	private Vector3[] score_01_verts;

	private Vector2[] score_01_uv;

	private int[] score_01_tris;

	private Mesh score_02_mesh;

	private Vector3[] score_02_verts;

	private Vector2[] score_02_uv;

	private int[] score_02_tris;

	private Mesh score_03_mesh;

	private Vector3[] score_03_verts;

	private Vector2[] score_03_uv;

	private int[] score_03_tris;

	private Mesh score_04_mesh;

	private Vector3[] score_04_verts;

	private Vector2[] score_04_uv;

	private int[] score_04_tris;

	private Mesh coins_01_mesh;

	private Vector3[] coins_01_verts;

	private Vector2[] coins_01_uv;

	private int[] coins_01_tris;

	private Mesh coins_02_mesh;

	private Vector3[] coins_02_verts;

	private Vector2[] coins_02_uv;

	private int[] coins_02_tris;

	public static float widthU;

	public void Start()
	{
		triggerCoinHolderIn = triggerCoinHolderOut = -1;
		triggerCoinHolderOutAll = false;
		currentHolderState = stateOffScreen;
		if (GameManagerScript.is_iPad())
		{
			transform.localScale = GameManagerScript.iPadUIScale;
			Vector3 p = transform.localPosition;
			p.x = holderOffScreenX_iPad; p.y = GameManagerScript.iPadUIPosition.y; p.z = GameManagerScript.iPadUIPosition.z;
			transform.localPosition = p;
		}
		holderOffScreenX = transform.localPosition.x;
		coinsLeftBarObject = GameObject.Find("/ui_ingame_3coin_hold/coin_holder_top/coins_left");
		quarterFlyInObject = GameObject.Find("/ui_ingame_3coin_root/ui_ingame_3coin");
		quarterFlyInObject.animation.AddClip(quarterFlyInObject.animation.clip, "FlyIn1", 0, 20);
		quarterFlyInObject.animation.AddClip(quarterFlyInObject.animation.clip, "FlyIn2", 40, 60);
		quarterFlyInObject.animation.AddClip(quarterFlyInObject.animation.clip, "FlyIn3", 80, 100);
		for (int index = 0; index < 3; index++)
			GameObject.Find("/ui_ingame_3coin_root/ui_ingame_3coin/quarter_card_0" + (index + 1)).renderer.enabled = false;
		quarterFlyInCheckAnim = false;
		quarterFlyInRenderer = null;
		quarterFlyInAnimName = string.Empty;
		currentCoinsLeftState = clStateOffScreen;
		coinTriggered = false;
		widthU = (float)digitTextureWidth / mainTextureWidth;
		LoadMesh("/ui_ingame_3coin_hold/coin_holder_base/score_01", out score_01_mesh, out score_01_verts, out score_01_uv, out score_01_tris);
		LoadMesh("/ui_ingame_3coin_hold/coin_holder_base/score_02", out score_02_mesh, out score_02_verts, out score_02_uv, out score_02_tris);
		LoadMesh("/ui_ingame_3coin_hold/coin_holder_base/score_03", out score_03_mesh, out score_03_verts, out score_03_uv, out score_03_tris);
		LoadMesh("/ui_ingame_3coin_hold/coin_holder_base/score_04", out score_04_mesh, out score_04_verts, out score_04_uv, out score_04_tris);
		LoadMesh("/ui_ingame_3coin_hold/coin_holder_base/coins_01", out coins_01_mesh, out coins_01_verts, out coins_01_uv, out coins_01_tris);
		LoadMesh("/ui_ingame_3coin_hold/coin_holder_base/coins_02", out coins_02_mesh, out coins_02_verts, out coins_02_uv, out coins_02_tris);
	}

	public static void DisplayDigit(Mesh orig_mesh, Vector3[] orig_verts, Vector2[] orig_uv, int[] orig_tris, int digit)
	{
		Vector3[] vertices = (Vector3[])orig_verts.Clone();
		Vector2[] uv = (Vector2[])orig_uv.Clone();
		int[] triangles = (int[])orig_tris.Clone();
		orig_mesh.Clear();
		for (int index = 0; index < uv.Length; index++) uv[index].x += widthU * digit;
		orig_mesh.vertices = vertices;
		orig_mesh.uv = uv;
		orig_mesh.triangles = triangles;
	}

	public void HandleTextures(int score, int coinsLeft)
	{
		score = Mathf.Clamp(score, 0, 9999);
		coinsLeft = Mathf.Clamp(coinsLeft, 0, 99);
		Mesh[] scoreMeshes = { score_01_mesh, score_02_mesh, score_03_mesh, score_04_mesh };
		Vector3[][] scoreVerts = { score_01_verts, score_02_verts, score_03_verts, score_04_verts };
		Vector2[][] scoreUvs = { score_01_uv, score_02_uv, score_03_uv, score_04_uv };
		int[][] scoreTris = { score_01_tris, score_02_tris, score_03_tris, score_04_tris };
		for (int place = 0; place < 4; place++)
		{
			int divisor = (int)Mathf.Pow(10f, 3 - place);
			int digit = score / divisor % 10;
			GameObject digitObject = GameObject.Find("/ui_ingame_3coin_hold/coin_holder_base/score_0" + (place + 1));
			digitObject.renderer.enabled = place == 3 || score >= divisor;
			if (digitObject.renderer.enabled) DisplayDigit(scoreMeshes[place], scoreVerts[place], scoreUvs[place], scoreTris[place], digit);
		}
		Mesh[] coinMeshes = { coins_01_mesh, coins_02_mesh };
		Vector3[][] coinVerts = { coins_01_verts, coins_02_verts };
		Vector2[][] coinUvs = { coins_01_uv, coins_02_uv };
		int[][] coinTris = { coins_01_tris, coins_02_tris };
		for (int place = 0; place < 2; place++)
		{
			int divisor = place == 0 ? 10 : 1;
			GameObject digitObject = GameObject.Find("/ui_ingame_3coin_hold/coin_holder_base/coins_0" + (place + 1));
			digitObject.renderer.enabled = place == 1 || coinsLeft >= 10;
			if (digitObject.renderer.enabled) DisplayDigit(coinMeshes[place], coinVerts[place], coinUvs[place], coinTris[place], coinsLeft / divisor % 10);
		}
	}

	public void DisplayQuarters(int numQuarters)
	{
		for (int index = 0; index < 3; index++)
		{
			GameObject quarter = GameObject.Find("/ui_ingame_3coin_hold/quarter_card_0" + (index + 1));
			if (quarter) quarter.renderer.enabled = index < numQuarters;
		}
	}

	public void QuarterFlyIn(int quarterIndex)
	{
		if (quarterIndex < 0 || quarterIndex >= 3) return;
		GameObject quarter = GameObject.Find("/ui_ingame_3coin_root/ui_ingame_3coin/quarter_card_0" + (quarterIndex + 1));
		quarterFlyInRenderer = null;
		if (quarter) { quarterFlyInRenderer = quarter.renderer; quarterFlyInRenderer.enabled = true; }
		quarterFlyInAnimName = "FlyIn" + (quarterIndex + 1);
		quarterFlyInObject.animation.Play(quarterFlyInAnimName);
		quarterFlyInCheckAnim = true;
	}

	public void Update()
	{
		if (triggerCoinHolderIn >= 0)
		{
			HandleTextures(GameManagerScript.GetCurrentScore(), GameManagerScript.GetCurrentShotsLeft());
			DisplayQuarters(triggerCoinHolderIn); triggerCoinHolderIn = -1;
			currentHolderState = stateSlidingOn;
		}
		else if (triggerCoinHolderOut >= 0 || triggerCoinHolderOutAll)
		{
			if (quarterFlyInRenderer) { quarterFlyInRenderer.enabled = false; quarterFlyInRenderer = null; }
			triggerCoinHolderOut = -1; triggerCoinHolderOutAll = false;
			currentHolderState = stateSlidingOff;
		}
		else if (triggerCoin01) { QuarterFlyIn(0); triggerCoin01 = false; }
		else if (triggerCoin02) { QuarterFlyIn(1); triggerCoin02 = false; }
		else if (triggerCoin03) { QuarterFlyIn(2); triggerCoin03 = false; }
		else if (triggerCoinsLeftAnim)
		{
			triggerCoinsLeftAnim = false; currentCoinsLeftState = clStateSlidingOn;
		}

		if (quarterFlyInCheckAnim && !quarterFlyInObject.animation.IsPlaying(quarterFlyInAnimName))
		{
			if (quarterFlyInRenderer) { quarterFlyInRenderer.enabled = false; quarterFlyInRenderer = null; }
			DisplayQuarters(GameManagerScript.curMadeShotsThisRound + (QuarterTrigger.glassMultiplierTriggered ? 1 : 0));
			quarterFlyInCheckAnim = false;
		}

		float holderTarget = holderOffScreenX;
		if (currentHolderState == stateSlidingOn || currentHolderState == stateOnScreen)
			holderTarget += holderOnScreenDeltaX;
		if (currentHolderState == stateSlidingOn || currentHolderState == stateSlidingOff)
		{
			Vector3 p = transform.localPosition;
			p.x = Mathf.MoveTowards(p.x, holderTarget, Mathf.Abs(holderOnScreenDeltaX) / holderSlideTime * Time.deltaTime);
			transform.localPosition = p;
			if (p.x == holderTarget) currentHolderState = currentHolderState == stateSlidingOn ? stateOnScreen : stateOffScreen;
		}

		float coinsTarget = coinsLeftOffScreenX;
		if (currentCoinsLeftState == clStateSlidingOn || currentCoinsLeftState == clStateOnScreen)
			coinsTarget += coinsLeftOnScreenDeltaX;
		if (currentCoinsLeftState == clStateSlidingOn || currentCoinsLeftState == clStateSlidingOff)
		{
			Vector3 p = coinsLeftBarObject.transform.localPosition;
			p.x = Mathf.MoveTowards(p.x, coinsTarget, Mathf.Abs(coinsLeftOnScreenDeltaX) / coinsLeftSlideTime * Time.deltaTime);
			coinsLeftBarObject.transform.localPosition = p;
			if (p.x == coinsTarget)
			{
				currentCoinsLeftState = currentCoinsLeftState == clStateSlidingOn ? clStateOnScreen : clStateOffScreen;
				waitTime = Time.time;
			}
		}
		else if (currentCoinsLeftState == clStateOnScreen && Time.time - waitTime > coinsLeftOnScreenTime)
			currentCoinsLeftState = clStateSlidingOff;
	}

	public static void TriggerCoinIn(int coin)
	{
		if (coin == 0) triggerCoin01 = true;
		else if (coin == 1) triggerCoin02 = true;
		else if (coin == 2) triggerCoin03 = true;
		else if (coin == 3) triggerCoin04 = true;
		if (coin >= 0 && coin <= 3) coinTriggered = true;
	}

	public void Main()
	{
	}

	private static void LoadMesh(string path, out Mesh mesh, out Vector3[] vertices, out Vector2[] uv, out int[] triangles)
	{
		mesh = ((MeshFilter)GameObject.Find(path).GetComponent(typeof(MeshFilter))).mesh;
		vertices = mesh.vertices;
		uv = mesh.uv;
		triangles = mesh.triangles;
	}
}
