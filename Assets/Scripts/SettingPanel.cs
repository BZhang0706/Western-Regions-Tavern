using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SettingPanel : MonoBehaviour
{
    public AudioSource[] BGMusicList;//背景音效
    public AudioSource[] EffectMusicList;//播放效果音效的组件
    public AudioSource[] RoleMusicValue;//播放人物语音的组件

    public CanvasGroup dialog;//对话框文本的透明度

    public float SpeedText = 10;//文本显示的速度
    public float AspeedText = 10;//文本自动跳转下一句的速度
    public float WinAlpha = 0.8F;//对话框文本的透明度
    public float zongMusic = 1f;//总音量
    public float BGMusic = 1f;//背景音效
    public float RoleMusic = 1f;//人物说话的音量
    public float EffectMusic = 1f;//效果音效的音量

    public List<Slider> SliderList;
   

    private void Update()
    {
        for (int i = 0; i < BGMusicList.Length; i++)
        {
            //循环便利 背景音效的 数组
            BGMusicList[i].volume = BGMusic * zongMusic;//背景音效的大小 等于 我们设置的背景音量大小 乘以 总音效

        }

        for (int i = 0; i < EffectMusicList.Length; i++) 
        {
            //循环便利 背景音效的 数组
            EffectMusicList[i].volume = EffectMusic * zongMusic;//效果音效的大小 等于 我们设置的效果音量大小 乘以 总音效

        }

        for (int i = 0; i < RoleMusicValue.Length; i++)
        {
            //循环便利 背景音效的 数组
            RoleMusicValue[i].volume = RoleMusic * zongMusic;//人物说话音效的大小 等于 我们设置的人物音量大小 乘以 总音效

        }

        dialog.alpha = WinAlpha;//把对话框文本的透明度赋值

        //machine.TextSpeed=SpeedText//设置 自动状态下的打字机速度

        UpdateSlider();//把滚动条里面的参数 赋值给 当前脚本上面的参数

    }

    public void UpdateSlider()
    {
        //把滚动条里面的参数 赋值给 当前脚本上面的参数

        SpeedText = SliderList[0].value;//把第一个滚动条的参数赋值给 文字速度
        AspeedText = SliderList[1].value;
        zongMusic = SliderList[2].value;
        BGMusic = SliderList[3].value;
        EffectMusic = SliderList[4].value;
        RoleMusic = SliderList[5].value;
    }

    private void Awake()
    {
        //判断当前是否又设置文件， 如果有 就读取设置文件里面的参数
        if(File.Exists(Application.persistentDataPath+"Setting"))//判断当前文件路径 是否有Setting的 文件
        {
            //如果 有 就执行 读取文件 并且解析文件里面的数据内容

        }
        else
        {
            //如果没有文件
            //SaveValue 存储文件的方法

        }

        SetValue ();//把数据赋值给滚动条的value值


    }


    public void SetValue()//把数据赋值给滚动条的value值
    {

        // SliderList[0].SpeedText = SpeedText;//把文字打印的速度 赋值给 第一个滚动条
        // SliderList[1].AspeedText = SpeedText; 
        // SliderList[2].zongMusic = SpeedText;
        // SliderList[3].BGMusic = SpeedText;
        // SliderList[4].EffectMusic = SpeedText;
        // SliderList[5].RoleMusic = SpeedText;

    }




}