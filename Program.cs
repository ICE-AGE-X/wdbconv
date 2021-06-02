using System;
using System.IO;
using System.Text;
namespace wdbconv
{
    class Program
    {

        struct WDBHeader
        {
            public char[] signatrue;
            public int version;
            public char[] language;
            public int unk1;
            public int unk2;

            public WDBHeader(BinaryReader br)
            {
                this.signatrue = br.ReadChars(4);
                this.version = br.ReadInt32();
                this.language = br.ReadChars(4);
                this.unk1 = br.ReadInt32();
                this.unk2 = br.ReadInt32();
            }
        }


        class QuestInfo
        {
            uint questId;
            uint entryLength;
            ////
            int unk0;
            int unk1;
            int level;
            int area;
            int infoId;
            int unk2;
            int unk3;
            int unk4;
            int unk5;
            int nextQuestID;
            int coins;
            int substitudeExp;
            int spellReward;
            int startingItemID;
            int questFlags;
            int givenItem1;
            int givenItem1Amount;
            int givenItem2;
            int givenItem2Amount;
            int givenItem3;
            int givenItem3Amount;
            int givenItem4;
            int givenItem4Amount;
            int choiceItem1;
            int choiceItem1Amount;
            int choiceItem2;
            int choiceItem2Amount;
            int choiceItem3;
            int choiceItem3Amount;
            int choiceItem4;
            int choiceItem4Amount;
            int choiceItem5;
            int choiceItem5Amount;
            int choiceItem6;
            int choiceItem6Amount;
            int unk6;
            int unk7;
            int unk8;
            int unk9;
            ///
            string name;
            string description;
            string detail;
            string subdescription;
            ///
            int killCreature1;
            int killCreature1Amount;
            int collectItem1;
            int collectItem1Amount;
            int killCreature2;
            int killCreature2Amount;
            int collectItem2;
            int collectItem2Amount;
            int killCreature3;
            int killCreature3Amount;
            int collectItem3;
            int collectItem3Amount;
            int killCreature4;
            int killCreature4Amount;
            int collectItem4;
            int collectItem4Amount;
            ///
            string objective1;
            string objective2;
            string objective3;
            string objective4;

            public QuestInfo(string str)
            {
                this.init(str);
            }

