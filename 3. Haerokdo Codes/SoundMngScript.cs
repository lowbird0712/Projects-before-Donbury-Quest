﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMngScript : MonoBehaviour {
    static SoundMngScript   Inst { get; set; } = null;

    [SerializeField]
    AudioSource             mAudioSource = null;
    [SerializeField]
    AudioSource             mSubAudioSource = null;
    [SerializeField]
    AudioClip[]             mBGMs = null;
    [SerializeField]
    AudioClip[]             mEffects = null;

    private void Awake() => Inst = this;

	private void Start() {
        Inst.mAudioSource.loop = true;
        Inst.mSubAudioSource.loop = true;
	}

	static public void LoadSound(int _blockNum) {
        switch(_blockNum) {
            case 0:
                PlaySound("BGM", 0);
                break;
            case 1:
                PlaySound("BGM", 2);
                break;
		}
    }

    static public void PlaySound(string _type, int _index = -1, int _subIndex = -1) {
        if (_type == "BGM") {
            Inst.mAudioSource.Stop();
            Inst.mSubAudioSource.Stop();
            Inst.mAudioSource.clip = Inst.mBGMs[_index];
            Inst.mAudioSource.time = 0.0f;
            Inst.mAudioSource.Play();
            if (_subIndex != -1) {
                Inst.mSubAudioSource.clip = Inst.mBGMs[_subIndex];
                Inst.mSubAudioSource.time = 0.0f;
                Inst.mSubAudioSource.Play();
            }
        }
        else if (_type == "Sub BGM") {
            Inst.mSubAudioSource.Stop();
            Inst.mSubAudioSource.clip = Inst.mBGMs[_subIndex];
            Inst.mSubAudioSource.time = 0.0f;
            Inst.mSubAudioSource.Play();
        }
        else if (_type == "Stop All BGM") {
            Inst.mAudioSource.Stop();
            Inst.mSubAudioSource.Stop();
        }
        else if (_type == "Stop Sub BGM")
            Inst.mSubAudioSource.Stop();
        else if (_type == "Effect")
            Inst.mAudioSource.PlayOneShot(Inst.mEffects[_index]);
    }
}
