using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace DungeonManagerWpf
{
    static class Settings
    {
        public static List<Character> Characters = new List<Character>();
        
        public static void SaveSettings()
        {
            string settingsPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\dmsave.xml";
            DmSettings save = new DmSettings();

            save.Characters = Characters;

            XmlSerializer xmlSerial = new XmlSerializer(typeof(DmSettings));
            try
            {
                using (Stream fStream = new FileStream(settingsPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xmlSerial.Serialize(fStream, save);
                }

            }
            catch (Exception e)
            {
                //System.Windows.Forms.MessageBox.Show("Could not save settings file. Check permissions.", "DungeonManager");
            }
        }

        public static void LoadSettings()
        {
            string settingsPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\dmsave.xml";
            if (File.Exists(settingsPath))
            {
                try
                {
                    DmSettings XmlSave;
                    XmlSerializer xmlSerial = new XmlSerializer(typeof(DmSettings));
                    using (Stream fStream = new FileStream(settingsPath, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        XmlSave = (DmSettings)xmlSerial.Deserialize(fStream);
                        Characters = XmlSave.Characters;

                    }

                }
                catch (Exception e)
                {

                }
            }
        }
    }
    [Serializable]
    public class DmSettings
    {
        public List<Character> Characters = new List<Character>();
        public DmSettings()
        { }
    }
}