            public void init(string str)
            {
                var ary = str.Split("	");

                this.questId = Convert.ToUInt32(ary[0]);
                this.entryLength = Convert.ToUInt32(ary[1]);

                this.unk0 = Convert.ToInt32(ary[2]);
                this.unk1 = Convert.ToInt32(ary[3]); ;

                this.level = Convert.ToInt32(ary[4]);
                this.area = Convert.ToInt32(ary[5]);
                this.infoId = Convert.ToInt32(ary[6]);

                this.unk2 = Convert.ToInt32(ary[7]);
                this.unk3 = Convert.ToInt32(ary[8]);
                this.unk4 = Convert.ToInt32(ary[9]);
                this.unk5 = Convert.ToInt32(ary[10]);

                this.nextQuestID = Convert.ToInt32(ary[11]);
                this.coins = Convert.ToInt32(ary[12]);
                this.substitudeExp = Convert.ToInt32(ary[13]);
                this.spellReward = Convert.ToInt32(ary[14]);
                this.startingItemID = Convert.ToInt32(ary[15]);
                this.questFlags = Convert.ToInt32(ary[16]);
                this.givenItem1 = Convert.ToInt32(ary[17]);
                this.givenItem1Amount = Convert.ToInt32(ary[18]);
                this.givenItem2 = Convert.ToInt32(ary[19]);
                this.givenItem2Amount = Convert.ToInt32(ary[20]);
                this.givenItem3 = Convert.ToInt32(ary[21]);
                this.givenItem3Amount = Convert.ToInt32(ary[22]);
                this.givenItem4 = Convert.ToInt32(ary[23]);
                this.givenItem4Amount = Convert.ToInt32(ary[24]);

                this.choiceItem1 = Convert.ToInt32(ary[25]);
                this.choiceItem1Amount = Convert.ToInt32(ary[26]);
                this.choiceItem2 = Convert.ToInt32(ary[27]);
                this.choiceItem2Amount = Convert.ToInt32(ary[28]);
                this.choiceItem3 = Convert.ToInt32(ary[29]);
                this.choiceItem3Amount = Convert.ToInt32(ary[30]);
                this.choiceItem4 = Convert.ToInt32(ary[31]);
                this.choiceItem4Amount = Convert.ToInt32(ary[32]);
                this.choiceItem5 = Convert.ToInt32(ary[33]);
                this.choiceItem5Amount = Convert.ToInt32(ary[34]);
                this.choiceItem6 = Convert.ToInt32(ary[35]);
                this.choiceItem6Amount = Convert.ToInt32(ary[36]);

                this.unk6 = Convert.ToInt32(ary[37]);
                this.unk7 = Convert.ToInt32(ary[38]);
                this.unk8 = Convert.ToInt32(ary[39]);
                this.unk9 = Convert.ToInt32(ary[40]);

                /////
                this.name = ary[41];
                this.description = ary[42];
                this.detail = ary[43];
                this.subdescription = ary[44];

                this.killCreature1 = Convert.ToInt32(ary[45]);
                this.killCreature1Amount = Convert.ToInt32(ary[46]);
                this.collectItem1 = Convert.ToInt32(ary[47]);
                this.collectItem1Amount = Convert.ToInt32(ary[48]);

                this.killCreature2 = Convert.ToInt32(ary[49]);
                this.killCreature2Amount = Convert.ToInt32(ary[50]);
                this.collectItem2 = Convert.ToInt32(ary[51]);
                this.collectItem2Amount = Convert.ToInt32(ary[52]);

                this.killCreature3 = Convert.ToInt32(ary[53]);
                this.killCreature3Amount = Convert.ToInt32(ary[54]);
                this.collectItem3 = Convert.ToInt32(ary[55]);
                this.collectItem3Amount = Convert.ToInt32(ary[56]);

                this.killCreature4 = Convert.ToInt32(ary[57]);
                this.killCreature4Amount = Convert.ToInt32(ary[58]);
                this.collectItem4 = Convert.ToInt32(ary[59]);
                this.collectItem4Amount = Convert.ToInt32(ary[60]);

                this.objective1 = ary[61];
                this.objective2 = ary[62];
                this.objective3 = ary[63];
                this.objective4 = ary[64];

            }
            public QuestInfo(BinaryReader br)
            {
                this.questId = br.ReadUInt32();
                this.entryLength = br.ReadUInt32();

                this.unk0 = br.ReadInt32();
                this.unk1 = br.ReadInt32();

                this.level = br.ReadInt32();
                this.area = br.ReadInt32();
                this.infoId = br.ReadInt32();

                this.unk2 = br.ReadInt32();
                this.unk3 = br.ReadInt32();
                this.unk4 = br.ReadInt32();
                this.unk5 = br.ReadInt32();

                this.nextQuestID = br.ReadInt32();
                this.coins = br.ReadInt32();
                this.substitudeExp = br.ReadInt32();
                this.spellReward = br.ReadInt32();
                this.startingItemID = br.ReadInt32();
                this.questFlags = br.ReadInt32();
                this.givenItem1 = br.ReadInt32();
                this.givenItem1Amount = br.ReadInt32();
                this.givenItem2 = br.ReadInt32();
                this.givenItem2Amount = br.ReadInt32();
                this.givenItem3 = br.ReadInt32();
                this.givenItem3Amount = br.ReadInt32();
                this.givenItem4 = br.ReadInt32();
                this.givenItem4Amount = br.ReadInt32();

                this.choiceItem1 = br.ReadInt32();
                this.choiceItem1Amount = br.ReadInt32();
                this.choiceItem2 = br.ReadInt32();
                this.choiceItem2Amount = br.ReadInt32();
                this.choiceItem3 = br.ReadInt32();
                this.choiceItem3Amount = br.ReadInt32();
                this.choiceItem4 = br.ReadInt32();
                this.choiceItem4Amount = br.ReadInt32();
                this.choiceItem5 = br.ReadInt32();
                this.choiceItem5Amount = br.ReadInt32();
                this.choiceItem6 = br.ReadInt32();
                this.choiceItem6Amount = br.ReadInt32();

                this.unk6 = br.ReadInt32();
                this.unk7 = br.ReadInt32();
                this.unk8 = br.ReadInt32();
                this.unk9 = br.ReadInt32();

                /////
                this.name = getString(br);
                this.description = getString(br);
                this.detail = getString(br);
                this.subdescription = getString(br);
                ////

                this.killCreature1 = br.ReadInt32();
                this.killCreature1Amount = br.ReadInt32();
                this.collectItem1 = br.ReadInt32();
                this.collectItem1Amount = br.ReadInt32();

                this.killCreature2 = br.ReadInt32();
                this.killCreature2Amount = br.ReadInt32();
                this.collectItem2 = br.ReadInt32();
                this.collectItem2Amount = br.ReadInt32();

                this.killCreature3 = br.ReadInt32();
                this.killCreature3Amount = br.ReadInt32();
                this.collectItem3 = br.ReadInt32();
                this.collectItem3Amount = br.ReadInt32();

                this.killCreature4 = br.ReadInt32();
                this.killCreature4Amount = br.ReadInt32();
                this.collectItem4 = br.ReadInt32();
                this.collectItem4Amount = br.ReadInt32();

                this.objective1 = getString(br);
                this.objective2 = getString(br);
                this.objective3 = getString(br);
                this.objective4 = getString(br);
            }


