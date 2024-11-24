using MudBlazor;
using System.Reflection.Metadata;

namespace ClariSKaraoke.Shared.Models
{
    public class SongData
    {
        public string Title { get; set; } // 曲名
        public int Model { get; set; } // 機種（1=JOY, 2=DAM, 3=JOY&DAM)
        public List<string> Number = new List<string>(); // 選曲番号(Number[1]=JOY, Number[2]=DAM)

        public SongData( string t, int m, params string[] n )
        {
            Title = t;
            Model = m;
            Number.Add( "" ); // Number[0] は 空にする
            foreach( string nl in n )
            {
                Number.Add( nl );
            }
        }
    }

    public class SongDataManager
    {
        private List<SongData> SongList = new List<SongData>();
        private int index = 0;

        public SongData? GetSongData( string number, int model )
        {
            try {
                var val = SongList.Where( x => x.Number.ElementAt( model ) == number );
                return ( val.First() );
            } catch ( Exception e ) {
                return ( null );
            }
        }

        public SongData GetSongDataRandom( int model )
        {
            while ((SongList[index].Model & model) == 0)
                ++index;
            return (SongList[index++]);
        }
        public void ResetIndex()
        {
            index = 0;

            for (int i = 0; i < 5000; ++i)
            {
                var index1 = new byte[4];
                var index2 = new byte[4];
                using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
                {
                    rng.GetBytes(index1);
                    rng.GetBytes(index2);
                }
                UInt32 idx1 = System.BitConverter.ToUInt32(index1, 0);
                UInt32 idx2 = System.BitConverter.ToUInt32(index2, 0);
                idx1 = idx1 % (UInt32)SongList.Count;
                idx2 = idx2 % (UInt32)SongList.Count;

                var tmp = SongList[(int)idx1];
                SongList[(int)idx1] = SongList[(int)idx2];
                SongList[(int)idx2] = tmp;
            }
        }

