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

        /// <summary>Получить значение параметра</summary>
        public static string GetPropValue(string name) {
            return config?.Props?.FirstOrDefault(x => x.Name == name)?.Value;
        }

        /// <summary>Установить значение параметра (если параметра нет - создаст новый)</summary>
        public static void SetPropValue(string name, string value) {
            if (config?.Props == null)
                return;
            var prop = config.Props.FirstOrDefault(x => x.Name == name);
            if (prop == null)
                config.Props.Add(new Prop() { Name = name, Value = value });
            else
                prop.Value = value;
        }

        /// <summary>Установить значения параметров или создать новые параметры по данным словаря (имя-значение)</summary>
        public static void SetFromDict(Dictionary<string, string> dict) {
            if (dict == null)
                return;
            foreach (var item in dict) {
                SetPropValue(item.Key, item.Value);
            }
        }

        /// <summary>Получить объект параметра</summary>
        public static Prop GetProp(string name) {
            return config?.Props?.FirstOrDefault(x => x.Name == name);
        }

        /// <summary>Проверить наличие параметра</summary>
        public static bool HasProp(string name) {
            return config?.Props?.Any(x => x.Name == name) ?? false;
        }

        /// <summary>Получить список значений параметров группы</summary>
        public static List<string> GetGroupValues(string group) {
            return config?.Props?.Where(x => x.Group == group && !string.IsNullOrEmpty(group))?.Select(x => x.Value).ToList();
        }

        /// <summary>Получить список объектов параметров (весь или указанной группы)</summary>
        public static List<Prop> GetProps(string group = null) {
            return config?.Props?.Where(x => x.Group == group || string.IsNullOrEmpty(group)).ToList();
        }

        /// <summary>Загружает параметры приложения из файла. Если файла нет - создает новый.
        /// </summary>
        /// <param name="fileName">Имя файла, по умолчанию: имя приложения.xml</param>
        public static void Load(string fileName = "") {
            if (string.IsNullOrWhiteSpace(fileName))
                fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName.Replace("|",".")) + ".xml");
            try {
                if (!File.Exists(fileName))
                    fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName.Replace("|", ".").Replace("vshost.", "")) + ".xml");
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
        public string Group { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Value { get; set; }
    }
}