            public static string getTSVTitle()
            {
                return "questID	entryLength	unk0	unk1	level	area	infoID	unk2	unk3	unk4	unk5	nextQuestID	coins	substitudeExp	spellReward	startingItemID	questFlags	givenItem1	givenItem1Amount	givenItem2	givenItem2Amount	givenItem3	givenItem3Amount	givenItem4	givenItem4Amount	choiceItem1	choiceItem1Amount	choiceItem2	choiceItem2Amount	choiceItem3	choiceItem3Amount	choiceItem4	choiceItem4Amount	choiceItem5	choiceItem5Amount	choiceItem6	choiceItem6Amount	unk6	unk7	unk8	unk9	name	description	detail	subdescription	killCreature1	killCreature1Amount	collectItem1	collectItem1Amount	killCreature2	killCreature2Amount	collectItem2	collectItem2Amount	killCreature3	killCreature3Amount	collectItem3	collectItem3Amount	killCreature4	killCreature4Amount	collectItem4	collectItem4Amount	objective1	objective2	objective3	objective4";
            }

            public static string getTSVTitleWithoutUnk()
            {
                return "questID	level	area	infoID	nextQuestID	coins	substitudeExp	spellReward	startingItemID	questFlags	givenItem1	givenItem1Amount	givenItem2	givenItem2Amount	givenItem3	givenItem3Amount	givenItem4	givenItem4Amount	choiceItem1	choiceItem1Amount	choiceItem2	choiceItem2Amount	choiceItem3	choiceItem3Amount	choiceItem4	choiceItem4Amount	choiceItem5	choiceItem5Amount	choiceItem6	choiceItem6Amount	name	description	detail	subdescription	killCreature1	killCreature1Amount	collectItem1	collectItem1Amount	killCreature2	killCreature2Amount	collectItem2	collectItem2Amount	killCreature3	killCreature3Amount	collectItem3	collectItem3Amount	killCreature4	killCreature4Amount	collectItem4	collectItem4Amount	objective1	objective2	objective3	objective4";
            }

            override public string ToString()
            {
                var sb = new StringBuilder();
                return sb.AppendJoin("	",
                questId,
                entryLength,
                unk0,
                unk1,
                level,
                area,
                infoId,
                unk2,
                unk3,
                unk4,
                unk5,
                nextQuestID,
                coins,
                substitudeExp,
                spellReward,
                startingItemID,
                questFlags,
                givenItem1,
                givenItem1Amount,
                givenItem2,
                givenItem2Amount,
                givenItem3,
                givenItem3Amount,
                givenItem4,
                givenItem4Amount,
                choiceItem1,
                choiceItem1Amount,
                choiceItem2,
                choiceItem2Amount,
                choiceItem3,
                choiceItem3Amount,
                choiceItem4,
                choiceItem4Amount,
                choiceItem5,
                choiceItem5Amount,
                choiceItem6,
                choiceItem6Amount,
                unk6,
                unk7,
                unk8,
                unk9,
                name,
                description,
                detail,
                subdescription,
                killCreature1,
                killCreature1Amount,
                collectItem1,
                collectItem1Amount,
                killCreature2,
                killCreature2Amount,
                collectItem2,
                collectItem2Amount,
                killCreature3,
                killCreature3Amount,
                collectItem3,
                collectItem3Amount,
                killCreature4,
                killCreature4Amount,
                collectItem4,
                collectItem4Amount,
                objective1,
                objective2,
                objective3,
                objective4
                ).ToString();
            }

