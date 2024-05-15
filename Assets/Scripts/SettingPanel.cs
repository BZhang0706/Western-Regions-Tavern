using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SettingPanel : MonoBehaviour
{
    public AudioSource[] BGMusicList;//������Ч
    public AudioSource[] EffectMusicList;//����Ч����Ч�����
    public AudioSource[] RoleMusicValue;//�����������������

    public CanvasGroup dialog;//�Ի����ı���͸����

    public float SpeedText = 10;//�ı���ʾ���ٶ�
    public float AspeedText = 10;//�ı��Զ���ת��һ����ٶ�
    public float WinAlpha = 0.8F;//�Ի����ı���͸����
    public float zongMusic = 1f;//������
    public float BGMusic = 1f;//������Ч
    public float RoleMusic = 1f;//����˵��������
    public float EffectMusic = 1f;//Ч����Ч������

    public List<Slider> SliderList;
   

    private void Update()
    {
        for (int i = 0; i < BGMusicList.Length; i++)
        {
            //ѭ������ ������Ч�� ����
            BGMusicList[i].volume = BGMusic * zongMusic;//������Ч�Ĵ�С ���� �������õı���������С ���� ����Ч

        }

        for (int i = 0; i < EffectMusicList.Length; i++) 
        {
            //ѭ������ ������Ч�� ����
            EffectMusicList[i].volume = EffectMusic * zongMusic;//Ч����Ч�Ĵ�С ���� �������õ�Ч��������С ���� ����Ч

        }

        for (int i = 0; i < RoleMusicValue.Length; i++)
        {
            //ѭ������ ������Ч�� ����
            RoleMusicValue[i].volume = RoleMusic * zongMusic;//����˵����Ч�Ĵ�С ���� �������õ�����������С ���� ����Ч

        }

        dialog.alpha = WinAlpha;//�ѶԻ����ı���͸���ȸ�ֵ

        //machine.TextSpeed=SpeedText//���� �Զ�״̬�µĴ��ֻ��ٶ�

        UpdateSlider();//�ѹ���������Ĳ��� ��ֵ�� ��ǰ�ű�����Ĳ���

    }

    public void UpdateSlider()
    {
        //�ѹ���������Ĳ��� ��ֵ�� ��ǰ�ű�����Ĳ���

        SpeedText = SliderList[0].value;//�ѵ�һ���������Ĳ�����ֵ�� �����ٶ�
        AspeedText = SliderList[1].value;
        zongMusic = SliderList[2].value;
        BGMusic = SliderList[3].value;
        EffectMusic = SliderList[4].value;
        RoleMusic = SliderList[5].value;
    }

    private void Awake()
    {
        //�жϵ�ǰ�Ƿ��������ļ��� ����� �Ͷ�ȡ�����ļ�����Ĳ���
        if(File.Exists(Application.persistentDataPath+"Setting"))//�жϵ�ǰ�ļ�·�� �Ƿ���Setting�� �ļ�
        {
            //��� �� ��ִ�� ��ȡ�ļ� ���ҽ����ļ��������������

        }
        else
        {
            //���û���ļ�
            //SaveValue �洢�ļ��ķ���

        }

        SetValue ();//�����ݸ�ֵ����������valueֵ


    }


    public void SetValue()//�����ݸ�ֵ����������valueֵ
    {

        // SliderList[0].SpeedText = SpeedText;//�����ִ�ӡ���ٶ� ��ֵ�� ��һ��������
        // SliderList[1].AspeedText = SpeedText; 
        // SliderList[2].zongMusic = SpeedText;
        // SliderList[3].BGMusic = SpeedText;
        // SliderList[4].EffectMusic = SpeedText;
        // SliderList[5].RoleMusic = SpeedText;

    }




}