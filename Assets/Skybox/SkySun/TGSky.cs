using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class TGSky : MonoBehaviour
{
    [Header("------ Components")]
    public Light myLight;
    public Material skyMaterial;
    public ReflectionProbe probe;
    public AnimationCurve lightAngleCurve;

    [Header("------ Setup")]
    [Range(0, 24)] public float hour;
    [Range(-90, 90)] public float longitude;
    [Range(2, 22)] public float nightDuration = 12;
    public float dayMinutesDuration = 10;
    public bool animate;

#if UNITY_EDITOR
    [Header("------ Colors")]
    [SerializeField] private Color nightColor;
    [SerializeField] private Color dayColor;
    [SerializeField] private Color dawnColor;
#endif
    public Gradient gradientColor;

    [Header("------ State")]
    public bool isNight;
    public float intensity;

    private Color lightColor;
    private float lastHour = -1;
    private float lastLongitude = 1000;
    private int probeRenderID = -1;
    private float gray;
    private float hourEval;
    private Transform mainCamera;
    private float t = 0;
    private float dt = 0;

#if UNITY_EDITOR
    private float lastNightDuration = -1;
#endif

    //--------------------------------------------------------------------------
    void Start()
    {

    }

    //--------------------------------------------------------------------------
    private void OnEnable()
    {
        mainCamera = Camera.main.transform;
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Trilight;
        RenderSettings.sun = myLight;
        RenderSettings.skybox = skyMaterial;
        RenderSettings.defaultReflectionResolution = probe.resolution;
        RenderSettings.defaultReflectionMode = UnityEngine.Rendering.DefaultReflectionMode.Custom;
        RenderSettings.customReflection = new Cubemap(probe.resolution, TextureFormat.RGBA32, true);
        probeRenderID = probe.RenderProbe();
#if UNITY_EDITOR
        lastNightDuration = -1;
#endif
    }

    //--------------------------------------------------------------------------
    public void Update()
    {
#if UNITY_EDITOR
        if (Application.isPlaying == false && lastNightDuration == nightDuration && lastHour == hour && lastLongitude == longitude)
        {
            return;
        }

        if (lastNightDuration != nightDuration)
        {
            lastNightDuration = nightDuration;
            UpdateGradients();
        }
#endif
        lastHour = hour;
        lastLongitude = longitude;
        dt = Time.deltaTime;

        if (animate && Application.isPlaying)
        {
            hour += dt * 24.0f / (60 * dayMinutesDuration);
        }

        if (hour > 24) hour -= 24;

        isNight = hour < nightDuration / 2 || hour > 24 - (nightDuration / 2);

        hourEval = lightAngleCurve.Evaluate(hour);

        myLight.transform.position = mainCamera.position;
        myLight.transform.localEulerAngles = new Vector3(hourEval, 0, 0);
        myLight.transform.Rotate(Vector3.up, longitude);

        if (hour > 12)
        {
            myLight.transform.localEulerAngles = new Vector3(myLight.transform.localEulerAngles.x, myLight.transform.localEulerAngles.y + 180, 0);
            myLight.transform.localEulerAngles = new Vector3(myLight.transform.localEulerAngles.x, -myLight.transform.localEulerAngles.y, 0);
        }

        lightColor = gradientColor.Evaluate(hour / 24.0f);
        myLight.color = lightColor;

        gray = lightColor.grayscale;

        RenderSettings.ambientIntensity = gray;
        skyMaterial.SetFloat("_Exposure", gray * 1.3f);
        skyMaterial.SetColor("_SkyTint", lightColor);
        skyMaterial.SetColor("_GroundColor", lightColor * 0.5f);

        myLight.shadows = isNight ? LightShadows.None : LightShadows.Soft;
        myLight.shadowStrength = gray;

        RenderSettings.ambientSkyColor = lightColor * 0.85f;
        RenderSettings.ambientEquatorColor = lightColor * 0.5f;
        RenderSettings.ambientGroundColor = lightColor * 0.015f;

        intensity = isNight ? 0 : gray;

        //always update probe when dawn
        t = intensity > 0 && intensity < 1 ? 1 : t + dt;

        if (probe.IsFinishedRendering(probeRenderID) && t >= 1)
        {
            t = 0;
            Graphics.CopyTexture(probe.texture, RenderSettings.customReflection as Cubemap);
            probeRenderID = probe.RenderProbe();
        }
    }

#if UNITY_EDITOR
    //--------------------------------------------------------------------------
    public void UpdateGradients()
    {
        //light color --------
        GradientColorKey[] gradientColorKeys = new GradientColorKey[6];
        gradientColorKeys[0].color = nightColor;
        gradientColorKeys[1].color = dawnColor;
        gradientColorKeys[2].color = dayColor;
        gradientColorKeys[3].color = dayColor;
        gradientColorKeys[4].color = dawnColor;
        gradientColorKeys[5].color = nightColor;

        float startHour = nightDuration / 48.0f;

        float dawnTime = 1.5f / 24.0f / 2.0f; //1 hour

        gradientColorKeys[0].time = startHour;
        gradientColorKeys[1].time = startHour + dawnTime;
        gradientColorKeys[2].time = startHour + (dawnTime * 2);
        gradientColorKeys[3].time = (1 - startHour) - (dawnTime * 2);
        gradientColorKeys[4].time = (1 - startHour) - dawnTime;
        gradientColorKeys[5].time = (1 - startHour);

        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0].alpha = 1;
        alphaKeys[0].time = 0;
        alphaKeys[1].alpha = 1;
        alphaKeys[1].time = 1;

        gradientColor = new Gradient
        {
            colorKeys = gradientColorKeys,
            alphaKeys = alphaKeys
        };

        //light angle --------
        Keyframe[] keys = lightAngleCurve.keys;
        keys[1].time = nightDuration / 2;
        keys[3].time = 24 - nightDuration / 2;
        lightAngleCurve.keys = keys;

        for (int i = 0; i < lightAngleCurve.keys.Length; i++)
        {
            AnimationUtility.SetKeyBroken(lightAngleCurve, i, true);
            AnimationUtility.SetKeyLeftTangentMode(lightAngleCurve, i, AnimationUtility.TangentMode.Linear);
            AnimationUtility.SetKeyRightTangentMode(lightAngleCurve, i, AnimationUtility.TangentMode.Linear);
        }
    }
#endif
}
