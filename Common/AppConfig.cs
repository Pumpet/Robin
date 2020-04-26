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
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace Common {

    /// <summary>Параметры приложения
    /// </summary>
    public class AppConfig {

        string fileName;
        public static AppConfig config;

        [XmlElement("Prop")]
        public List<Prop> Props { get; set; }

        public AppConfig() {
            Props = new List<Prop>();
        }

        public static string Prop(string name) {
            return config?.Props?.FirstOrDefault(x => x.Name == name)?.Value;
        }

        public static bool Has(string name) {
            return config?.Props?.Any(x => x.Name == name) ?? false;
        }

        /// <summary>Загружает параметры приложения из файла. Если файла нет - создает новый.
        /// </summary>
        /// <param name="fileName">Имя файла, по умолчанию: имя приложения.xml</param>
        public static void Load(string fileName = "") {
            if (string.IsNullOrWhiteSpace(fileName))
                fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName) + ".xml");
            try {
                if (!File.Exists(fileName))
                    fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName.Replace("vshost.", "")) + ".xml");
                if (!File.Exists(fileName))
                    OptionsSerializer.Save(fileName, new AppConfig());
                config = OptionsSerializer.Load<AppConfig>(fileName);
                if (config != null)
                    config.fileName = fileName;
            }
            catch (Exception ex) {
                Loger.SendMess(ex, "Ошибка загрузки конфигурации из файла " + fileName);
            }
        }
        
        /// <summary>Записывает параметры приложения в файл.
        /// </summary>
        public static void Save() {
            if (config != null)
                OptionsSerializer.Save(config.fileName, config);
        }
    }
    
    /// <summary>Параметр приложения
    /// </summary>
    public class Prop {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Value { get; set; }
    }
}
