using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.Linq;

[System.Serializable]
public class StoryHistory
{
    public string character = "default";
    public CharacterData characterData = new CharacterData();
    public string text = "none";
    public string background = "default";
    public string eventname = "none";
    public string storyState = "none";
    public SoundDictionary soundDictionary = new SoundDictionary();

    [System.Serializable]
    public class CharacterData
    {
        public string expression = "default";
        public int slotIndex = 0;
        public string boxStyle = "default";
    }

    [System.Serializable]
    public class SoundDictionary
    {
        public List<SoundDataPair> soundDataPairs = new List<SoundDataPair>();

        [System.Serializable]
        public class SoundDataPair
        {
            public int track = 0;
            public string soundName = "none";

            public SoundDataPair(int track = 0, string soundName = "none")
            {
                this.track = track;
                this.soundName = soundName;
            }
        }
        public void AddSound(int track, string soundName)
        {
            // �����Ƿ��Ѵ��ڸ� track �� SoundDataPair
            var existingPair = soundDataPairs.Find(pair => pair.track == track);

            if (existingPair != null)
            {
                // ����ҵ������� soundName
                existingPair.soundName = soundName;
            }
            else
            {
                // ���û���ҵ��������µ� SoundDataPair
                soundDataPairs.Add(new SoundDataPair(track, soundName));
            }
        }
        public SoundDictionary DeepCopy()
        {
            SoundDictionary newDict = new SoundDictionary();
            foreach (SoundDataPair pair in this.soundDataPairs)
            {
                // ʹ��ÿ��SoundDataPair�Ŀ������캯��
                newDict.soundDataPairs.Add(new SoundDataPair(pair.track, pair.soundName));
            }
            return newDict;
        }
    }
}


public class StoryProgress
{
    public Stack<StoryHistory> storyHistories = new Stack<StoryHistory>();
    public Dictionary<string, StoryHistory.CharacterData> characterDatas = new Dictionary<string, StoryHistory.CharacterData>();


    // 当玩家想要后退时调用
    public bool LoadPreviousState(Story story)
    {
        if (storyHistories.Count <= 1) return false; // 保留初始状态，避免栈为空

        storyHistories.Pop(); // 移除当前状态
        string previousStateJson = storyHistories.Peek().storyState; // 查看上一个状态但不移除
        story.state.LoadJson(previousStateJson);
        return true;
    }

    public void LoadState(Story story) 
    {
        string StateJson = storyHistories.Peek().storyState;
        story.state.LoadJson(StateJson);
    }

}
[System.Serializable]
public class SavedStory
{
    public List<StoryHistory> histories = new List<StoryHistory>();
    public SerializablecharacterDataDictionary characterDatas = new SerializablecharacterDataDictionary();
    public string Level;

}



[System.Serializable]
public class SerializablecharacterDataDictionary
{
    [System.Serializable]
    public class SerializableCharacterDataPair
    {
        public string key;
        public StoryHistory.CharacterData value;

        public SerializableCharacterDataPair(string key, StoryHistory.CharacterData value)
        {
            this.key = key;
            this.value = value;
        }
    }

    public List<SerializableCharacterDataPair> keyValuePairs = new List<SerializableCharacterDataPair>();

    // 添加一个方法，用于将字典的数据添加到列表中
    public void FromDictionary(Dictionary<string, StoryHistory.CharacterData> dictionary)
    {
        keyValuePairs.Clear(); // 清空当前列表
        foreach (var kvp in dictionary)
        {
            keyValuePairs.Add(new SerializableCharacterDataPair(kvp.Key, kvp.Value));
        }
    }

    // 如果需要，也可以添加一个方法将这个结构转换回字典
    public Dictionary<string, StoryHistory.CharacterData> ToDictionary()
    {
        var dictionary = new Dictionary<string, StoryHistory.CharacterData>();
        foreach (var kvp in keyValuePairs)
        {
            dictionary[kvp.key] = kvp.value;
        }
        return dictionary;
    }
}