        public SongDataManager()
        {
            SongList.Add(new SongData("1/f", 1, "435059", ""));
            SongList.Add(new SongData("a moment", 3, "199450", "4733-41"));
            SongList.Add(new SongData("again", 3, "690270", "4733-90"));
            SongList.Add(new SongData("ALIVE", 3, "717248", "4739-29"));
            SongList.Add(new SongData("blossom", 3, "732475", "4733-46"));
            SongList.Add(new SongData("Blue Canvas", 3, "619379", "4739-39"));
            SongList.Add(new SongData("border", 3, "670196", "4733-77"));
            SongList.Add(new SongData("Brave", 2, "", "4739-17"));
            SongList.Add(new SongData("Butterfly Regret", 1, "697754", ""));
            SongList.Add(new SongData("Bye-Bye Butterfly", 1, "494322", ""));
            SongList.Add(new SongData("CheerS", 3, "431837", "4733-99"));
            SongList.Add(new SongData("Clear Sky", 3, "674473", "4733-81"));
            SongList.Add(new SongData("CLICK", 3, "761541", "4733-62"));
            SongList.Add(new SongData("Cloudy", 1, "423386", ""));
            SongList.Add(new SongData("Collage", 1, "699124", ""));
            SongList.Add(new SongData("distance", 1, "435163", ""));
            SongList.Add(new SongData("Don't cry", 3, "110932", "4733-35"));
            SongList.Add(new SongData("Drawing", 3, "312587", "4733-71"));
            SongList.Add(new SongData("Dreamin'", 3, "106279", "4733-12"));
            SongList.Add(new SongData("DROP", 2, "", "4739-28"));
            SongList.Add(new SongData("eternally", 3, "726248", "4733-51"));
            SongList.Add( new SongData( "Evergreen", 1, "631916", "" ) );
            SongList.Add(new SongData("Fairy Party", 3, "435186", "4739-19"));
            SongList.Add(new SongData("Fight!!", 3, "488834", "4739-16"));
            SongList.Add(new SongData("flowery", 3, "148627", "4733-05"));
            SongList.Add(new SongData("Friends", 3, "732476", "4733-45"));
            SongList.Add(new SongData("graduation", 3, "148622", "4733-02"));
            SongList.Add(new SongData("Gravity", 3, "686167", "4733-88"));
            SongList.Add(new SongData("HANABI", 3, "726263", "4733-55"));
            SongList.Add(new SongData("I'm in love", 3, "147668", "4733-15"));
            SongList.Add(new SongData("irony", 3, "701132", "4671-31"));
            SongList.Add(new SongData("Last Squall", 1, "435161", ""));
            SongList.Add(new SongData("Love is Mystery", 3, "627682", "4739-42"));
            SongList.Add(new SongData("Masquerade", 3, "610908", "4739-34"));
            SongList.Add(new SongData("Mermaid", 2, "", "4739-32"));
            SongList.Add(new SongData("missing you", 2, "", "4739-33"));
            SongList.Add(new SongData("NEN・DO・ROIDO", 3, "197121", "4733-26"));
            SongList.Add(new SongData("Neo Moon", 3, "109614", "4733-25"));
            SongList.Add(new SongData("next to you", 3, "736237", "4733-67"));
            SongList.Add(new SongData("nexus", 3, "29063", "3065-65"));
            SongList.Add(new SongData("Orange", 3, "431844", "4733-82"));
            SongList.Add(new SongData("pastel", 3, "424821", "4733-97"));
            SongList.Add(new SongData("Pieces", 3, "733315", "4733-61"));
            SongList.Add(new SongData("PRECIOUS", 2, "", "4739-21"));
            SongList.Add(new SongData("PRIMALove", 3, "426260", "4733-95"));
            SongList.Add(new SongData("Prism", 3, "679598", "4733-84"));
            SongList.Add(new SongData("rainy day", 3, "726262", "4733-58"));
            SongList.Add(new SongData("recall", 3, "699834", "4739-15"));
            SongList.Add(new SongData("Reflect", 1, "671270", ""));
            SongList.Add(new SongData("RESTART", 3, "313182", "4733-73"));
            SongList.Add(new SongData("reunion", 3, "723705", "4733-48"));
            SongList.Add(new SongData("second story", 3, "726149", "4733-53"));
            SongList.Add(new SongData("SECRET", 3, "431890", "4739-05"));
            SongList.Add(new SongData("SHIORI", 3, "698037", "4733-94"));
            SongList.Add(new SongData("STEP", 3, "736804", "4733-63"));
            SongList.Add(new SongData("Summer Delay", 3, "442549", "4739-07"));
            SongList.Add(new SongData("Surely", 3, "733314", "4733-60"));
            SongList.Add(new SongData("Tik Tak", 3, "725720", "4733-47"));
            SongList.Add(new SongData("Time", 3, "431842", "4733-91"));
            SongList.Add(new SongData("TRAVEL", 1, "435160", ""));
            SongList.Add(new SongData("treasure", 3, "148626", "4733-20"));
            SongList.Add(new SongData("Twinkle Twinkle", 2, "", "4739-24"));
            SongList.Add(new SongData("Wake Up", 3, "199137", "4733-34"));
            SongList.Add(new SongData("with you", 3, "726247", "4733-50"));
            SongList.Add(new SongData("YUMENOKI", 3, "431743", "4739-27"));
            SongList.Add(new SongData("zutto", 3, "148625", "4733-40"));
            SongList.Add(new SongData("アイデンティティ", 2, "", "4739-30"));
            SongList.Add(new SongData("アサガオ", 3, "627757", "4739-43"));
            SongList.Add(new SongData("アナタニFIT", 3, "110933", "4733-32"));
            SongList.Add(new SongData("アネモネ", 3, "675924", "4733-78"));
            SongList.Add(new SongData("アリシア", 3, "446519", "4739-12"));
            SongList.Add(new SongData("アワイ オモイ", 1, "431741", ""));
            SongList.Add(new SongData("アンダンテ", 3, "625896", "4739-41"));
            SongList.Add(new SongData("イロドリ", 1, "698851", ""));
            SongList.Add(new SongData("ウソツキ", 3, "699022", "4733-92"));
            SongList.Add(new SongData("かくれんぼ", 3, "431726", "4733-69"));
            SongList.Add(new SongData("カラフル", 3, "761535", "4733-59"));
            SongList.Add(new SongData("キミとふたり", 3, "109628", "4733-10"));
            SongList.Add(new SongData("グラスプ", 3, "726249", "4733-52"));
            SongList.Add(new SongData("ケアレス", 3, "493110", "4739-23"));
            SongList.Add(new SongData("コイセカイ", 3, "619284", "4739-38"));
            SongList.Add(new SongData("コイノミ", 3, "431843", "4733-79"));
            SongList.Add(new SongData("ココロの引力", 3, "105194", "3994-53"));
            SongList.Add(new SongData("コネクト", 3, "701133", "4049-06"));
            SongList.Add(new SongData("このiは虚数", 3, "424993", "4733-96"));
            SongList.Add(new SongData("サヨナラは言わない", 3, "148624", "4733-19"));
            SongList.Add(new SongData("シグナル", 3, "442896", "4739-10"));
            SongList.Add(new SongData("シニカルサスペンス", 3, "435159", "4739-14"));
            SongList.Add(new SongData("シルシ", 3, "736236", "4733-68"));
            SongList.Add(new SongData("スノーライト", 2, "", "4739-35"));
            SongList.Add(new SongData("セピア", 1, "431742", ""));
            SongList.Add(new SongData("ダイアリー", 3, "726264", "4733-54"));
            SongList.Add(new SongData("トパーズ", 3, "428866", "4733-87"));
            SongList.Add(new SongData("ドライフラワー", 3, "256413", "4733-70"));
            SongList.Add(new SongData("ドリームワールド", 3, "312808", "4733-83"));
            SongList.Add(new SongData("ナイショの話", 3, "702113", "3153-80"));
            SongList.Add(new SongData("ねがい", 1, "432534", ""));
            SongList.Add(new SongData("パラレルワープ", 1, "435162", ""));
            SongList.Add(new SongData("ハルラ", 3, "726261", "4733-56"));
            SongList.Add(new SongData("ひとつだけ", 3, "726265", "4733-57"));
            SongList.Add(new SongData("ヒトリゴト", 3, "694549", "4733-93"));
            SongList.Add(new SongData("ひらひら ひらら", 3, "697613", "4733-86"));
            SongList.Add(new SongData("ふぉりら", 3, "621758", "4739-40"));
            SongList.Add(new SongData("プロミス", 3, "148628", "4733-08"));
            SongList.Add(new SongData("ホログラム", 3, "693229", "4739-04"));
            SongList.Add(new SongData("ミントガム", 3, "725343", "4733-49"));
            SongList.Add(new SongData("メモリー", 3, "148629", "4733-30"));
            SongList.Add(new SongData("ユニゾン", 1, "447883", ""));
            SongList.Add(new SongData("ルミナス", 3, "32226", "4733-44"));
            SongList.Add(new SongData("仮面ジュブナイル", 2, "", "4739-22"));
            SongList.Add(new SongData("泣かないよ", 3, "199451", "4733-43"));
            SongList.Add(new SongData("桜咲く", 3, "314068", "4733-80"));
            SongList.Add(new SongData("新世界ビーナス", 2, "", "4739-31"));
            SongList.Add(new SongData("水色クラゲ", 1, "699833", ""));
            SongList.Add(new SongData("冬空花火", 3, "427712", "4739-06"));
            SongList.Add(new SongData("瞳の中のローレライ", 2, "", "4739-25"));
            SongList.Add(new SongData("本当は", 3, "147669", "4733-27"));
            SongList.Add(new SongData("眠り姫", 3, "428865", "4733-72"));
            SongList.Add(new SongData("陽だまり", 3, "435164", "4739-20"));
            SongList.Add(new SongData("恋磁石", 3, "148623", "4733-17"));
            SongList.Add(new SongData("メドレー1", 3, "148400", "4647-62"));
            SongList.Add(new SongData("メドレー2", 1, "314271", ""));

            ResetIndex();
        }
    }
}
