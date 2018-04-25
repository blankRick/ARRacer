using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class HelperFunctions {

    public const int HIT_BUFFER_SIZE = 20;
    public const int HIT_BUFFER_SIZE_SMALL = 5;
    public const float MIN_DISTANCE = 0.01f;
    public const float SCREEN_WIDTH = 11.0F;

    public static bool GetRandomBool() {
        int temp = Random.Range(0, 2);
        if(temp == 0)
            return true;
        else
            return false;
    }

    public static bool HasComponent<T>(this GameObject gameObject) {
        if(gameObject.GetComponent<T>() == null) {
            return false;
        }else {
            return true;
        }
    }

    public static bool HasComponent<T>(this Component component) {
        if(component.GetComponent<T>() == null) {
            return false;
        } else {
            return true;
        }
    }

    public static Vector3 Grounded(this Vector3 pos) {
        return new Vector3(pos.x, 0, pos.z);
    }

    public static Vector3 High(this Vector3 pos) {
        return new Vector3(pos.x, 5, pos.z);
    }

    public static T RandomEnumValue<T>() {
        var v = Enum.GetValues(typeof(T));
        return (T)v.GetValue(Random.Range(0, v.Length));
    }

    public static bool ChanceChecker(float chance) {
        float temp = UnityEngine.Random.Range(0.0f, 1.0f);
        if(temp < chance) {
            return true;
        } else {
            return false;
        }
    }

    public static T GetRandomFromList<T>(this List<T> list) {
        int random = Random.Range(0, list.Count);
        return list[random];
    }


}
