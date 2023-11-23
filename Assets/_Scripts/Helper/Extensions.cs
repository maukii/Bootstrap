using System;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions 
{
    public static void Fade(this SpriteRenderer renderer, float alpha)
    {
        var color = renderer.color;
        color.a = alpha;
        renderer.color = color;
    }

    public static T GetRandom<T>(this IList<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }

    public static void DestroyChildren(this Transform transform)
    {
        for (var i = transform.childCount - 1; i >= 0; i--)
            UnityEngine.Object.Destroy(transform.GetChild(i).gameObject);
    }

    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : MonoBehaviour
    {
        var component = gameObject.GetComponent<T>();
        if (component == null) gameObject.AddComponent<T>();
        return component;
    }

    public static Vector2 GetClosestVector2From(this Vector2 vector, Vector2[] otherVectors)
    {
        if (otherVectors.Length == 0) 
            throw new Exception("The list of other vectors is empty");

        var minDistanceSquared = float.MaxValue;
        var minVector = otherVectors[0];

        foreach (var otherVector in otherVectors)
        {
            var direction = otherVector - vector;
            var distanceSquared = direction.sqrMagnitude;

            if (distanceSquared < minDistanceSquared)
            {
                minDistanceSquared = distanceSquared;
                minVector = otherVector;
            }
        }

        return minVector;
    }
}