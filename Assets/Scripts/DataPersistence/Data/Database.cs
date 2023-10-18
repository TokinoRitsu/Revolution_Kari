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

        new skill(99, skill.skillClass.STATUS, "「世界」", skill.skillType.FORCE, 100, 0, 100,
            new List<skill.effect>(){ skill.effect.RaiseAttack, skill.effect.RaiseDefence, skill.effect.RaiseMagicAttack, skill.effect.RaiseMagicDefense, skill.effect.RaiseSpeed },
            new List<float>(){ 2, 2, 2, 2, 2 },
            new List<float>(){ 100, 100, 100, 100, 100 }),
    };

    
}
