using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMake : MonoBehaviour
{
    public List<string> bonusMessage1;
    // Start is called before the first frame update
    void Start()
    {
        bonusMessage1 = new List<string>
        {
            "かじられたリンゴ、まだカップめんには勝てない重さ。",
            "バナナは、豆腐パックよりもしっかりした重さ。",
            "エビフライは、もやし1本よりはるかに重たい。",
            "モモンガはメスフラスコよりも軽やか。",
            "かに缶、ぞうきんよりずっしりした存在感。",
            "そろばんは、日食グラスよりも確実に重い。",
            "トースト、虎の巻には到底かなわない軽さ。",
            "アルコールランプは、メスフラスコよりちょっと重い。",
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
