using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using WotReplayParser.Entity;

namespace WotReplayParser
{
    class Parse
    {
        public void parse(String fileName)
        {

            FileStream fs = new FileStream(fileName, FileMode.Open);

            // read block count 
            int blockCount = readDataBlockCount(fs);

            //skip 3 byte 
            _ = readBytesFromFileStream(fs, 3);


            List<byte[]> datablocks = new List<byte[]>();

            //loop read block 
            for (int i = 0; i < blockCount; i++)
            {
                datablocks.Add(readDataBlock(fs));
            }

            for (int i = 0; i < blockCount; i++)
            {
                string jsonStr = Encoding.UTF8.GetString(datablocks[i]);
                Console.WriteLine(jsonStr);
                //DataBlock dataBlock = JsonConvert.DeserializeObject<DataBlock>(jsonStr);
            }

            //last encrypted slice, unknown content
            //skip 4 byte
            readBytesFromFileStream(fs, 4);
            //read length
            uint sliceLength = bytesToUIntLE(readBytesFromFileStream(fs, 4));
            //skip slice
            readBytesFromFileStream(fs, sliceLength);

            if (datablocks.Count < 1)
            {
                return;
            }
        }


        int readDataBlockCount(FileStream fs)
        {
            //skip 4 bytes in file head , is might be the magic number of the file
            //0x12 0x32 0x34 0x11 
            readBytesFromFileStream(fs, 4);
            return fs.ReadByte();
        }



        byte[] readDataBlock(FileStream fs)
        {
            //readBlockLength
            byte[] intBytes = readBytesFromFileStream(fs, 4);
            uint blockLength = bytesToUIntLE(intBytes);
            //read block array
            byte[] blockArray = readBytesFromFileStream(fs, blockLength);

            return blockArray;
        }



        /* Read 
         * 
         * 
         */
        byte[] readBytesFromFileStream(FileStream fs, uint length)
        {
            //check if file does not have enough bytes to read
            if (fs.Length - fs.Position < length)
            {
                throw new Exception("Read error ! File length not enough to read ! Current position " + fs.Position + ", read length " + length + ".");
            }
            byte[] bytes = new byte[length];
            fs.Read(bytes);
            return bytes;
        }

        /* 
         * cast byte array to int with big-endian
         */
        uint bytesToUIntLE(byte[] bytes)
        {
            if (bytes.Length < 4)
            {
                return 0;
            }
            return (uint)(bytes[0]  |
                bytes[1] << 1 * 8 |
                bytes[2] << 2 * 8 |
                bytes[3] << 3 * 8);
        }


    }
}
