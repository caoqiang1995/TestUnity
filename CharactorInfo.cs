using UnityEngine;
using System.Collections;

public class CharactorInfo  {
    public int Level { get; set; }
    public int Hp { get; set; }
    public CharactorInfo() {
        Level = 0;
        Hp = 0;
    }
    public CharactorInfo(int level, int hp) {
        Level = level;
        Hp = hp;
    }
}
