using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusMake : MonoBehaviour
{
    private string[] objectNames;
    private string bonusMessage;

    public Text bonusText;

    public List<string> bonusMessage1;
    public List<string> bonusMessage2;
    public List<string> bonusMessage3;

    // Start is called before the first frame update
    void Start()
    {
        bonusMessage1 = new List<string>
        {
            "かじられたリンゴ、" +
            "まだカップめんには勝てない重さ。",
            "バナナは、豆腐パックよりもしっかりした重さ。",
            "エビフライは、もやし1本よりはるかに重たい。",
            "モモンガはメスフラスコよりも軽やか。",
            "かに缶、ぞうきんよりずっしりした存在感。",
            "そろばんは、日食グラスよりも確実に重い。",
            "トースト、虎の巻には到底かなわない軽さ。",
            "アルコールランプは、メスフラスコよりちょっと重い。",
            "かじられたリンゴより、" +
            "カップめんのほうがずっしりと腹に溜まる。",
            "そろばんは計算できるけど、" +
            "ぞうきんの方が軽くて扱いやすいよ。",
            "バナナの栄養価も高いけど、" +
            "トーストの軽さには敵わないね。",
            "モモンガのふわふわな軽さに比べたら、" +
            "メスフラスコの精密さが重く感じる。",
            "もやし(1本)の軽さはりんごに比べて、" +
            "まるで羽のようだね。",
            "豆腐パックの中身はぷるぷるだけど、" +
            "虎の巻の重みは知識の詰まり具合次第。",
            "かに缶は中身がぎっしりだけど、" +
            "エビフライのサクサク感は軽さが勝ち。",
        };

        bonusMessage2 = new List<string>
        {
            "ゲーミングPCを持ち運ぶ？アライグマに任せると、" +
            "ちょっとしたトレーニングだね。",
            "タブレットの重さと比べると、" +
            "えび天丼はヘルシーに見えるかも？",
            "ねこは軽いけど、ドームカバーの中に隠れたら" +
            "出てこない重さだよ。",
            "釜めしの釜の熱も凄いけど、" +
            "ヒートガンの熱には負けるかな？",
            "占いの水晶が未来を見せてくれるけど、" +
            "製麺機の重さで現実を感じるね。",
            "電流計が精密でも、" +
            "電工ドラムの重さには勝てないよ。",
            "木製たらいの重さを感じたら、" +
            "アライグマでも入りたがるかもね。",
            "アライグマとゲーミングPC、どっちが重いかって？" +
            "アライグマは軽いフットワークだよ！",
            "えび天丼の方が軽いけど、" +
            "タブレットの方が長持ちする" +
            "…腹持ちの話ね。",
            "ドームカバーは大きいけど、" +
            "ねこのほうが気軽に持ち上げられる。",
            "ヒートガンと釜めしの釜、" +
            "どっちも重さはあるけど、使い道が全然違うよね。",
            "牛乳(ビン)と三角停止板、どっちも重要だけど、" +
            "重さは牛乳が勝ち！",
            "錠の重さも気になるけど、" +
            "生ハム原木を抱える方が大仕事かも。",
            "製麺機の重さに比べたら、占いの水晶は" +
            "ずいぶん軽やかに未来が見えるね。",
            "電工ドラムの方が重いけど、" +
            "電流計の数値の重みも侮れない。",
            "木製たらいが重いって？" +
            "アライグマはその中でくつろぎたいんじゃない？"
        };

        bonusMessage3 = new List<string>
        {
            "アルパカはもふもふだけど、" +
            "ビールケースの重さには敵わないね。",
            "タケノコ(小さめ)と比べると、" +
            "うまの重さはまさに桁違い！",
            "ゴマフアザラシが水中で軽やかでも、" +
            "消波ブロックほどの重さはないね。",
            "生まれたての子鹿としかを比べると、" +
            "重さは親譲りの差があるね。",
            "タケノコ(小さめ)と黒板、" +
            "授業に役立つのは黒板だけど、" +
            "軽いのはタケノコ。",
            "ポストはしっかり重いけど、" +
            "パンダが座ったらそれ以上だよ。",
            "モルモットは小さくて軽いけど、" +
            "ビールケースを持つには力が要るよ。",
            "プテラノドンは空を飛ぶけど、" +
            "重さは黒毛和牛に劣らないかもね。",
            "レッサーパンダとヘラジカ、" +
            "どっちが重いかなんて一目瞭然！",
            "消波ブロックも重いけど、" +
            "ポストを運ぶのもなかなかの労働だね。",
            "しかも大きいけど、" +
            "ホッキョクグマの重さにはかなわない。",
            "モルモットの軽さは、" +
            "プテラノドンの翼の重みとは正反対だね。",
            "レッサーパンダのかわいさと重さ、" +
            "タケノコ(小さめ)には到底勝てない。",
            "黒板の重さを感じたら、" +
            "パンダの体重が何倍もあることを思い出して。",
            "黒毛和牛とビールケース、牛の方が重いけど、" +
            "どちらも手に入れると嬉しいよね。",
            "消波ブロックを持ち上げるのは大変だけど、" +
            "うまに乗ったらもっと大変かも？",
            "生まれたての子鹿は軽いけど、" +
            "ホッキョクグマにはまだまだ届かない。",
            "アルパカの重さは見た目通り、" +
            "ゴマフアザラシのしっとりした体重に近いかも？",
            "ポストも重いけど、" +
            "ヘラジカに比べたらまだ軽い方だね。",
            "パンダの重さと黒毛和牛、" +
            "どちらもボリューム満点だよね。"
        };

        objectNames = ObjectPlacer.objectNames;
        searchWord(ObjectPlacer.listSelect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void searchWord(int num)
    {
        int rand = Random.Range(0, objectNames.Length); //出てるオブジェクトの中からランダムで選出
        Debug.Log("Num :" + num);
        List<string> pMessage;
        pMessage = new List<string>();

        switch (num)
        {
            case 1:
                pMessage = new List<string>(bonusMessage1);
                break;
            case 2:
                pMessage = new List<string>(bonusMessage2);
                break;
            case 3:
                pMessage = new List<string>(bonusMessage3);
                break;
            default:
                //Debug.LogWarning("Unexpected value for num: " + num);  // エラーメッセージを表示
                break;
        }

        List<string> matchTexts = new List<string>();

        for (int i = 0; i < pMessage.Count; i++)
        {
            //Debug.Log(pMessage[i]);
            //Debug.Log(objectNames[rand]);

            //int strLength = pMessage[i].Length;


            if (pMessage[i].Contains(objectNames[rand]))
            {
                bonusMessage =  pMessage[i];
                //Debug.Log(bonusMessage);
                matchTexts.Add(bonusMessage);
            }
        }

        int selectText = Random.Range(0, matchTexts.Count);
        //Debug.Log(selectText);
        bonusText.text = matchTexts[selectText];
        if(matchTexts.Count == 0)
        {
            bonusText.text = "重さを当てるのって案外難しいよね";
        }

    }
}