            public string ToStringWithoutUnk()
            {
                var sb = new StringBuilder();
                return sb.AppendJoin("	",
                // Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}",
                questId,
                // entryLength,
                // unk0,
                // unk1,
                level,
                area,
                infoId,
                // unk2,
                // unk3,
                // unk4,
                // unk5,
                nextQuestID,
                coins,
                substitudeExp,
                spellReward,
                startingItemID,
                questFlags,
                givenItem1,
                givenItem1Amount,
                givenItem2,
                givenItem2Amount,
                givenItem3,
                givenItem3Amount,
                givenItem4,
                givenItem4Amount,
                choiceItem1,
                choiceItem1Amount,
                choiceItem2,
                choiceItem2Amount,
                choiceItem3,
                choiceItem3Amount,
                choiceItem4,
                choiceItem4Amount,
                choiceItem5,
                choiceItem5Amount,
                choiceItem6,
                choiceItem6Amount,
                // unk6,
                // unk7,
                // unk8,
                // unk9,
                name,
                description,
                detail,
                subdescription,
                killCreature1,
                killCreature1Amount,
                collectItem1,
                collectItem1Amount,
                killCreature2,
                killCreature2Amount,
                collectItem2,
                collectItem2Amount,
                killCreature3,
                killCreature3Amount,
                collectItem3,
                collectItem3Amount,
                killCreature4,
                killCreature4Amount,
                collectItem4,
                collectItem4Amount,
                objective1,
                objective2,
                objective3,
                objective4
                ).ToString();
            }


            public int getBinLength()
            {
                var len = 55 * 4;
                len += Encoding.Default.GetByteCount(name) + 1 +
                Encoding.Default.GetByteCount(description) + 1 +
                Encoding.Default.GetByteCount(detail) + 1 +
                Encoding.Default.GetByteCount(subdescription) + 1 +
                Encoding.Default.GetByteCount(objective1) + 1 +
                Encoding.Default.GetByteCount(objective2) + 1 +
                Encoding.Default.GetByteCount(objective3) + 1 +
                Encoding.Default.GetByteCount(objective4) + 1;
                return len;
            }

