using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Database
{
    static public stats[] base_stats =
    {
        null,
        new stats(78, 42, 84, 78, 109, 85, 100),
        new stats(80, 50, 49, 49, 65, 65, 60),
        new stats(90, 30, 130, 80, 65, 85, 55),
        new stats(90, 50, 110, 80, 100, 80, 95),
        new stats(40, 22, 45, 45, 35, 35, 56),
        new stats(100, 25, 50, 35, 28, 35, 50),
        new stats(75, 30, 60, 25, 45, 30, 55),
        new stats(40, 20, 40, 30, 30, 30, 55),
        new stats(55, 20, 40, 65, 30, 30, 60),
        new stats(42, 20, 40, 55, 40, 45, 48),
        new stats(70, 45, 90, 55, 55, 55, 50),
        new stats(35, 30, 60, 44, 40, 54, 55),
        new stats(60, 32, 65, 34, 40, 34, 45),
        new stats(80, 42, 85, 95, 30, 30, 25),
        new stats(70, 45, 90, 70, 60, 70, 40),
        new stats(40, 25, 50, 90, 30, 55, 65),
        new stats(72, 40, 80, 49, 40, 49, 40),
        new stats(65, 35, 70, 60, 65, 65, 115),
        new stats(123, 50, 100, 62, 97, 81, 68),
        new stats(70, 60, 120, 40, 95, 40, 95),
        new stats(80, 35, 70, 65, 80, 120, 100),
        new stats(95, 65, 130, 80, 70, 80, 50),
        new stats(85, 52, 105, 100, 79, 83, 78),
        new stats(61, 61, 123, 60, 60, 50, 136),
        new stats(72, 47, 95, 67, 103, 71, 122),
        new stats(100, 50, 100, 90, 150,140, 90),
        new stats(100, 70, 140, 130, 140, 135, 45),
        new stats(90, 65, 130, 95, 73, 69, 77),
        new stats(95, 80, 120, 110, 80, 72, 56),
        new stats(98, 47, 95, 130, 67, 87, 80),
        new stats(84, 60, 120, 85, 63, 60, 105),
        new stats(130, 85, 80, 115, 170, 115, 148)
    };

    static public string[] names =
    {
        null,
        "プレイヤー",
        "カンナ",
        "ユウト",
        "ロサン",

        "トリ",
        "タカ",
        "オオカミ",
        "シキ",
        "ウシ",
        "ヒツジ",
        "ヒグマ",

        "ヘビ",
        "シシ",
        "サイ",
        "クモ",
        "サソリ",
        "ゾウ",
        "カラカル",
        "アダックス",

        "サメ",
        "クラゲ",
        "シロクマ",
        "ワニ",
        "カジキマグロ",
        "カエル",
        "クジラ",
        "エイ",

        "剣持ち",
        "魔法使い",
        "盾持ち",
        "警備員",
        "父親",
        // 33

    };

    static public List<List<skill.skillType>> weakTypes =
    new List<List<skill.skillType>>
    {
        null,
        new List<skill.skillType>{ skill.skillType.PIERCING },
        new List<skill.skillType>{ skill.skillType.BLUDGEONING },
        new List<skill.skillType>{ skill.skillType.POISON },
        new List<skill.skillType>{ skill.skillType.SLASHING },

        new List<skill.skillType>{ skill.skillType.PIERCING },
        new List<skill.skillType>{ skill.skillType.PIERCING },
        new List<skill.skillType>{ skill.skillType.SLASHING },
        new List<skill.skillType>{ skill.skillType.SLASHING },
        new List<skill.skillType>{ skill.skillType.POISON },
        new List<skill.skillType>{ skill.skillType.POISON },
        new List<skill.skillType>{ skill.skillType.PIERCING, skill.skillType.SLASHING },

        new List<skill.skillType>{ skill.skillType.PIERCING },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },

        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },

        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{ skill.skillType.PIERCING, skill.skillType.SLASHING },
    };

    static public List<List<skill.skillType>> resistanceTypes =
    new List<List<skill.skillType>>
    {
        null,
        new List<skill.skillType>{ skill.skillType.POISON },
        new List<skill.skillType>{ skill.skillType.SLASHING },
        new List<skill.skillType>{ skill.skillType.PIERCING },
        new List<skill.skillType>{ skill.skillType.BLUDGEONING },

        new List<skill.skillType>{ skill.skillType.BLUDGEONING },
        new List<skill.skillType>{ skill.skillType.BLUDGEONING },
        new List<skill.skillType>{ skill.skillType.PIERCING },
        new List<skill.skillType>{ skill.skillType.PIERCING },
        new List<skill.skillType>{ skill.skillType.BLUDGEONING },
        new List<skill.skillType>{ skill.skillType.BLUDGEONING },
        new List<skill.skillType>{ skill.skillType.POISON },

        new List<skill.skillType>{ skill.skillType.POISON },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },

        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },

        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{  },
        new List<skill.skillType>{ skill.skillType.BLUDGEONING, skill.skillType.POISON },
    };

    static public List<List<int[]>> learnable_skills =
    new List<List<int[]>>
    {
        null,
        new List<int[]>{ 
            new int[2] { 1, 0 }, 
            new int[2] { 1, 1 },
            new int[2] { 6, 2 },
            new int[2] { 10, 3 },
            new int[2] { 15, 4 },
            new int[2] { 21, 5 },
            new int[2] { 28, 6 },
            new int[2] { 37, 7 },
            new int[2] { 47, 8 },
            new int[2] { 58, 9 },
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },

        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
            },
        new List<int[]>{
            new int[2] { 1, 0 }
        },

        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },

        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },
        new List<int[]>{
            new int[2] { 1, 0 }
        },

        new List<int[]>{
            new int[2] { 1, 0 },
            new int[2] { 1, 1 },
        },
        new List<int[]>{
            new int[2] { 1, 0 },
            new int[2] { 1, 1 },
        },
        new List<int[]>{
            new int[2] { 1, 0 },
            new int[2] { 1, 1 },
        },
        new List<int[]>{
            new int[2] { 1, 0 },
            new int[2] { 1, 1 },
        },
        new List<int[]>{
            new int[2] { 1, 0 },
            new int[2] { 1, 1 },
            new int[2] { 6, 2 },
            new int[2] { 10, 3 },
            new int[2] { 15, 4 },
            new int[2] { 21, 5 },
            new int[2] { 28, 6 },
            new int[2] { 37, 7 },
            new int[2] { 47, 8 },
            new int[2] { 58, 9 },
        },
    };

    static public int[] exp_types =
    {
        0,
        0, 0, 1, 2,
        0, 2, 1, 2, 2, 1, 
        0, 0, 2, 2, 1, 1, 2, 1, 1,
        2, 0, 2, 2, 1, 1, 2, 1, 
        2, 2, 2, 2, 2
    };


    static public List<List<string>> lines_names =
    new List<List<string>>
    {
        new List<string>
        {
            "ＤＩＯ",
            "ＤＩＯ",
            "承太郎",
            "ＤＩＯ"
        },

        new List<string>
        {
            null,
            "ＤＩＯ",
        }
    };
    static public List<List<string>> lines_text = 
    new List<List<string>>
    {
        new List<string>
        {
            "ほう…向かってくるのか……逃げずにこのDIOに近づいて来るというのか…",
            "せっかく祖父のジョセフが私の「世界」の正体を、試験終了チャイム直前まで問題を解いている受験生のような必死こいた気分で教えてくれたというのに………",
            "近づかなきゃてめーをブチのめせないんでな………",
            "ほほお〜〜〜〜〜〜っ　では十分近づくがよい"
        },

        new List<string>
        {
            "テストテスト",
            "「世界」ッ!!",
        }
    };

    static public List<string> battle_text =
    new List<string>
    {
        "HPが満タンになった！",
        "使っても効果がないようだ！",
        "HPが回復された！",
    };

    static public List<List<unit>> enemy_info =
    new List<List<unit>>
    {
        new List<unit>
        {
            new unit(5, 2)
        },
        new List<unit>
        {
            new unit(5, 3)
        },
        new List<unit>
        {
            new unit(5, 2),
            new unit(5, 2)
        },
        new List<unit>
        {
            new unit(5, 3),
            new unit(5, 2)
        },
        new List<unit>
        {
            new unit(5, 3),
            new unit(5, 3)
        },
        new List<unit>
        {
            new unit(6, 3),
            new unit(7, 4)
        },
        new List<unit>
        {
            new unit(30, 60),
            new unit(32, 70),
            new unit(31, 60)
        }
    };

    static public List<skill> skill_data =
    new List<skill>
    {
        new skill(0, skill.skillClass.PHYSICAL, "つっつき", skill.skillType.PIERCING, 3, 35, 100, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(1, skill.skillClass.PHYSICAL, "つばさでうつ", skill.skillType.BLUDGEONING, 4, 45, 100, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(2, skill.skillClass.PHYSICAL, "ひっかき", skill.skillType.SLASHING, 4, 40, 100, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(3, skill.skillClass.PHYSICAL, "エアカッター", skill.skillType.SLASHING, 6, 60, 95, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(4, skill.skillClass.PHYSICAL, "かみつき", skill.skillType.PIERCING, 8, 60, 100, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(5, skill.skillClass.PHYSICAL, "かぎづめ", skill.skillType.SLASHING, 5, 50, 95, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(6, skill.skillClass.PHYSICAL, "つのつき", skill.skillType.PIERCING, 10, 70, 100, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(7, skill.skillClass.PHYSICAL, "もうとっしん", skill.skillType.BLUDGEONING, 8, 90, 85, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(8, skill.skillClass.PHYSICAL, "とっしん", skill.skillType.BLUDGEONING, 4, 40, 100, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(9, skill.skillClass.PHYSICAL, "もうれつパンチ", skill.skillType.BLUDGEONING, 12, 100, 90, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(10, skill.skillClass.PHYSICAL, "どくのきば", skill.skillType.POISON, 50, 100, 4, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(11, skill.skillClass.MAGICAL, "ヘドロばくだん", skill.skillType.ACID, 80, 70, 16, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(12, skill.skillClass.PHYSICAL, "どくのはり", skill.skillType.POISON, 30, 100, 4, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(13, skill.skillClass.PHYSICAL, "ふみつぶし", skill.skillType.BLUDGEONING, 65, 100, 12, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(14, skill.skillClass.PHYSICAL, "ダブルキック", skill.skillType.BLUDGEONING, 80, 100, 16, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(15, skill.skillClass.MAGICAL, "フレアハリケーン", skill.skillType.FIRE, 100, 100, 20, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(16, skill.skillClass.PHYSICAL, "かみくだき", skill.skillType.SLASHING, 80, 100, 10, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(17, skill.skillClass.PHYSICAL, "どくのしょくしゅ", skill.skillType.POISON, 100, 90, 4, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(18, skill.skillClass.PHYSICAL, "きりさき", skill.skillType.SLASHING, 80, 100, 10, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(19, skill.skillClass.PHYSICAL, "つきささり", skill.skillType.PIERCING, 75, 100, 7, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(20, skill.skillClass.PHYSICAL, "アクアブレード", skill.skillType.SLASHING, 180, 100, 13, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(21, skill.skillClass.MAGICAL, "ようかいえき", skill.skillType.ACID, 90, 70, 100, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(22, skill.skillClass.PHYSICAL, "からみつき", skill.skillType.BLUDGEONING, 65, 85, 5, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(25, skill.skillClass.PHYSICAL, "つらぬき", skill.skillType.PIERCING, 200, 20, 12, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(26, skill.skillClass.MAGICAL, "いと", skill.skillType.FORCE, 40, 95, 5, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(27, skill.skillClass.PHYSICAL, "きりばさみ", skill.skillType.SLASHING, 70, 100, 7, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(28, skill.skillClass.PHYSICAL, "はなたたき", skill.skillType.BLUDGEONING, 80, 75, 7, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(29, skill.skillClass.MAGICAL, "パウンスバイト", skill.skillType.ELECTRIC, 65, 100, 7, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(30, skill.skillClass.MAGICAL, "ほのおのあみ", skill.skillType.FIRE, 65, 85, 7, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(31, skill.skillClass.MAGICAL, "バブ（る）",skill.skillType.COLD, 65, 100, 8, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(32, skill.skillClass.STATUS, "つめをとぐ",skill.skillType.FORCE, 0, 100, 0, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(33, skill.skillClass.MAGICAL, "だくりゅう", skill.skillType.ACID, 90, 85, 9, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(34, skill.skillClass.MAGICAL, "ジェットふんしゃ",skill.skillType.ACID, 160, 100, 20, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(35, skill.skillClass.STATUS, "フォースフロー", skill.skillType.FORCE, 0, 100, 8, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(36, skill.skillClass.MAGICAL, "じしん", skill.skillType.FORCE, 100, 50, 8, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(37, skill.skillClass.MAGICAL, "ちょうおんぱ", skill.skillType.PSYCHIC, 75, 95, 9, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(38, skill.skillClass.STATUS, "みずたて", skill.skillType.FORCE, 0, 100, 10, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(39, skill.skillClass.MAGICAL, "じなり", skill.skillType.FORCE, 60, 100, 7, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(40, skill.skillClass.PHYSICAL, "こうそくアタック", skill.skillType.BLUDGEONING, 45, 90, 4, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(41, skill.skillClass.MAGICAL, "クロスファイアー", skill.skillType.FIRE, 150, 70, 14 ,new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(42, skill.skillClass.STATUS,"みがまえる", skill.skillType.FORCE, 0, 100, 8,new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(43, skill.skillClass.STATUS, "えいしょう", skill.skillType.FORCE, 0, 100, 8, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(44, skill.skillClass.MAGICAL, "ウェーブストーム", skill.skillType.FORCE, 80, 100, 8, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(45, skill.skillClass.STATUS, "うみのめぐみ", skill.skillType.PSYCHIC, 0, 100, 12, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(46, skill.skillClass.MAGICAL, "フレイムソード", skill.skillType.FIRE, 70, 100, 12, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(47, skill.skillClass.STATUS, "フェアリーサークル", skill.skillType.PSYCHIC, 0, 100, 25, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(48, skill.skillClass.STATUS, "ガードプレス", skill.skillType.PSYCHIC, 0, 100, 12, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(49, skill.skillClass.STATUS, "フェイタルカース", skill.skillType.PSYCHIC, 0, 100, 15, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(50, skill.skillClass.PHYSICAL, "スクリューソード", skill.skillType.SLASHING, 90, 90, 7, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(51, skill.skillClass.MAGICAL, "トゥウィンクルレーザー", skill.skillType.ELECTRIC, 50, 100, 6, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(52, skill.skillClass.PHYSICAL, "うらけん", skill.skillType.BLUDGEONING, 60, 100, 6, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(53, skill.skillClass.STATUS, "サイコパラライズ", skill.skillType.PSYCHIC, 0, 100, 10, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(54, skill.skillClass.PHYSICAL, "めつりゅうけん", skill.skillType.SLASHING, 120, 90, 10, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(55, skill.skillClass.MAGICAL, "エメラルドスター", skill.skillType.ELECTRIC, 75, 100, 7, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(56, skill.skillClass.PHYSICAL, "ラリアット", skill.skillType.BLUDGEONING, 300, 30, 10, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(57, skill.skillClass.MAGICAL, "フェニックスアロー", skill.skillType.FIRE, 100, 90, 9, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(58, skill.skillClass.PHYSICAL, "ばくさいけん", skill.skillType.SLASHING, 100, 100, 11, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(59, skill.skillClass.MAGICAL,"ノアクラビクル", skill.skillType.ELECTRIC, 45, 100, 5, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(60, skill.skillClass.PHYSICAL, "じごくづき", skill.skillType.PIERCING, 100, 70, 9, new List<skill.effect>(), new List<float>(), new List<float>()),
        new skill(61, skill.skillClass.MAGICAL, "アイシクルレイン", skill.skillType.COLD, 120, 80, 10, new List<skill.effect>(), new List<float>(), new List<float>()),


        new skill(99, skill.skillClass.STATUS, "「世界」", skill.skillType.FORCE, 100, 0, 100,
            new List<skill.effect>(){ skill.effect.RaiseAttack, skill.effect.RaiseDefence, skill.effect.RaiseMagicAttack, skill.effect.RaiseMagicDefense, skill.effect.RaiseSpeed },
            new List<float>(){ 2, 2, 2, 2, 2 },
            new List<float>(){ 100, 100, 100, 100, 100 }),
    };

    
}
