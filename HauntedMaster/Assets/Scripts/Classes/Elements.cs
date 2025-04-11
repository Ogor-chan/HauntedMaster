using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Element
{
    fire,
    water,
    earth,
    wind,
    neutral
}
public class Elements
{
    private static readonly Dictionary<(Element, Element), float> _typeEffectiveness = new Dictionary<(Element, Element), float>
    {
        {(Element.fire, Element.earth), 1.0f},
        {(Element.fire, Element.water), 2f},
        {(Element.fire, Element.fire), 1.0f},
        {(Element.fire, Element.wind), 0.5f},

        {(Element.water, Element.fire), 2.0f},
        {(Element.water, Element.earth), 0.5f},
        {(Element.water, Element.water), 1.0f},
        {(Element.water, Element.wind), 1.0f},

        {(Element.earth, Element.water), 2.0f},
        {(Element.earth, Element.fire), 0.5f},
        {(Element.earth, Element.earth), 1.0f},
    };

    public static float GetEffectiveness(Element attackElement, Element targetElement)
    {
        if (_typeEffectiveness.ContainsKey((attackElement, targetElement)))
        {
            return _typeEffectiveness[(attackElement, targetElement)];
        }
        else
        {
            return 1.0f;
        }
    }
}
