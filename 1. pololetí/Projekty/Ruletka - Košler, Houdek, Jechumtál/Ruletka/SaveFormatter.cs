using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ruletka
{
    public static class SaveFormatter
    {
        private const string DATA_FILENAME = "savegame.niger";

        public static void Save(double balance)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                FileStream stream = new FileStream(DATA_FILENAME, FileMode.Create, FileAccess.Write);

                formatter.Serialize(stream, balance);

                stream.Close();
            }
            catch
            {
                throw new SaveAndLoadException("Your progress cannot be saved.");
            }
        }
        public static double Load()
        {
            double balance;
            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists(DATA_FILENAME))
            {
                try
                {
                    FileStream stream = new FileStream(DATA_FILENAME, FileMode.Open, FileAccess.Read);

                    balance = (double)formatter.Deserialize(stream);

                    stream.Close();

                    return balance;
                }
                catch
                {
                    throw new SaveAndLoadException("Your progress cannot be loaded");      
                }

            }
            else
            {
                return 0;
            }
        }
    }
}

