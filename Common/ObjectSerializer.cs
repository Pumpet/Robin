//
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE.
//
//  License: GNU Lesser General Public License (LGPLv3)
//
//  Email: pumpet.net@gmail.com
//  Git: https://github.com/Pumpet/Robin
//  Copyright (C) Alex Rozanov, 2020 
//

using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Common {

    /// <summary>Сериализация в xml
    /// </summary>
    public static class OptionsSerializer {
        /// <summary>Загрузить объект указанного типа из файла
        /// </summary>
        /// <param name="file">имя файла</param>
        public static T Load<T>(string file) where T : class {
            T obj = null;
            if (!File.Exists(file))
                throw new Exception(String.Format("File not found {0}", file));
            try {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                using (var s = new StreamReader(file, Encoding.GetEncoding("windows-1251"))) {
                    obj = (T)xs.Deserialize(s);
                }
            }
            catch (Exception ex) {
                Loger.SendMess(ex, $"Ошибка получения объекта из файла {file}");
            }
            return obj;
        }

        public static T LoadXML<T>(string xml) where T : class {
            T obj = null;
            try {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                var s = new StringReader(xml);
                obj = (T)xs.Deserialize(s);
            }
            catch (Exception ex) {
                Loger.SendMess(ex, $"Ошибка получения объекта из XML");
            }
            return obj;
        }

        /// <summary>
        /// Сохранить объект указанного типа в файл
        /// </summary>
        /// <param name="file">имя файла</param>
        /// <param name="obj">объект указанного типа</param>
        public static void Save<T>(string file, T obj) where T : class {
            if (obj == null)
                return;
            try {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                using (var s = new StreamWriter(file, false, Encoding.GetEncoding("windows-1251"))) {
                    xs.Serialize(s, obj);
                }
            }
            catch (Exception ex) {
                Loger.SendMess(ex, $"Ошибка записи объекта в файл {file}");
            }
        }

        public static string GetXML<T>(T obj) where T : class {
            string res = null;
            if (obj == null)
                return null;
            try {
                StringWriter writer = new StringWriter(CultureInfo.InvariantCulture);
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(writer, obj);
                res = writer.ToString();
            }
            catch (Exception ex) {
                Loger.SendMess(ex, $"Ошибка формирования XML из объекта");
            }
            return res;
        }
    }
}
