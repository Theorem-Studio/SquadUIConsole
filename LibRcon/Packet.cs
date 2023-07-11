using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibRcon
{
    internal class Packet
    {
        public int Size;
        public int ID;
        public int Type;
        public string Body = "0";
        private const byte End = 0;
        public Packet() { }
        public Packet(int id, int type, string body)
        {
            ID = id;
            Type = type;
            Body = body;
        }
        public byte[] ToStream()
        {
            var res = new MemoryStream();
            using (var bw = new BinaryWriter(res))
            {
                bw.Write((int)0);
                bw.Write(ID);
                bw.Write(Type);
                bw.Write(Encoding.UTF8.GetBytes(Body));
                bw.Write(End);
                bw.Write(End);
                bw.BaseStream.Position = 0;
                bw.Write((int)bw.BaseStream.Length - 4);
            }
            return res.ToArray();
        }
        public static byte[] Packet2Stream(Packet src)
        {
            return src.ToStream();
        }
        public static Packet Stream2Packet(Stream src)
        {
            Packet res = new Packet();
            using (var br = new BinaryReader(src))
            {
                res.Size = br.ReadInt32();
                res.ID = br.ReadInt32();
                res.Type = br.ReadByte();
                res.Body = br.ReadString();
            }
            return res;
        }
        public static Packet Stream2Packet(byte[] src)
        {
            Packet res = new Packet();
            using (var br = new BinaryReader(new MemoryStream(src)))
            {
                res.Size = br.ReadInt32();
                res.ID = br.ReadInt32();
                res.Type = br.ReadByte();
                res.Body = Encoding.UTF8.GetString(src, 12, res.Size - 9);
            }
            return res;
        }
    }
}
