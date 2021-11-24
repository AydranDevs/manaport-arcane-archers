using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SpellInfo {
    public string type;
    public string element;
}

public abstract class Spell : MonoBehaviour {
    public SpellInfo spellInfo;

    public virtual void Cast(Vector2 direction, string element) { }
}