            public void writeBin(BinaryWriter bw)
            {
                bw.Write(this.questId);
                this.entryLength = (uint)this.getBinLength();
                bw.Write(this.entryLength);

                bw.Write(this.unk0);
                bw.Write(this.unk1);

                bw.Write(this.level);
                bw.Write(this.area);
                bw.Write(this.infoId);

                bw.Write(this.unk2);
                bw.Write(this.unk3);
                bw.Write(this.unk4);
                bw.Write(this.unk5);

                bw.Write(this.nextQuestID);
                bw.Write(this.coins);
                bw.Write(this.substitudeExp);
                bw.Write(this.spellReward);
                bw.Write(this.startingItemID);
                bw.Write(this.questFlags);
                bw.Write(this.givenItem1);
                bw.Write(this.givenItem1Amount);
                bw.Write(this.givenItem2);
                bw.Write(this.givenItem2Amount);
                bw.Write(this.givenItem3);
                bw.Write(this.givenItem3Amount);
                bw.Write(this.givenItem4);
                bw.Write(this.givenItem4Amount);

                bw.Write(this.choiceItem1);
                bw.Write(this.choiceItem1Amount);
                bw.Write(this.choiceItem2);
                bw.Write(this.choiceItem2Amount);
                bw.Write(this.choiceItem3);
                bw.Write(this.choiceItem3Amount);
                bw.Write(this.choiceItem4);
                bw.Write(this.choiceItem4Amount);
                bw.Write(this.choiceItem5);
                bw.Write(this.choiceItem5Amount);
                bw.Write(this.choiceItem6);
                bw.Write(this.choiceItem6Amount);

                bw.Write(this.unk6);
                bw.Write(this.unk7);
                bw.Write(this.unk8);
                bw.Write(this.unk9);

                /////

                bw.Write(Encoding.Default.GetBytes(this.name));
                bw.Write((byte)0);
                bw.Write(Encoding.Default.GetBytes(this.description));
                bw.Write((byte)0);
                bw.Write(Encoding.Default.GetBytes(this.detail));
                bw.Write((byte)0);
                bw.Write(Encoding.Default.GetBytes(this.subdescription));
                bw.Write((byte)0);
                ////

                bw.Write(this.killCreature1);
                bw.Write(this.killCreature1Amount);
                bw.Write(this.collectItem1);
                bw.Write(this.collectItem1Amount);

                bw.Write(this.killCreature2);
                bw.Write(this.killCreature2Amount);
                bw.Write(this.collectItem2);
                bw.Write(this.collectItem2Amount);

                bw.Write(this.killCreature3);
                bw.Write(this.killCreature3Amount);
                bw.Write(this.collectItem3);
                bw.Write(this.collectItem3Amount);

                bw.Write(this.killCreature4);
                bw.Write(this.killCreature4Amount);
                bw.Write(this.collectItem4);
                bw.Write(this.collectItem4Amount);

                bw.Write(Encoding.Default.GetBytes(this.objective1));
                bw.Write((byte)0);
                bw.Write(Encoding.Default.GetBytes(this.objective2));
                bw.Write((byte)0);
                bw.Write(Encoding.Default.GetBytes(this.objective3));
                bw.Write((byte)0);
                bw.Write(Encoding.Default.GetBytes(this.objective4));
                bw.Write((byte)0);
            }
        }

        static int tempLength = 0;
        static char[] tempAry = new char[2048];
        static String getString(BinaryReader br)
        {
            if (br.PeekChar() == 0)
            {
                br.ReadByte();
                return "";
            }
            else
            {
                tempLength = 0;
                char c;
                while ((c = br.ReadChar()) != 0)
                {
                    tempAry[tempLength] = c;
                    tempLength++;
                }

                return new String(tempAry, 0, tempLength);
            }
        }

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("use: wdbconv.exe aaa.wdb/bbb.tsv");
                return;
            }

            var path = args[0];
            if (!File.Exists(path))
            {
                Console.WriteLine("file {0} does not exists", path);
                return;
            }


            bool isWdb = path.EndsWith("wdb");
            var outPath = path + (isWdb ? ".tsv" : ".wdb");

            var rfs = new FileStream(path, FileMode.Open);
            var wfs = new FileStream(outPath, FileMode.Create);
            if (isWdb)
            {
                var br = new BinaryReader(rfs);
                var header = new WDBHeader(br);
                var sw = new StreamWriter(wfs);
                Console.WriteLine("sign:{0} version:{1} language:{2}", new String(header.signatrue), header.version, new String(header.language));
                sw.WriteLine(QuestInfo.getTSVTitle());
                while (br.BaseStream.Length - br.BaseStream.Position > 20)
                {
                    var quest = new QuestInfo(br);
                    sw.WriteLine(quest.ToString());
                }

                sw.Flush();
                sw.Close();
                br.Close();
            }
            else
            {
                var tsvSr = new StreamReader(rfs);
                var wdbBw = new BinaryWriter(wfs);
                wdbBw.Write(0x57515354);
                wdbBw.Write(0x16f3);
                wdbBw.Write(0x7a68434e);
                wdbBw.Write(0x18dc);
                wdbBw.Write(0x3);

                tsvSr.ReadLine();//skip title
                var quest = new QuestInfo(tsvSr.ReadLine());
                quest.writeBin(wdbBw);
                while (!tsvSr.EndOfStream)
                {
                    quest.init(tsvSr.ReadLine());
                    quest.writeBin(wdbBw);
                }
                ///padding end
                wdbBw.Write(0);
                wdbBw.Write(0);

                tsvSr.Close();
                wdbBw.Flush();
                wdbBw.Close();
            }

            wfs.Close();
            rfs.Close();
        }
    }
}
